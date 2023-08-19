using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YellowCart.Migrations
{
    public partial class imagesBulkUpload : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Users",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "Name", "SubCategoryName" },
                values: new object[,]
                {
                    { 1L, "Gaming accessories", "Mouse" },
                    { 2L, "Gaming accessories", "Keyboard" },
                    { 3L, "Gaming accessories", "Play Station" },
                    { 4L, "Gaming accessories", "PC And Laptops" },
                    { 5L, "Gaming accessories", "Headphones" },
                    { 6L, "Electronics", "TV & Audio" },
                    { 7L, "Electronics", "Mobile Phones" },
                    { 8L, "Electronics", "Fan & Coolers" },
                    { 9L, "Electronics", "Heaters" },
                    { 10L, "Men's Fashion", "Mens Shirts" },
                    { 11L, "Men's Fashion", "Mens Jeans" },
                    { 12L, "Men's Fashion", "Watches" },
                    { 13L, "Women's Fashion", "Women's Shirts" },
                    { 14L, "Women's Fashion", "Women's Jeans" },
                    { 15L, "Women's Fashion", "Shalwars" },
                    { 16L, "Accessories", "Others" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "Image", "Price", "ProductName", "Quantity" },
                values: new object[,]
                {
                    { 1, 5L, "This gaming headset comes with a bendable cardioid noise-canceling microphone. The closed ear cup design effectively reduces background noise interference, allowing you to communicate seamlessly with your teammates without interruption.", "/images/GamingHeadset.jpg", 4500, "Gaming Headset with Mic - Compatible with PS5", 3 },
                    { 2, 1L, "59G ULTRA-LIGHTWEIGHT DESIGN — Enjoy a level of speed and control favored by the world’s top players with one of the lightest ergonomic esports mice ever created", "/images/Mouse.jfif", 1200, "Wired Gaming Mouse", 56 },
                    { 3, 1L, "Pentakill, 5 DPI Levels - Geared with 5 redefinable DPI levels (default as: 500/1000/2000/3000/4000), easy to switch between different game needs. Dedicated demand of DPI options between 500-8000 is also available to be processed by software.", "/images/mouse2.jpg", 2500, "Redragon M612 Predator RGB Gaming Mouse", 30 },
                    { 4, 3L, "Ready to play as USB AC adaptor is included that supports 5 V, 1.0A USB output", "/images/playstation.jfif", 250000, "Sony PlayStation ", 12 },
                    { 5, 4L, "COMPATIBILITY - This hard shell laptop case is custom-made only to fit Dell Chromebook 3110/3100 11-inch (2-in-1). Incompatible with other device models. Please don't hesitate to reach out if you need further assistance.", "/images/chrome.jfif", 450000, "SlimTech Laptop Case Fits Dell Chromebook", 35 },
                    { 6, 2L, "ROX Gaming keyboard with LEDs", "/images/keyboard.jpg", 3000, "Gaming Keyboard", 100 },
                    { 7, 6L, "Products with electrical plugs are designed for use in the US. Outlets and voltage differ internationally and this product may require an adapter or converter for use in your destination. Please check compatibility before purchasing.", "/images/insignia.jpg", 75000, "INSIGNIA 32-inch Class F20 Series Smart HD 720p Fire TV", 12 },
                    { 8, 6L, "WORKS WITH ALEXA & SIRI - WiiM Mini works with Alexa and Siri Voice Assistants. Use your voice to control music playback and smart home automation.", "/images/51797CctBoL._AC_SX679_.jpg", 25000, "WiiM Mini AirPlay2 Wireless Audio Streamer, Multiroom Stereo, Preamplifier", 200 },
                    { 9, 6L, "Products with electrical plugs are designed for use in the US. Outlets and voltage differ internationally and this product may require an adapter or converter for use in your destination. Please check compatibility before purchasing.", "/images/61i2nXFwvXL._AC_SX679_.jpg", 4500, "Car Radio with Bluetooth, Car Audio Receiver", 78 },
                    { 10, 7L, "4G Android 11 Mobile Phone, 5.5 Inch HD Display, 13MP + 5MP Camera, 3100mAh Battery, 2GB/16GB, 128GB Expandable, Dual SIM Black", "/images/71D08-YlM2L._AC_SX679_.jpg", 80000, "CUBOT Note 8 Smartphone Without Contract, 4G Android 11 Mobile Phone", 300 },
                    { 11, 7L, "Power 5 (3+64g) Android 11 Smart Phone, 6150mAh Battery+ 6.53\" HD Display Smartphone with 16MP AI Triple Camera, Dual SIM Android Phone", "/images/71IvlUbzpqL._AC_SX679_.jpg", 70000, "UMIDIGI Unlocked Cell Phone", 300 },
                    { 12, 7L, "Factory Unlocked Android Smartphone, 128GB w/ 6.4” Fluid Display Screen, Hi Res Camera, Long Battery Life, Refined Design, US Version, 2023, Awesome Black", "/images/61MEp5HIdBL._AC_SX679_.jpg", 90000, "SAMSUNG Galaxy A54 5G A Series Cell Phone", 480 },
                    { 13, 10L, "SOFT & LIGHTWEIGHT - Super-soft and lightweight fabric feels great up against your skin.\r\nSHORT-SLEEVES - Sporty short-sleeve design keeps you feeling cool and comfortable.", "/images/81vCTr9UaEL._AC_UX679_.jpg", 1200, "Hanes Men’s Short Sleeve Graphic T-shirt Collection", 950 },
                    { 14, 10L, "HIGH-QUALITY MATERIAL --- Button down shirt lightweight, soft and comfortable, casual, skin-friendly, relaxed fit, perfectly suitable for all seasons.", "/images/81oTmSS7J3L._AC_UX569_.jpg", 750, "COOFANDY Men's Casual Linen Button Down Shirt Short Sleeve Beach Shirt", 30 },
                    { 15, 13L, "Material: Womens Tops and Blouses is Made of Rayon/Polyester/Spandex. The Women Summer Casual Shirt Feels Very Soft and Comfortable. It Is a Breathable but Opaque Womens Short Sleeve T Shirts.\r\nFeature: This Summer Casual Short Sleeve Shirt designs with Leopard Print, Color Blocks, Round Neck Combined with Stylish Short Sleeve Design, Women Crew Neck Color Block, Reflects the Elegance of Women.", "/images/7104Xrswi+L._AC_UY741_.jpg", 850, "Adibosy Women Summer Casual Shirts: Short Sleeve Striped Tunic Tops - Womens Crew Neck Tee Tshirt Blouses", 1000 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Users_Email",
                table: "Users");

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 8L);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 9L);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 11L);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 12L);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 14L);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 15L);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 16L);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 6L);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 7L);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 10L);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 13L);

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }
    }
}
