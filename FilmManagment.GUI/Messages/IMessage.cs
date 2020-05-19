using System;

namespace FilmManagment.GUI.Messages
{
	public interface IMessage
	{
		Guid Id { get; set; }
		Guid TargetId { get; set; }
	}
}
