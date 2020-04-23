using FilmManagment.BL;
using System;

namespace FilmManagment.GUI.Messages
{
    public abstract class Message<TwrappedModel> : IMessage where TwrappedModel : IId
    {
        // TODO: is this ID of sender object ?
        private Guid? id;

        public TwrappedModel Model;

        public Guid Id
        {
            get => id ?? Model.Id;
            set => id = value;
        }

        public Guid TargetId { get; set; }
    }
}
