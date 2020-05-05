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

    /// <summary>
    /// This message will be sent from WarningViewModel to specific ListViewModel to aprrove deletion
    /// </summary>
    public class YES_WarningResultMessage<TwrrappedModel> : Message<TwrrappedModel> where TwrrappedModel : IId
    {
    }

    /// <summary>
    /// This message will be sent from WarningViewModel to specific ListViewModel to reject deletion
    /// </summary>
    public class NO_WarningResultMessage<TwrrappedModel> : Message<TwrrappedModel> where TwrrappedModel : IId
    {
    }

    /// <summary>
    /// This message will be sent e.g. when you want to move on FilmDetail from ActorDetail via ActedMovies
    /// </summary>
    /// <typeparam name="TwrrappedModel"> Selected item which you want to see in detail view </typeparam>
    public class MoveFromDetailToDetail<TwrrappedModel> : Message<TwrrappedModel> where TwrrappedModel : IId
    {
    }
}
