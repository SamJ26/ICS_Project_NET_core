
using Project_filmManagment.DAL.Entities;
using System.Collections.Generic;

namespace Project_filmManagment.DAL.Tests
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
