
using Project_filmManagment.DAL.Entities;
using System.Collections.Generic;

namespace Project_filmManagment.DAL.Tests
{
    public class AppDbContextTests
    {
        public void AddNewActor()
        {
            var myActor = new ActorEntity();

            myActor.FirstName = "John";
            myActor.SecondName = "Stone";
            myActor.Age = 43;
            myActor.WikiUrl = "Wikipedia";
        }
    }
}
