using System;
using System.Collections.Generic;
using System.Text;

namespace Project_filmManagment
{

    //TODO: This enum TypeOfPerson will be removed after adding new classes for actor and director

    /// <summary>
    /// Enum type for determining if the person is actor or director
    /// Default value which is assing to new person is undefined
    /// </summary>
    enum TypeOfPerson
    {
        Undefined,
        Actor,
        Director
    }

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

}
