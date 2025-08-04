using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infraestruture.Migrations
{
    /// <inheritdoc />
    public partial class Cliente_AdicionarCpf : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Cpf",
                table: "Cliente",
                type: "VARCHAR(11)",
                nullable: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cpf",
                table: "Cliente");
        }
    }
}
