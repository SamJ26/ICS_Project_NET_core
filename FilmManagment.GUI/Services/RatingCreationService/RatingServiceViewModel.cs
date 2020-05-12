using FilmManagment.GUI.Commands;
using FilmManagment.GUI.Messages;
using FilmManagment.GUI.ViewModels;
using FilmManagment.GUI.Wrappers;
using System.Windows.Input;

namespace FilmManagment.GUI.Services.RatingCreationService
{
    public class RatingServiceViewModel : ViewModelBase, IRatingServiceViewModel
    {
        private readonly IMediator usedMediator;

        public RatingServiceViewModel(IMediator mediator)
        {
            usedMediator = mediator;
            SaveButtonCommand = new RelayCommand(SaveRating, CanSave);
        }

        public ICommand SaveButtonCommand { get; set; }

        public int RatingInPercents { get; set; }
        public string TextRating { get; set; }

        private void SaveRating()
        {
            usedMediator.Send(new AddRatingToFilmMessage<RatingWrappedListModel>()
            {
                TextRating = this.TextRating,
                RatingInPercents = this.RatingInPercents
            });
        }

        private bool CanSave() => (RatingInPercents != 0 && !string.IsNullOrWhiteSpace(TextRating)) ? true : false;
    }
}
