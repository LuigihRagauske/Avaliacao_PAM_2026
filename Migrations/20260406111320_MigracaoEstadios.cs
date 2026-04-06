using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace copaHAS.Migrations
{
    /// <inheritdoc />
    public partial class MigracaoEstadios : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_TB_JOGADORES",
                table: "TB_JOGADORES");

            migrationBuilder.RenameTable(
                name: "TB_JOGADORES",
                newName: "TB_ESTADIOS");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TB_ESTADIOS",
                table: "TB_ESTADIOS",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Estadio",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cidade = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Capacidade = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estadio", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Estadio",
                columns: new[] { "Id", "Capacidade", "Cidade", "Nome" },
                values: new object[,]
                {
                    { 1, 46000, "São Paulo", "NeoQuímica Arena" },
                    { 2, 45000, "São Paulo", "Allianz Parque" },
                    { 3, 75000, "Rio de Janeiro", "Maracanã" },
                    { 4, 47000, "São Paulo", "Morumbi" },
                    { 5, 30000, "São Paulo", "Castelão" },
                    { 6, 20000, "São Paulo", "Brinco de Ouro" },
                    { 7, 50000, "São Paulo", "Camp Nou" },
                    { 8, 60000, "São Paulo", "Allianz Arena" },
                    { 9, 20000, "São Paulo", "Vila Belmiro" },
                    { 10, 20000, "São Paulo", "Arena Barueri" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Estadio");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TB_ESTADIOS",
                table: "TB_ESTADIOS");

            migrationBuilder.RenameTable(
                name: "TB_ESTADIOS",
                newName: "TB_JOGADORES");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TB_JOGADORES",
                table: "TB_JOGADORES",
                column: "Id");
        }
    }
}
