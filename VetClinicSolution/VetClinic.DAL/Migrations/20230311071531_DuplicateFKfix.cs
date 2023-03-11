using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VetClinic.DAL.Migrations
{
    /// <inheritdoc />
    public partial class DuplicateFKfix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VetPassports_PetOwners_PetOwnerId",
                table: "VetPassports");

            migrationBuilder.DropIndex(
                name: "IX_VetPassports_PetOwnerId",
                table: "VetPassports");

            migrationBuilder.DropColumn(
                name: "PetOwnerId",
                table: "VetPassports");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "PetOwnerId",
                table: "VetPassports",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_VetPassports_PetOwnerId",
                table: "VetPassports",
                column: "PetOwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_VetPassports_PetOwners_PetOwnerId",
                table: "VetPassports",
                column: "PetOwnerId",
                principalTable: "PetOwners",
                principalColumn: "PetOwnerId");
        }
    }
}
