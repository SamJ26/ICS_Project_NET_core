
using FilmManagment.DAL.Entities;
using System.Collections.Generic;

namespace FilmManagment.DAL.Tests
{
    public class AppDbContextTests
    {
        public void AddNew_Actor()
        {
            var myActor = new ActorEntity();

            myActor.FirstName = "John";
            myActor.SecondName = "Stone";
            myActor.Age = 43;
            myActor.UrlWiki = "Wikipedia";

        }
    }
}
