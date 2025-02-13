using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ElPalacio.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddNewColumnToEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Category_Product_ProductFK",
                table: "Category");

            migrationBuilder.DropIndex(
                name: "IX_Category_ProductFK",
                table: "Category");

            migrationBuilder.DropColumn(
                name: "ProductFK",
                table: "Category");

            migrationBuilder.AddColumn<int>(
                name: "CategoryFK",
                table: "Product",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Product_CategoryFK",
                table: "Product",
                column: "CategoryFK");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Category_CategoryFK",
                table: "Product",
                column: "CategoryFK",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_Category_CategoryFK",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Product_CategoryFK",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "CategoryFK",
                table: "Product");

            migrationBuilder.AddColumn<int>(
                name: "ProductFK",
                table: "Category",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Category_ProductFK",
                table: "Category",
                column: "ProductFK");

            migrationBuilder.AddForeignKey(
                name: "FK_Category_Product_ProductFK",
                table: "Category",
                column: "ProductFK",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
