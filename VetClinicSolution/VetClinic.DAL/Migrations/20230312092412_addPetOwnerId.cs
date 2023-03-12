using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VetClinic.DAL.Migrations
{
    /// <inheritdoc />
    public partial class addPetOwnerId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VetPassports_PetOwners_PetOwnerId",
                table: "VetPassports");

            migrationBuilder.AlterColumn<long>(
                name: "PetOwnerId",
                table: "VetPassports",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_VetPassports_PetOwners_PetOwnerId",
                table: "VetPassports",
                column: "PetOwnerId",
                principalTable: "PetOwners",
                principalColumn: "PetOwnerId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VetPassports_PetOwners_PetOwnerId",
                table: "VetPassports");

            migrationBuilder.AlterColumn<long>(
                name: "PetOwnerId",
                table: "VetPassports",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddForeignKey(
                name: "FK_VetPassports_PetOwners_PetOwnerId",
                table: "VetPassports",
                column: "PetOwnerId",
                principalTable: "PetOwners",
                principalColumn: "PetOwnerId");
        }
    }
}
