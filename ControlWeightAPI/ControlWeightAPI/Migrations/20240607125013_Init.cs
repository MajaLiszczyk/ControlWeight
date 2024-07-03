using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ControlWeightAPI.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Measures",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Weight = table.Column<double>(type: "float", nullable: false),
                    Waist = table.Column<double>(type: "float", nullable: false),
                    Hips = table.Column<double>(type: "float", nullable: false),
                    Thigh = table.Column<double>(type: "float", nullable: false),
                    Arm = table.Column<double>(type: "float", nullable: false),
                    Chest = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Measures", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Measures");
        }
    }
}
