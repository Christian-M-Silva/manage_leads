using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Manage_lead.Migrations
{
    /// <inheritdoc />
    public partial class PriceDiscount : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "PriceDiscount",
                table: "Leads",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PriceDiscount",
                table: "Leads");
        }
    }
}
