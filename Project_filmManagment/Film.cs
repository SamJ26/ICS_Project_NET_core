using System;
using System.Collections.Generic;
using System.Text;

namespace Project_filmManagment
{
    /// <summary>
    /// This class contains all informations about film
    /// For every new film, new object from this class need to be created
    /// </summary>
    class Film
    {
        // Private fields of the class ( they are private by default )
        string orignalName;
        string czechName;
        Genre genreOfFilm;
        int lengthInMinutes;
        string directorsName;
        string countryOfOrigin;
        string description;
        int numberOfRatings;                            // When new rating to the film is added, this variable will be incremented
        int sumOfAllAddedRatings;                       // This varaible holds sum of all added ratings in percent
        int overallRatingInPercents;                    // This variable is overall rating and is always changed when new rating to the film is added
                                                        // overallRatingInPercents = sumOfAllAddedRatings / numberOfRatigns
                                                        // e.g.: 85% = ( 80% + 90% ) / 2
        
        // Auto properties
        // If you add new actor to the film, new object Actor is created and you can specify details about him/her
        public List<Actor> Actors { get; set; }
        public List<Rating> Ratings { get; set; }

        // Default constructor
        // Changes variables of type string from default value null to string.Empty
        public Film()
        {
            orignalName = string.Empty;
            czechName = string.Empty;
            genreOfFilm = Genre.Undefined;
            lengthInMinutes = 0;
            directorsName = string.Empty;
            countryOfOrigin = string.Empty;
            description = string.Empty;
            numberOfRatings = 0;
            sumOfAllAddedRatings = 0;
            overallRatingInPercents = 0;
        }

        #region Properties

        // Methods for getting and setting the content of orignalName
        public string OriginalName
        {
            get => orignalName;
            set => orignalName = value;
        }

        // Methods for getting and setting the content of czechName
        public string CzechName
        {
            get => czechName;
            set => czechName = value;
        }

        // Methods for getting and setting the content of genreOfFilm
        public Genre GenreOfFilm
        {
            get => genreOfFilm;
            set => genreOfFilm = value;
        }

        // Methods for getting and setting the value of lengthInMinutes
        public int LengthInMinutes
        {
            get => lengthInMinutes;
            set => lengthInMinutes = value;
        }

        // Methods for getting and setting the content of director
        public string DirectorsName
        {
            get => directorsName;
            set => directorsName = value;
        }

        // Methods for getting and setting the content of countryOfOrigin
        public string CountryOfOrigin
        {
            get => countryOfOrigin;
            set => countryOfOrigin = value;
        }

        // Methods for getting and setting the content of description
        public string Description
        {
            get => description;
            set => description = value;
        }

        // Methods for getting and setting the value of numberOfRatings
        public int NumberOfRatings
        {
            get => numberOfRatings;
            set => numberOfRatings = value;
        }

        // Methods for getting and setting the value of overallRatingInPercents
        public int OverallRatingInPercents
        {
            get => overallRatingInPercents;
            set => overallRatingInPercents = value;
        }

        // Methods for getting and setting the value of sumOfAllAddedRatings
        public int SumOfAllAddedRatings
        {
            get => sumOfAllAddedRatings;
            set => sumOfAllAddedRatings = value;
        }

        #endregion

        /// <summary>
        /// Method for calculation of overall rating of the film
        /// Useage: OverallRatingInPercents = CalculateOverallRating();
        /// </summary>
        /// <returns></returns>
        public int CalculateOverallRating()
        {
            if (numberOfRatings == 0)
                return 0;
            return sumOfAllAddedRatings / numberOfRatings;
        }

    }
}
