using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace FilmManagment.DAL.Migrations
{
	public partial class Added_new_seeds_Migration : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.InsertData(
				table: "Actors",
				columns: new[] { "Id", "Age", "FirstName", "PhotoFilePath", "SecondName", "WikiUrl" },
				values: new object[] { new Guid("562ed03a-dc26-41cf-8a01-ee78afd22541"), 50, "Axel", "c:/blabla/nic/bla/AxelBrown", "Brown", "wikiurlAB" });

			migrationBuilder.InsertData(
				table: "Directors",
				columns: new[] { "Id", "Age", "FirstName", "PhotoFilePath", "SecondName", "WikiUrl" },
				values: new object[] { new Guid("d4a48f01-c183-4b22-a4a7-5fdf1fa2634f"), 60, "George", "c:/blabla/nic/bla/GeorgeBlack", "Black", "wikiurlGB" });

			migrationBuilder.InsertData(
				table: "Films",
				columns: new[] { "Id", "CountryOfOrigin", "CzechName", "Description", "GenreOfFilm", "ImageFilePath", "LengthInMinutes", "OriginalName" },
				values: new object[,]
				{
					{ new Guid("5729a349-b4ec-4c7e-ab3b-86ae981003d9"), "Denmark", "Dansky hrdina", "Film about Danish Hero", 2, "c:/blabla/nic/bla/DanishHero", new TimeSpan(0, 2, 56, 30, 0), "Danish Hero" },
					{ new Guid("03b8ccb9-c1c2-4251-b86e-4a2a0baccfc7"), "England", "Velký návrat", "Movie about one of the best sport comeback", 7, "c:/blabla/nic/bla/BigComeback", new TimeSpan(0, 2, 56, 30, 0), "Big Comeback" }
				});

			migrationBuilder.InsertData(
				table: "FilmsActorsEntity",
				columns: new[] { "FilmId", "ActorId", "Id" },
				values: new object[] { new Guid("5729a349-b4ec-4c7e-ab3b-86ae981003d9"), new Guid("562ed03a-dc26-41cf-8a01-ee78afd22541"), new Guid("4117bfcc-b81f-4e73-b8cc-af8a14135621") });

			migrationBuilder.InsertData(
				table: "FilmsDirectorsEntity",
				columns: new[] { "FilmId", "DirectorId", "Id" },
				values: new object[] { new Guid("5729a349-b4ec-4c7e-ab3b-86ae981003d9"), new Guid("d4a48f01-c183-4b22-a4a7-5fdf1fa2634f"), new Guid("9e00af51-7eba-496a-9e72-254eaa9b674d") });

			migrationBuilder.InsertData(
				table: "Ratings",
				columns: new[] { "Id", "FilmId", "RatingInPercents", "TextRating" },
				values: new object[] { new Guid("2ed269bc-2c39-457e-bf7c-96258b3d247a"), new Guid("5729a349-b4ec-4c7e-ab3b-86ae981003d9"), 50, "Pretty average" });
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DeleteData(
				table: "Films",
				keyColumn: "Id",
				keyValue: new Guid("03b8ccb9-c1c2-4251-b86e-4a2a0baccfc7"));

			migrationBuilder.DeleteData(
				table: "FilmsActorsEntity",
				keyColumns: new[] { "FilmId", "ActorId" },
				keyValues: new object[] { new Guid("5729a349-b4ec-4c7e-ab3b-86ae981003d9"), new Guid("562ed03a-dc26-41cf-8a01-ee78afd22541") });

			migrationBuilder.DeleteData(
				table: "FilmsDirectorsEntity",
				keyColumns: new[] { "FilmId", "DirectorId" },
				keyValues: new object[] { new Guid("5729a349-b4ec-4c7e-ab3b-86ae981003d9"), new Guid("d4a48f01-c183-4b22-a4a7-5fdf1fa2634f") });

			migrationBuilder.DeleteData(
				table: "Ratings",
				keyColumn: "Id",
				keyValue: new Guid("2ed269bc-2c39-457e-bf7c-96258b3d247a"));

			migrationBuilder.DeleteData(
				table: "Actors",
				keyColumn: "Id",
				keyValue: new Guid("562ed03a-dc26-41cf-8a01-ee78afd22541"));

			migrationBuilder.DeleteData(
				table: "Directors",
				keyColumn: "Id",
				keyValue: new Guid("d4a48f01-c183-4b22-a4a7-5fdf1fa2634f"));

			migrationBuilder.DeleteData(
				table: "Films",
				keyColumn: "Id",
				keyValue: new Guid("5729a349-b4ec-4c7e-ab3b-86ae981003d9"));
		}
	}
}
