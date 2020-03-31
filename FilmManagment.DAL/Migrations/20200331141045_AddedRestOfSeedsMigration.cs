using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FilmManagment.DAL.Migrations
{
    public partial class AddedRestOfSeedsMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Actors",
                columns: new[] { "Id", "Age", "FirstName", "PhotoFilePath", "SecondName", "WikiUrl" },
                values: new object[,]
                {
                    { new Guid("5aae9cc3-b880-441c-b88e-ca00242db99f"), 21, "Mical", "c:/blabla/nic/bla/MicalMorris", "Morris", "wikiurlMM" },
                    { new Guid("7793e739-6940-4c51-9f37-340be6e613a9"), 23, "Garreth", "c:/blabla/nic/bla/GarrethClark", "Clark", "wikiurlGC" }
                });

            migrationBuilder.InsertData(
                table: "Directors",
                columns: new[] { "Id", "Age", "FirstName", "PhotoFilePath", "SecondName", "WikiUrl" },
                values: new object[,]
                {
                    { new Guid("011a72e9-827c-48e4-ac61-da46ab5756e3"), 35, "Rory", "c:/blabla/nic/bla/RorySabatini", "Sabatini", "wikiurlRS" },
                    { new Guid("9033b72b-6340-4667-8a14-b6aed51697b6"), 42, "Paul", "c:/blabla/nic/bla/PaulGasol", "Gasol", "wikiurlPG" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: new Guid("5aae9cc3-b880-441c-b88e-ca00242db99f"));

            migrationBuilder.DeleteData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: new Guid("7793e739-6940-4c51-9f37-340be6e613a9"));

            migrationBuilder.DeleteData(
                table: "Directors",
                keyColumn: "Id",
                keyValue: new Guid("011a72e9-827c-48e4-ac61-da46ab5756e3"));

            migrationBuilder.DeleteData(
                table: "Directors",
                keyColumn: "Id",
                keyValue: new Guid("9033b72b-6340-4667-8a14-b6aed51697b6"));
        }
    }
}
