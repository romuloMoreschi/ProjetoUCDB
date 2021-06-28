using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjetoUCDB.Infrastructure.Migrations
{
    public partial class Initials : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    Id = table.Column<long>(type: "BIGINT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome_produto = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    valor = table.Column<decimal>(type: "DECIMAL(9,2)", nullable: false, defaultValue: 0m),
                    desconto = table.Column<decimal>(type: "DECIMAL(9,2)", nullable: false, defaultValue: 0m),
                    data_vencimento = table.Column<DateTime>(type: "DATE", nullable: false),
                    situacao = table.Column<string>(type: "VARCHAR(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Order");
        }
    }
}
