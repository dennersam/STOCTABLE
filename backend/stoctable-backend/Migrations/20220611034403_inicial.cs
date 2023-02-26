using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace stoctable_backend.Migrations
{
    public partial class inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Produtos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Codigo = table.Column<int>(type: "integer", nullable: false),
                    Descricao = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: false),
                    Unidade = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Fornecedor = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Fabricante = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: false),
                    Setor = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    PrecoCusto = table.Column<decimal>(type: "numeric", nullable: false),
                    PrecoVenda = table.Column<decimal>(type: "numeric", nullable: false),
                    MargemLucro = table.Column<decimal>(type: "numeric", nullable: false),
                    CustoMedio = table.Column<decimal>(type: "numeric", nullable: false),
                    Quantidade = table.Column<int>(type: "integer", nullable: false),
                    QtMinima = table.Column<int>(type: "integer", nullable: false),
                    Observacao = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false),
                    AlicotaICMS = table.Column<decimal>(type: "numeric", nullable: false),
                    BaseCalcICMS = table.Column<decimal>(type: "numeric", nullable: false),
                    PesoBruto = table.Column<decimal>(type: "numeric", nullable: false),
                    PesoLiquido = table.Column<decimal>(type: "numeric", nullable: false),
                    CodigoInterno = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produtos", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Produtos");
        }
    }
}
