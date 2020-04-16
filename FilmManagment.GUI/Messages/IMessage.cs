using System;

namespace FilmManagment.GUI.Messages
{
    public interface IMessage
    {
        // TODO: SenderId ... spravne pomenovanie ?
        Guid SenderId { get; set; }
        Guid TargetId { get; set; }
    }
}
