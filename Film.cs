using System;
using System.Collections.Generic;
using System.Text;

namespace Project_filmManagment
{
    // TODO: where to place this enum variable ???
    /// <summary>
    /// Enum type for genres
    /// </summary>
    enum Genre
    {
        Undefined,
        ActionFilm,
        AdventureFilm,
        ComedyFilm,
        HorrorFilm,
        HistoricalFilm,
        DocumentaryFilm,
        DramaFilm,
        ScienceFilm,
        WarFilm
    }

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
        string countryOfOrigin;
        string description;
        object rating;                  // This reference variable will point at description which belongs to the film
        int numberOfRatings;            // When new rating to the film is added, this variable will be incremented
        int sumOfAllAddedRatings;       // This varaible holds sum of all added ratings in percent
        int overallRatingInPercents;    // This variable is overall rating and is always changed when new rating to the film is added
                                        // overallRatingInPercents = sumOfAllAddedRatings / numberOfRatigns
                                        // e.g.: 85% = ( 80% + 90% ) / 2

        string[] actors;                // In this array will be stored all actors, which played in the film       
        int actors_index;               // Keep track of index in array actors

        string director;                // TODO: could be there more than one director ???

        // Default constructor
        public Film()
        {
            orignalName = string.Empty;
            czechName = string.Empty;
            genreOfFilm = Genre.Undefined;
            lengthInMinutes = 0;
            countryOfOrigin = string.Empty;
            description = string.Empty;
            rating = null;
            actors = new string[10];                // Default length is 10 because of simplicity of code
            actors_index = 0;
            director = string.Empty;
            numberOfRatings = 0;
            sumOfAllAddedRatings = 0;
            overallRatingInPercents = 0;
        }

        #region Properties

        // Methods for getting and setting the content of orignalName
        public string OriginalName
        {
            get { return orignalName; }
            set { orignalName = value; }
        }

        // Methods for getting and setting the content of czechName
        public string CzechName
        {
            get { return czechName; }
            set { czechName = value; }
        }

        // Methods for getting and setting the content of genreOfFilm
        public Genre GenreOfFilm
        {
            get { return genreOfFilm; }
            set { genreOfFilm = value; }
        }

        // Methods for getting and setting the value of lengthInMinutes
        public int LengthInMinutes
        {
            get { return lengthInMinutes; }
            set { lengthInMinutes = value; }
        }

        // Methods for getting and setting the content of countryOfOrigin
        public string CountryOfOrigin
        {
            get { return countryOfOrigin; }
            set { countryOfOrigin = value; }
        }

        // Methods for getting and setting the content of description
        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        // Method for getting and setting the content of rating
        // If rating to film is added, new object from class Ratings is created and reference to this object is saved
        public object Rating
        {
            get { return rating; }
            set { rating = value; }
        }

        // Method for setting the content of array actors
        public string Actors
        {
            set
            {
                if (actors_index >= 0 && actors_index < actors.Length)
                    actors[actors_index] = value;
                ++actors_index;
            }
        }

        // Methods for getting and setting the content of director
        public string Director
        {
            get { return director; }
            set { director = value; }
        }

        // Methods for getting and setting the value of numberOfRatings
        public int NumberOfRatings
        {
            get { return numberOfRatings; }
            set { numberOfRatings = value; }
        }

        // Methods for getting and setting the value of overallRatingInPercents
        public int OverallRatingInPercents
        {
            get { return overallRatingInPercents; }
            set { overallRatingInPercents = value; }
        }

        // Methods for getting and setting the value of sumOfAllAddedRatings
        public int SumOfAllAddedRatings
        {
            get { return sumOfAllAddedRatings; }
            set { sumOfAllAddedRatings = value; }
        }

        #endregion

        // TODO: These functions are always created when new film is added and that is not very effective ... any improvement ???

        /// <summary>
        /// Method for printing out names of actors of chosen film
        /// </summary>
        public void ReadActersOfFilm()
        {
            for (int i = 0; i < 3; ++i)
                Console.WriteLine($"{i + 1}. actor: {actors[i]}");
        }

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

        // TODO: write a method for reading from array actors according to index
        // TODO: write a method for removing actors from the array actors

    }
}
