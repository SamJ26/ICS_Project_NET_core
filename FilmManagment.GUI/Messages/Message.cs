using System;
using System.Collections.Generic;
using System.Text;

namespace FilmManagment.GUI.Messages
{
    public abstract class Message<T> : IMessage
    {
        public Guid SenderId { get; set; }
        public Guid TargetId { get; set; }

        // TODO: continue
    }
}
