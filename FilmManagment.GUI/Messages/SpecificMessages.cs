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
}
