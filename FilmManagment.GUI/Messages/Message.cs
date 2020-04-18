using FilmManagment.BL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FilmManagment.GUI.Messages
{
    // TODO: ModelWrapperBase instead of ModelBase ?
 
    public abstract class Message<TwrappedModel> : IMessage where TwrappedModel : ModelBase
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
