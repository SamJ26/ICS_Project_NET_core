using FilmManagment.GUI.Messages;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FilmManagment.GUI.Services
{
	public class Mediator : IMediator
	{
		private readonly Dictionary<Type, List<Delegate>> registeredActions = new Dictionary<Type, List<Delegate>>();

		public void Register<TMessage>(Action<TMessage> action) where TMessage : IMessage
		{
			var key = typeof(TMessage);
			if (!registeredActions.TryGetValue(key, out _))
			{
				registeredActions[key] = new List<Delegate>();
			}
			registeredActions[key].Add(action);
		}

		public void Send<TMessage>(TMessage message) where TMessage : IMessage
		{
			List<Delegate> foundActions;
			var key = typeof(TMessage);
			if (registeredActions.TryGetValue(key, out foundActions))
			{
				foreach (var action in foundActions.Select(action => action as Action<TMessage>).Where(action => action != null))
				{
					action(message);
				}
			}
		}

		public void UnRegister<TMessage>(Action<TMessage> action) where TMessage : IMessage
		{
			List<Delegate> foundActions;
			var key = typeof(TMessage);
			if (registeredActions.TryGetValue(key, out foundActions))
			{
				var actionsList = foundActions.ToList();
				actionsList.Remove(action);
				registeredActions[key] = new List<Delegate>(actionsList);

				// TODO: neslo by to takto zjednodusit ??
				registeredActions[key].Remove(action);
			}
		}
	}
}
