using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MiniProject.API.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TMCustomer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TMCustomer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TMPromo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PromoName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Discount = table.Column<decimal>(type: "decimal(5,2)", precision: 5, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TMPromo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TTPromo",
                columns: table => new
                {
                    IdCustomer = table.Column<int>(type: "int", nullable: false),
                    IdPromo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TTPromo", x => new { x.IdCustomer, x.IdPromo });
                    table.ForeignKey(
                        name: "FK_TTPromo_TMCustomer_IdCustomer",
                        column: x => x.IdCustomer,
                        principalTable: "TMCustomer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TTPromo_TMPromo_IdPromo",
                        column: x => x.IdPromo,
                        principalTable: "TMPromo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TTPromo_IdPromo",
                table: "TTPromo",
                column: "IdPromo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TTPromo");

            migrationBuilder.DropTable(
                name: "TMCustomer");

            migrationBuilder.DropTable(
                name: "TMPromo");
        }
    }
}
