using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class NewTablesAddedCEOCountryBrandCityCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "date",
                table: "Activities",
                newName: "Date");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Activities",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "Activities",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "Activities",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Activities",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Notes",
                table: "Activities",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Notes = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    CategoryId = table.Column<Guid>(nullable: false),
                    DateOfOrigin = table.Column<DateTime>(nullable: false),
                    CountryId = table.Column<Guid>(nullable: false),
                    CityId = table.Column<Guid>(nullable: false),
                    Venue = table.Column<string>(nullable: true),
                    TelephoneNumber = table.Column<string>(nullable: true),
                    CEOId = table.Column<Guid>(nullable: false),
                    OurClientSince = table.Column<DateTime>(nullable: false),
                    NumberOfEmployees = table.Column<int>(nullable: false),
                    PriceOfBrand = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Notes = table.Column<string>(nullable: true),
                    KingOfCategory = table.Column<string>(nullable: true),
                    LeadingBrand = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CEOs",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Notes = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    CountryId = table.Column<Guid>(nullable: false),
                    Experience = table.Column<string>(nullable: true),
                    Age = table.Column<int>(nullable: false),
                    Gender = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CEOs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Notes = table.Column<string>(nullable: true),
                    Population = table.Column<int>(nullable: false),
                    Language = table.Column<string>(nullable: true),
                    Religion = table.Column<string>(nullable: true),
                    Currency = table.Column<string>(nullable: true),
                    Continent = table.Column<string>(nullable: true),
                    Region = table.Column<string>(nullable: true),
                    CountryId = table.Column<Guid>(nullable: false),
                    IsAlsoCountry = table.Column<bool>(nullable: false),
                    IsCapital = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Notes = table.Column<string>(nullable: true),
                    Population = table.Column<int>(nullable: false),
                    Language = table.Column<string>(nullable: true),
                    Religion = table.Column<string>(nullable: true),
                    Currency = table.Column<string>(nullable: true),
                    Continent = table.Column<string>(nullable: true),
                    Region = table.Column<string>(nullable: true),
                    IsPartOfEU = table.Column<bool>(nullable: false),
                    CapitalId = table.Column<Guid>(nullable: false),
                    TelephoneCode = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Brands");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "CEOs");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "Notes",
                table: "Activities");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Activities",
                newName: "date");
        }
    }
}
