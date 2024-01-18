using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace KailahsCloset.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addingProductTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Brand = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Size = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "Brand", "Description", "Name", "Price", "Size" },
                values: new object[,]
                {
                    { 1, "Nike", "Black Nike zip-Up hoodie", "Nike Zip-Up Hoodie", 30.0, "Large" },
                    { 2, "Levi's", "Dark wash slim-fit jeans for all occasions", "Levi's Slim-Fit Jeans", 35.0, "32x32" },
                    { 3, "Uniqulo", "60% cotton / 40% polyester slim-fit grey tee.", "Uniqulo Grey Tee", 12.0, "Large" },
                    { 4, "ASColour", "65% cotton / 35% polyester slim-fit navy blue tee.", "ASColour Navy Blue Tee", 12.0, "Large" },
                    { 5, "Flag & Anthem", "60% cotton / 40% polyester dark grey chino pants.", "Flag & Anthem Oakland Slim Chinos", 38.0, "33x32" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
