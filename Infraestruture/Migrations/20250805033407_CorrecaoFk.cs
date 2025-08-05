using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infraestruture.Migrations
{
    /// <inheritdoc />
    public partial class CorrecaoFk : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pedido_Cliente_Id",
                table: "Pedido");

            migrationBuilder.DropForeignKey(
                name: "FK_Pedido_Livro_Id",
                table: "Pedido");

            migrationBuilder.CreateIndex(
                name: "IX_Pedido_ClientId",
                table: "Pedido",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Pedido_LivroId",
                table: "Pedido",
                column: "LivroId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pedido_Cliente_ClientId",
                table: "Pedido",
                column: "ClientId",
                principalTable: "Cliente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pedido_Livro_LivroId",
                table: "Pedido",
                column: "LivroId",
                principalTable: "Livro",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pedido_Cliente_ClientId",
                table: "Pedido");

            migrationBuilder.DropForeignKey(
                name: "FK_Pedido_Livro_LivroId",
                table: "Pedido");

            migrationBuilder.DropIndex(
                name: "IX_Pedido_ClientId",
                table: "Pedido");

            migrationBuilder.DropIndex(
                name: "IX_Pedido_LivroId",
                table: "Pedido");

            migrationBuilder.AddForeignKey(
                name: "FK_Pedido_Cliente_Id",
                table: "Pedido",
                column: "Id",
                principalTable: "Cliente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pedido_Livro_Id",
                table: "Pedido",
                column: "Id",
                principalTable: "Livro",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
