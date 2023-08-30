using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PokemonEH.Migrations
{
    /// <inheritdoc />
    public partial class AddPokemonDetails : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BaseExperience",
                table: "Pokemon",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Height",
                table: "Pokemon",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Weight",
                table: "Pokemon",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BaseExperience",
                table: "Pokemon");

            migrationBuilder.DropColumn(
                name: "Height",
                table: "Pokemon");

            migrationBuilder.DropColumn(
                name: "Weight",
                table: "Pokemon");
        }
    }
}
