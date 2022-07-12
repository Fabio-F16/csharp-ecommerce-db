using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace csharp_ecommerce_db.Migrations
{
    public partial class InitialCreatex2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_order_product_order_quantity_ProductOrderQuantityId",
                table: "order");

            migrationBuilder.DropForeignKey(
                name: "FK_product_product_order_quantity_ProductOrderQuantityId",
                table: "product");

            migrationBuilder.AlterColumn<int>(
                name: "ProductOrderQuantityId",
                table: "product",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ProductOrderQuantityId",
                table: "order",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_order_product_order_quantity_ProductOrderQuantityId",
                table: "order",
                column: "ProductOrderQuantityId",
                principalTable: "product_order_quantity",
                principalColumn: "ProductOrderQuantityId");

            migrationBuilder.AddForeignKey(
                name: "FK_product_product_order_quantity_ProductOrderQuantityId",
                table: "product",
                column: "ProductOrderQuantityId",
                principalTable: "product_order_quantity",
                principalColumn: "ProductOrderQuantityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_order_product_order_quantity_ProductOrderQuantityId",
                table: "order");

            migrationBuilder.DropForeignKey(
                name: "FK_product_product_order_quantity_ProductOrderQuantityId",
                table: "product");

            migrationBuilder.AlterColumn<int>(
                name: "ProductOrderQuantityId",
                table: "product",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ProductOrderQuantityId",
                table: "order",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_order_product_order_quantity_ProductOrderQuantityId",
                table: "order",
                column: "ProductOrderQuantityId",
                principalTable: "product_order_quantity",
                principalColumn: "ProductOrderQuantityId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_product_product_order_quantity_ProductOrderQuantityId",
                table: "product",
                column: "ProductOrderQuantityId",
                principalTable: "product_order_quantity",
                principalColumn: "ProductOrderQuantityId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
