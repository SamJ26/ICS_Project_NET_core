﻿using FilmManagment.BL;

namespace FilmManagment.GUI.Messages
{
	public class NewMessage<TwrappedModel> : Message<TwrappedModel> where TwrappedModel : IId
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
	/// This message will be sent e.g. when you want to move on FilmDetail from ActorDetail via Actor.ActedMovies
	/// </summary>
	/// <typeparam name="TwrrappedModel"> Selected item which you want to see in detail view </typeparam>
	public class MoveToDetailMessage<TwrrappedModel> : Message<TwrrappedModel> where TwrrappedModel : IId
	{
	}

	/// <summary>
	/// This message will be sent to FilmDetailViewModel when user select actor or director in SelectiveWindow
	/// </summary>
	/// <typeparam name="TwrrappedModel"> Type of selected person ( DirectorWrappedModel / ActorWrappedModel ) </typeparam>
	public class AddPersonToFilmMessage<TwrrappedModel> : Message<TwrrappedModel> where TwrrappedModel : IId
	{
		public string PersonName { get; set; } = string.Empty;
	}

	/// <summary>
	/// This is message will be sent to FilmDetailViewModel when user press Save button on RatingServiceWindow
	/// </summary>
	/// <typeparam name="TwrrappedModel"> Always RatingWrappedModel </typeparam>
	public class AddRatingToFilmMessage<TwrrappedModel> : Message<TwrrappedModel> where TwrrappedModel : IId
	{
		public string TextRating { get; set; } = string.Empty;
		public int RatingInPercents { get; set; } = 0;
	}
}
