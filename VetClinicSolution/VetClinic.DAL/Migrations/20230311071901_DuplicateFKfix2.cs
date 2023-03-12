using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VetClinic.DAL.Migrations
{
    /// <inheritdoc />
    public partial class DuplicateFKfix2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "VetPassports");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<long>(
                name: "OwnerId",
                table: "VetPassports",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }
    }
}
