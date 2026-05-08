using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestaoProdutosOracle.Migrations
{
    /// <inheritdoc />
    public partial class Inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DEPARTAMENTOS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Nome = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DEPARTAMENTOS", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PRODUTOS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Nome = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Preco = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: false),
                    DepartamentoId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRODUTOS", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PRODUTOS_DEPARTAMENTOS_DepartamentoId",
                        column: x => x.DepartamentoId,
                        principalTable: "DEPARTAMENTOS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PRODUTOS_DepartamentoId",
                table: "PRODUTOS",
                column: "DepartamentoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PRODUTOS");

            migrationBuilder.DropTable(
                name: "DEPARTAMENTOS");
        }
    }
}
