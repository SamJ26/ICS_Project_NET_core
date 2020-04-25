using FilmManagment.BL;

namespace FilmManagment.GUI.Messages
{ 
    public class NewMessage<TwrappedModel>: Message<TwrappedModel> where TwrappedModel : IId
    {
    }
    
    public class UpdateMessage<TwrappedModel> : Message<TwrappedModel> where TwrappedModel : IId
    {
    }
    
    public class DeleteMessage<TwrappedModel> : Message<TwrappedModel> where TwrappedModel : IId
    {
    }
    
    public class SelectedMessage<TwrappedModel> : Message<TwrappedModel> where TwrappedModel : IId
    {
    }

    /// <summary>
    /// This message will be sent to MainViewModel when DetailButton on some ListView is pressed
    /// </summary>
    public class DetailButtonPushedMessage<TwrrappedModel> : Message<TwrrappedModel> where TwrrappedModel : IId
    {
    }
}
