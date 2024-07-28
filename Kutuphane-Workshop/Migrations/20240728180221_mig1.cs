using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Kutuphane_Workshop.Migrations
{
    /// <inheritdoc />
    public partial class mig1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Musteri",
                table: "Musteri");

            migrationBuilder.RenameTable(
                name: "Musteri",
                newName: "Musteriler");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Musteriler",
                table: "Musteriler",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "KitapMusteriler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MusteriId = table.Column<int>(type: "integer", nullable: false),
                    KitapId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KitapMusteriler", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KitapMusteriler_Kitaplar_KitapId",
                        column: x => x.KitapId,
                        principalTable: "Kitaplar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KitapMusteriler_Musteriler_MusteriId",
                        column: x => x.MusteriId,
                        principalTable: "Musteriler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_KitapMusteriler_KitapId",
                table: "KitapMusteriler",
                column: "KitapId");

            migrationBuilder.CreateIndex(
                name: "IX_KitapMusteriler_MusteriId",
                table: "KitapMusteriler",
                column: "MusteriId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KitapMusteriler");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Musteriler",
                table: "Musteriler");

            migrationBuilder.RenameTable(
                name: "Musteriler",
                newName: "Musteri");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Musteri",
                table: "Musteri",
                column: "Id");
        }
    }
}
