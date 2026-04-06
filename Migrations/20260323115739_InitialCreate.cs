using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace copaHAS.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_JOGADORES",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumeroCamisa = table.Column<int>(type: "int", nullable: false),
                    Posicao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SelecaoId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_JOGADORES", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "TB_JOGADORES",
                columns: new[] { "Id", "Nome", "NumeroCamisa", "Posicao", "SelecaoId", "Status" },
                values: new object[,]
                {
                    { 1, "Tevez", 10, "Meio-Campo", 0, 1 },
                    { 2, "Cassio", 12, "Goleiro", 0, 1 },
                    { 3, "Ronaldo", 9, "Atacante", 0, 1 },
                    { 4, "Fagner", 23, "Lateral Direito", 0, 1 },
                    { 5, "Gil", 4, "Zagueiro", 0, 1 },
                    { 6, "Renato Augusto", 8, "Meio-Campo", 0, 1 },
                    { 7, "Paulinho", 15, "Meio-Campo", 0, 1 },
                    { 8, "Yuri Alberto", 9, "Atacante", 0, 1 },
                    { 9, "Roger Guedes", 10, "Atacante", 0, 1 },
                    { 10, "Fabio Santos", 6, "Lateral Esquerdo", 0, 1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_JOGADORES");
        }
    }
}
