using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Electro.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class removeNullableFromDecimal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {


            // Trigger to update LastUpdated on the Product table
            migrationBuilder.Sql(@"
            CREATE TRIGGER UpdateProductLastUpdated
            ON Products
            AFTER UPDATE
            AS
            BEGIN
                UPDATE Product
                SET LastUpdated = GETDATE()
                WHERE Id IN (SELECT Id FROM inserted);
            END;
        ");

            // Trigger to update LastUpdated on the Cart table
            migrationBuilder.Sql(@"
            CREATE TRIGGER UpdateCartLastUpdated
            ON Carts
            AFTER UPDATE
            AS
            BEGIN
                UPDATE Cart
                SET LastUpdated = GETDATE()
                WHERE Id IN (SELECT Id FROM inserted);
            END;
        ");

            // Trigger to update TotalAmount on the Cart table
            migrationBuilder.Sql(@"
            CREATE TRIGGER UpdateCartTotalAmount
            ON CartItems
            AFTER INSERT, UPDATE, DELETE
            AS
            BEGIN
                UPDATE Cart
                SET TotalAmount = (
                    SELECT SUM(ci.TotalPrice)
                    FROM CartItem ci
                    WHERE ci.CartId = inserted.CartId
                )
                WHERE Id IN (SELECT CartId FROM inserted);
            END;
        ");

            // Trigger to update TotalAmount on the Order table
            migrationBuilder.Sql(@"
            CREATE TRIGGER UpdateOrderTotalAmount
            ON OrderItems
            AFTER INSERT, UPDATE, DELETE
            AS
            BEGIN
                UPDATE [Order]
                SET TotalAmount = (
                    SELECT SUM(oi.TotalPrice)
                    FROM OrderItem oi
                    WHERE oi.OrderId = inserted.OrderId
                )
                WHERE Id IN (SELECT OrderId FROM inserted);
            END;
        ");

            migrationBuilder.AlterColumn<string>(
                name: "Weight",
                table: "Products",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "ShippingWeight",
                table: "Products",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "SKU",
                table: "Products",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Material",
                table: "Products",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "ImageURL",
                table: "Products",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Products",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "Hello",
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);

            migrationBuilder.AlterColumn<string>(
                name: "Color",
                table: "Products",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Brand",
                table: "Products",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);


        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Drop the triggers if rolling back the migration
            migrationBuilder.Sql("DROP TRIGGER IF EXISTS UpdateProductLastUpdated;");
            migrationBuilder.Sql("DROP TRIGGER IF EXISTS UpdateCartLastUpdated;");
            migrationBuilder.Sql("DROP TRIGGER IF EXISTS UpdateCartTotalAmount;");
            migrationBuilder.Sql("DROP TRIGGER IF EXISTS UpdateOrderTotalAmount;");

            migrationBuilder.AlterColumn<string>(
                name: "Weight",
                table: "Products",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ShippingWeight",
                table: "Products",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SKU",
                table: "Products",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Material",
                table: "Products",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ImageURL",
                table: "Products",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Products",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldDefaultValue: "Hello");

            migrationBuilder.AlterColumn<string>(
                name: "Color",
                table: "Products",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Brand",
                table: "Products",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);
        }
    }
}
