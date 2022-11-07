using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AnimesProtech.Infra.Migrations
{
    public partial class CreateTableBaseAndAnime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "anime",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    nome = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    resumo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    diretor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    criado_em = table.Column<DateTime>(type: "datetime2", nullable: false),
                    alterado_em = table.Column<DateTime>(type: "datetime2", nullable: true),
                    data_inativacao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ativo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_anime", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_anime_nome",
                table: "anime",
                column: "nome",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "anime");
        }
    }
}
