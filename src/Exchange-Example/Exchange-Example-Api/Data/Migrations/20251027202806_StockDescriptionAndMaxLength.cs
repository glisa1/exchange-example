using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Exchange_Example_Api.Data.Migrations
{
    /// <inheritdoc />
    public partial class StockDescriptionAndMaxLength : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "stocks",
                type: "character varying(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "stocks");
        }
    }
}
