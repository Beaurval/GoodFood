using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace goodfood_products.Migrations
{
    public partial class Add_restaurant_id : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RestaurantId",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RestaurantId",
                table: "Products");
        }
    }
}
