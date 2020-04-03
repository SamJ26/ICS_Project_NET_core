using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace FilmManagment.DAL.Migrations
{
	public partial class AddedFirstSeed_Migration : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropForeignKey(
				name: "FK_FilmActorEntity_Actors_ActorId",
				table: "FilmActorEntity");

			migrationBuilder.DropForeignKey(
				name: "FK_FilmActorEntity_Films_FilmId",
				table: "FilmActorEntity");

			migrationBuilder.DropForeignKey(
				name: "FK_FilmDirectorEntity_Directors_DirectorId",
				table: "FilmDirectorEntity");

			migrationBuilder.DropForeignKey(
				name: "FK_FilmDirectorEntity_Films_FilmId",
				table: "FilmDirectorEntity");

			migrationBuilder.DropPrimaryKey(
				name: "PK_FilmDirectorEntity",
				table: "FilmDirectorEntity");

			migrationBuilder.DropPrimaryKey(
				name: "PK_FilmActorEntity",
				table: "FilmActorEntity");

			migrationBuilder.DeleteData(
				table: "Actors",
				keyColumn: "Id",
				keyValue: new Guid("63156919-53f4-4a7a-b099-1c57bace2307"));

			migrationBuilder.RenameTable(
				name: "FilmDirectorEntity",
				newName: "FilmsDirectorsEntity");

			migrationBuilder.RenameTable(
				name: "FilmActorEntity",
				newName: "FilmsActorsEntity");

			migrationBuilder.RenameIndex(
				name: "IX_FilmDirectorEntity_DirectorId",
				table: "FilmsDirectorsEntity",
				newName: "IX_FilmsDirectorsEntity_DirectorId");

			migrationBuilder.RenameIndex(
				name: "IX_FilmActorEntity_ActorId",
				table: "FilmsActorsEntity",
				newName: "IX_FilmsActorsEntity_ActorId");

			migrationBuilder.AddPrimaryKey(
				name: "PK_FilmsDirectorsEntity",
				table: "FilmsDirectorsEntity",
				columns: new[] { "FilmId", "DirectorId" });

			migrationBuilder.AddPrimaryKey(
				name: "PK_FilmsActorsEntity",
				table: "FilmsActorsEntity",
				columns: new[] { "FilmId", "ActorId" });

			migrationBuilder.InsertData(
				table: "Actors",
				columns: new[] { "Id", "Age", "FirstName", "PhotoFilePath", "SecondName", "WikiUrl" },
				values: new object[] { new Guid("63156915-53f4-4a7a-b099-1c57bace2307"), 59, "John", "c:/blabla/nic/bla/JohnStone", "Stone", "wikiurlJS" });

			migrationBuilder.InsertData(
				table: "Directors",
				columns: new[] { "Id", "Age", "FirstName", "PhotoFilePath", "SecondName", "WikiUrl" },
				values: new object[] { new Guid("880c8cf4-21cd-4c7a-a4a9-917502bd7db4"), 56, "Adam", "c:/blabla/nic/bla/AdamSilver", "Silver", "wikiurlAS" });

			migrationBuilder.InsertData(
				table: "Films",
				columns: new[] { "Id", "CountryOfOrigin", "CzechName", "Description", "GenreOfFilm", "ImageFilePath", "LengthInMinutes", "OriginalName" },
				values: new object[] { new Guid("07cab248-0bcf-4e36-a954-b4f8f619579e"), "USA", "White house", "Movie about white house", 1, "c:/blabla/nic/bla/WhiteHouse", new TimeSpan(0, 2, 56, 30, 0), "Bily dum" });

			migrationBuilder.InsertData(
				table: "FilmsActorsEntity",
				columns: new[] { "FilmId", "ActorId", "Id" },
				values: new object[] { new Guid("07cab248-0bcf-4e36-a954-b4f8f619579e"), new Guid("63156915-53f4-4a7a-b099-1c57bace2307"), new Guid("5c0154f3-6f6a-473c-8904-1a56dc39eb96") });

			migrationBuilder.InsertData(
				table: "FilmsDirectorsEntity",
				columns: new[] { "FilmId", "DirectorId", "Id" },
				values: new object[] { new Guid("07cab248-0bcf-4e36-a954-b4f8f619579e"), new Guid("880c8cf4-21cd-4c7a-a4a9-917502bd7db4"), new Guid("8805e086-0206-4b9e-8fba-031a2f04092a") });

			migrationBuilder.InsertData(
				table: "Ratings",
				columns: new[] { "Id", "FilmId", "RatingInPercents", "TextRating" },
				values: new object[] { new Guid("aa835099-587e-4dbb-b48e-f9c402f978a4"), new Guid("07cab248-0bcf-4e36-a954-b4f8f619579e"), 87, "Best movie I have seen so far" });

			migrationBuilder.AddForeignKey(
				name: "FK_FilmsActorsEntity_Actors_ActorId",
				table: "FilmsActorsEntity",
				column: "ActorId",
				principalTable: "Actors",
				principalColumn: "Id",
				onDelete: ReferentialAction.Cascade);

			migrationBuilder.AddForeignKey(
				name: "FK_FilmsActorsEntity_Films_FilmId",
				table: "FilmsActorsEntity",
				column: "FilmId",
				principalTable: "Films",
				principalColumn: "Id",
				onDelete: ReferentialAction.Cascade);

			migrationBuilder.AddForeignKey(
				name: "FK_FilmsDirectorsEntity_Directors_DirectorId",
				table: "FilmsDirectorsEntity",
				column: "DirectorId",
				principalTable: "Directors",
				principalColumn: "Id",
				onDelete: ReferentialAction.Cascade);

			migrationBuilder.AddForeignKey(
				name: "FK_FilmsDirectorsEntity_Films_FilmId",
				table: "FilmsDirectorsEntity",
				column: "FilmId",
				principalTable: "Films",
				principalColumn: "Id",
				onDelete: ReferentialAction.Cascade);
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropForeignKey(
				name: "FK_FilmsActorsEntity_Actors_ActorId",
				table: "FilmsActorsEntity");

			migrationBuilder.DropForeignKey(
				name: "FK_FilmsActorsEntity_Films_FilmId",
				table: "FilmsActorsEntity");

			migrationBuilder.DropForeignKey(
				name: "FK_FilmsDirectorsEntity_Directors_DirectorId",
				table: "FilmsDirectorsEntity");

			migrationBuilder.DropForeignKey(
				name: "FK_FilmsDirectorsEntity_Films_FilmId",
				table: "FilmsDirectorsEntity");

			migrationBuilder.DropPrimaryKey(
				name: "PK_FilmsDirectorsEntity",
				table: "FilmsDirectorsEntity");

			migrationBuilder.DropPrimaryKey(
				name: "PK_FilmsActorsEntity",
				table: "FilmsActorsEntity");

			migrationBuilder.DeleteData(
				table: "FilmsActorsEntity",
				keyColumns: new[] { "FilmId", "ActorId" },
				keyValues: new object[] { new Guid("07cab248-0bcf-4e36-a954-b4f8f619579e"), new Guid("63156915-53f4-4a7a-b099-1c57bace2307") });

			migrationBuilder.DeleteData(
				table: "FilmsDirectorsEntity",
				keyColumns: new[] { "FilmId", "DirectorId" },
				keyValues: new object[] { new Guid("07cab248-0bcf-4e36-a954-b4f8f619579e"), new Guid("880c8cf4-21cd-4c7a-a4a9-917502bd7db4") });

			migrationBuilder.DeleteData(
				table: "Ratings",
				keyColumn: "Id",
				keyValue: new Guid("aa835099-587e-4dbb-b48e-f9c402f978a4"));

			migrationBuilder.DeleteData(
				table: "Actors",
				keyColumn: "Id",
				keyValue: new Guid("63156915-53f4-4a7a-b099-1c57bace2307"));

			migrationBuilder.DeleteData(
				table: "Directors",
				keyColumn: "Id",
				keyValue: new Guid("880c8cf4-21cd-4c7a-a4a9-917502bd7db4"));

			migrationBuilder.DeleteData(
				table: "Films",
				keyColumn: "Id",
				keyValue: new Guid("07cab248-0bcf-4e36-a954-b4f8f619579e"));

			migrationBuilder.RenameTable(
				name: "FilmsDirectorsEntity",
				newName: "FilmDirectorEntity");

			migrationBuilder.RenameTable(
				name: "FilmsActorsEntity",
				newName: "FilmActorEntity");

			migrationBuilder.RenameIndex(
				name: "IX_FilmsDirectorsEntity_DirectorId",
				table: "FilmDirectorEntity",
				newName: "IX_FilmDirectorEntity_DirectorId");

			migrationBuilder.RenameIndex(
				name: "IX_FilmsActorsEntity_ActorId",
				table: "FilmActorEntity",
				newName: "IX_FilmActorEntity_ActorId");

			migrationBuilder.AddPrimaryKey(
				name: "PK_FilmDirectorEntity",
				table: "FilmDirectorEntity",
				columns: new[] { "FilmId", "DirectorId" });

			migrationBuilder.AddPrimaryKey(
				name: "PK_FilmActorEntity",
				table: "FilmActorEntity",
				columns: new[] { "FilmId", "ActorId" });

			migrationBuilder.InsertData(
				table: "Actors",
				columns: new[] { "Id", "Age", "FirstName", "PhotoFilePath", "SecondName", "WikiUrl" },
				values: new object[] { new Guid("63156919-53f4-4a7a-b099-1c57bace2307"), 40, "John", "c:/blabla/nic/bla", "Stone", "wikiurl" });

			migrationBuilder.AddForeignKey(
				name: "FK_FilmActorEntity_Actors_ActorId",
				table: "FilmActorEntity",
				column: "ActorId",
				principalTable: "Actors",
				principalColumn: "Id",
				onDelete: ReferentialAction.Cascade);

			migrationBuilder.AddForeignKey(
				name: "FK_FilmActorEntity_Films_FilmId",
				table: "FilmActorEntity",
				column: "FilmId",
				principalTable: "Films",
				principalColumn: "Id",
				onDelete: ReferentialAction.Cascade);

			migrationBuilder.AddForeignKey(
				name: "FK_FilmDirectorEntity_Directors_DirectorId",
				table: "FilmDirectorEntity",
				column: "DirectorId",
				principalTable: "Directors",
				principalColumn: "Id",
				onDelete: ReferentialAction.Cascade);

			migrationBuilder.AddForeignKey(
				name: "FK_FilmDirectorEntity_Films_FilmId",
				table: "FilmDirectorEntity",
				column: "FilmId",
				principalTable: "Films",
				principalColumn: "Id",
				onDelete: ReferentialAction.Cascade);
		}
	}
}
