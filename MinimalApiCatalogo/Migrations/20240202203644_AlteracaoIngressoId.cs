using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MinimalApiCatalogo.Migrations
{
    public partial class AlteracaoIngressoId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProdutoId",
                table: "Ingresso",
                newName: "IngressoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IngressoId",
                table: "Ingresso",
                newName: "ProdutoId");
        }
    }
}
