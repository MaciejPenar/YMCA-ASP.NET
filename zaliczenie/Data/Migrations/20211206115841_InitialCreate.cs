using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace zaliczenie.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Dane",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    plec = table.Column<bool>(type: "bit", nullable: false),
                    pas = table.Column<double>(type: "float", nullable: false),
                    masa = table.Column<double>(type: "float", nullable: false),
                    data = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dane", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Dane");
        }
    }
}
