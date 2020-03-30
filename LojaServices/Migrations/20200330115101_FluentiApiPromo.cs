using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LojaServices.Migrations
{
    public partial class FluentiApiPromo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Promocao_Produto_Produto_Produto_Id",
                table: "Promocao_Produto");

            migrationBuilder.DropForeignKey(
                name: "FK_Promocao_Produto_Promocoes_Promocao_Id",
                table: "Promocao_Produto");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Promocao_Produto",
                table: "Promocao_Produto");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Promocao_Produto",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Promocao_Produto",
                table: "Promocao_Produto",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Promocao_Produto_Produto_Id",
                table: "Promocao_Produto",
                column: "Produto_Id");

            migrationBuilder.AddForeignKey(
                name: "FK__Produto_Promocao",
                table: "Promocao_Produto",
                column: "Produto_Id",
                principalTable: "Produto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK__Promocao_Produto",
                table: "Promocao_Produto",
                column: "Promocao_Id",
                principalTable: "Promocoes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__Produto_Promocao",
                table: "Promocao_Produto");

            migrationBuilder.DropForeignKey(
                name: "FK__Promocao_Produto",
                table: "Promocao_Produto");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Promocao_Produto",
                table: "Promocao_Produto");

            migrationBuilder.DropIndex(
                name: "IX_Promocao_Produto_Produto_Id",
                table: "Promocao_Produto");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Promocao_Produto");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Promocao_Produto",
                table: "Promocao_Produto",
                columns: new[] { "Produto_Id", "Promocao_Id" });

            migrationBuilder.AddForeignKey(
                name: "FK_Promocao_Produto_Produto_Produto_Id",
                table: "Promocao_Produto",
                column: "Produto_Id",
                principalTable: "Produto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Promocao_Produto_Promocoes_Promocao_Id",
                table: "Promocao_Produto",
                column: "Promocao_Id",
                principalTable: "Promocoes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
