using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace VetClinic.DAL.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GenderVariant",
                columns: table => new
                {
                    GenderVariantId = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GenderVariant", x => x.GenderVariantId);
                });

            migrationBuilder.CreateTable(
                name: "PetOwners",
                columns: table => new
                {
                    PetOwnerId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    City = table.Column<string>(type: "text", nullable: false),
                    Street = table.Column<string>(type: "text", nullable: false),
                    House = table.Column<string>(type: "text", nullable: false),
                    Building = table.Column<string>(type: "text", nullable: true),
                    Flat = table.Column<string>(type: "text", nullable: false),
                    Phone = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PetOwners", x => x.PetOwnerId);
                });

            migrationBuilder.CreateTable(
                name: "VetPassports",
                columns: table => new
                {
                    VetPassportId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PetName = table.Column<string>(type: "text", nullable: false),
                    Breed = table.Column<string>(type: "text", nullable: false),
                    SpecialSigns = table.Column<string>(type: "text", nullable: false),
                    Birthday = table.Column<DateOnly>(type: "date", nullable: false),
                    MicrochipNumber = table.Column<long>(type: "bigint", nullable: false),
                    MicrochipDate = table.Column<DateOnly>(type: "date", nullable: false),
                    LocationOfMicrochip = table.Column<string>(type: "text", nullable: false),
                    GenderVariantId = table.Column<int>(type: "integer", nullable: false),
                    OwnerId = table.Column<long>(type: "bigint", nullable: false),
                    PetOwnerId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VetPassports", x => x.VetPassportId);
                    table.ForeignKey(
                        name: "FK_VetPassports_GenderVariant_GenderVariantId",
                        column: x => x.GenderVariantId,
                        principalTable: "GenderVariant",
                        principalColumn: "GenderVariantId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VetPassports_PetOwners_PetOwnerId",
                        column: x => x.PetOwnerId,
                        principalTable: "PetOwners",
                        principalColumn: "PetOwnerId");
                });

            migrationBuilder.InsertData(
                table: "GenderVariant",
                columns: new[] { "GenderVariantId", "Name" },
                values: new object[,]
                {
                    { 0, "Male" },
                    { 1, "Female" },
                    { 2, "Сastrato" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_VetPassports_GenderVariantId",
                table: "VetPassports",
                column: "GenderVariantId");

            migrationBuilder.CreateIndex(
                name: "IX_VetPassports_PetOwnerId",
                table: "VetPassports",
                column: "PetOwnerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VetPassports");

            migrationBuilder.DropTable(
                name: "GenderVariant");

            migrationBuilder.DropTable(
                name: "PetOwners");
        }
    }
}
