using System;

namespace FilmManagment.GUI.Messages
{
    public interface IMessage
    {
        Guid SenderId { get; set; }
        Guid TargetId { get; set; }
    }
}
