using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DigitalCatalog.Dal.Migrations
{
    /// <inheritdoc />
    public partial class AddedCourseCreditPoints : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CreditPoints",
                table: "Courses",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreditPoints",
                table: "Courses");
        }
    }
}
