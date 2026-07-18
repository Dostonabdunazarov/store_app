using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hypex.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddProductOldPrice : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "OldPrice",
                table: "products",
                type: "numeric(12,2)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OldPrice",
                table: "products");
        }
    }
}
