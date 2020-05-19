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

			ratingInPercents = 0;
			textRating = string.Empty;
		}

		public ICommand SaveButtonCommand { get; set; }

		private int ratingInPercents;
		public int RatingInPercents
		{
			get => ratingInPercents;
			set
			{
				ratingInPercents = value;
				OnPropertyChanged();
			}
		}

		private string textRating;
		public string TextRating
		{
			get => textRating;
			set
			{
				textRating = value;
				OnPropertyChanged();
			}
		}

		private void SaveRating()
		{
			usedMediator.Send(new AddRatingToFilmMessage<RatingWrappedListModel>()
			{
				TextRating = this.TextRating,
				RatingInPercents = this.RatingInPercents
			});
			ratingInPercents = 0;
			textRating = string.Empty;
		}

		private bool CanSave() => (RatingInPercents != 0 && !string.IsNullOrWhiteSpace(TextRating)) ? true : false;
	}
}
