using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Country.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false, defaultValueSql: "NULL"),
                    Iso3 = table.Column<string>(type: "character varying(3)", maxLength: 3, nullable: true, defaultValueSql: "NULL"),
                    Iso2 = table.Column<string>(type: "character varying(2)", maxLength: 2, nullable: true, defaultValueSql: "NULL"),
                    NumericCode = table.Column<string>(type: "character varying(3)", maxLength: 3, nullable: true, defaultValueSql: "NULL"),
                    PhoneCode = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true, defaultValueSql: "NULL"),
                    Capital = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true, defaultValueSql: "NULL"),
                    Currency = table.Column<string>(type: "character varying(2500)", maxLength: 2500, nullable: true, defaultValueSql: "NULL"),
                    CurrencyName = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true, defaultValueSql: "NULL"),
                    CurrencySymbol = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true, defaultValueSql: "NULL"),
                    Tld = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true, defaultValueSql: "NULL"),
                    Native = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true, defaultValueSql: "NULL"),
                    Region = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true, defaultValueSql: "NULL"),
                    SubRegion = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true, defaultValueSql: "NULL"),
                    Latitude = table.Column<string>(type: "character varying(25)", maxLength: 25, nullable: true, defaultValueSql: "NULL"),
                    Longitude = table.Column<string>(type: "character varying(25)", maxLength: 25, nullable: true, defaultValueSql: "NULL"),
                    Emoji = table.Column<string>(type: "character varying(191)", maxLength: 191, nullable: true, defaultValueSql: "NULL"),
                    EmojiU = table.Column<string>(type: "character varying(191)", maxLength: 191, nullable: true, defaultValueSql: "NULL")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Languages",
                columns: table => new
                {
                    Id = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false, defaultValueSql: "NULL"),
                    Description = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false, defaultValueSql: "NULL")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Languages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "States",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CountryId = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false, defaultValueSql: "NULL"),
                    CountryCode = table.Column<string>(type: "character varying(2)", maxLength: 2, nullable: false, defaultValueSql: "NULL"),
                    CountryName = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false, defaultValueSql: "NULL"),
                    StateCode = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false, defaultValueSql: "NULL"),
                    Type = table.Column<string>(type: "character varying(191)", maxLength: 191, nullable: true, defaultValueSql: "NULL"),
                    Latitude = table.Column<string>(type: "character varying(25)", maxLength: 25, nullable: true, defaultValueSql: "NULL"),
                    Longitude = table.Column<string>(type: "character varying(25)", maxLength: 25, nullable: true, defaultValueSql: "NULL")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_States", x => x.Id);
                    table.ForeignKey(
                        name: "FK_States_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Timezones",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CountryId = table.Column<int>(type: "integer", nullable: false),
                    ZoneName = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false, defaultValueSql: "NULL"),
                    GmtOffset = table.Column<int>(type: "integer", nullable: true),
                    GmtOffsetName = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false, defaultValueSql: "NULL"),
                    Abbreviation = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false, defaultValueSql: "NULL"),
                    TzName = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false, defaultValueSql: "NULL")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Timezones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Timezones_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Translations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    LanguageId = table.Column<string>(type: "character varying(10)", nullable: false, defaultValueSql: "NULL"),
                    CountryId = table.Column<int>(type: "integer", nullable: false),
                    Description = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false, defaultValueSql: "NULL")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Translations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Translations_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Translations_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false, defaultValueSql: "NULL"),
                    StateId = table.Column<int>(type: "integer", nullable: false),
                    StateCode = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false, defaultValueSql: "NULL"),
                    StateName = table.Column<string>(type: "text", nullable: false, defaultValueSql: "NULL"),
                    CountryId = table.Column<int>(type: "integer", nullable: false),
                    CountryCode = table.Column<string>(type: "character varying(2)", maxLength: 2, nullable: false, defaultValueSql: "NULL"),
                    CountryName = table.Column<string>(type: "text", nullable: false, defaultValueSql: "NULL"),
                    Latitude = table.Column<string>(type: "character varying(25)", maxLength: 25, nullable: true, defaultValueSql: "NULL"),
                    Longitude = table.Column<string>(type: "character varying(25)", maxLength: 25, nullable: true, defaultValueSql: "NULL"),
                    WikiDataId = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true, defaultValueSql: "NULL")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cities_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Cities_States_StateId",
                        column: x => x.StateId,
                        principalTable: "States",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "Description" },
                values: new object[,]
                {
                    { "cn", "Chinese (S)" },
                    { "de", "German" },
                    { "es", "Spanish" },
                    { "fa", "Farsi" },
                    { "fr", "French" },
                    { "hr", "Croatian" },
                    { "it", "Italian" },
                    { "ja", "Japanese" },
                    { "kr", "Korean" },
                    { "nl", "Dutch" },
                    { "pt", "Portuguese (Portugal)" },
                    { "pt-BR", "Portuguese (Brazil)" },
                    { "tr", "Turkish" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cities_CountryId_StateId_Name",
                table: "Cities",
                columns: new[] { "CountryId", "StateId", "Name" });

            migrationBuilder.CreateIndex(
                name: "IX_Cities_StateId",
                table: "Cities",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_Languages_Id_Description",
                table: "Languages",
                columns: new[] { "Id", "Description" });

            migrationBuilder.CreateIndex(
                name: "IX_States_CountryId_Name",
                table: "States",
                columns: new[] { "CountryId", "Name" });

            migrationBuilder.CreateIndex(
                name: "IX_Timezones_CountryId",
                table: "Timezones",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Translations_CountryId",
                table: "Translations",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Translations_LanguageId_CountryId",
                table: "Translations",
                columns: new[] { "LanguageId", "CountryId" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "Timezones");

            migrationBuilder.DropTable(
                name: "Translations");

            migrationBuilder.DropTable(
                name: "States");

            migrationBuilder.DropTable(
                name: "Languages");

            migrationBuilder.DropTable(
                name: "Countries");
        }
    }
}
