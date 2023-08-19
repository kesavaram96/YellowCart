using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using YellowCart.Models;

namespace YellowCart.Data
{
 
        public class ApplicationDbContext : DbContext
        {
            public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

            public DbSet<Product> Products { get; set; }
            public DbSet<Category> Category { get; set; }
            public DbSet<Users> Users { get; set; }
            public DbSet<Cart> Cart { get; set; }
            public DbSet<Orders> Orders { get; set; }
            public DbSet<ReviewRatings> ReviewRatings { get; set; }
            public DbSet<ShippingAddress> ShippingAddresses { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Users>()
                .HasIndex(u => u.Email)
                .IsUnique(true);

            builder.Entity<Category>().HasData(
                new Category { Id=1,Name= "Gaming accessories", SubCategoryName="Mouse"},
                new Category { Id = 2, Name = "Gaming accessories", SubCategoryName = "Keyboard" },
                new Category { Id = 3, Name = "Gaming accessories", SubCategoryName = "Play Station" },
                new Category { Id = 4, Name = "Gaming accessories", SubCategoryName = "PC And Laptops" },
                new Category { Id = 5, Name = "Gaming accessories", SubCategoryName = "Headphones" },
                new Category { Id = 6, Name = "Electronics", SubCategoryName = "TV & Audio" },
                new Category { Id = 7, Name = "Electronics", SubCategoryName = "Mobile Phones" },
                new Category { Id = 8, Name = "Electronics", SubCategoryName = "Fan & Coolers" },
                new Category { Id = 9, Name = "Electronics", SubCategoryName = "Heaters" },
                new Category { Id = 10, Name = "Men's Fashion", SubCategoryName = "Mens Shirts" },
                new Category { Id = 11, Name = "Men's Fashion", SubCategoryName = "Mens Jeans" },
                new Category { Id = 12, Name = "Men's Fashion", SubCategoryName = "Watches" },
                new Category { Id = 13, Name = "Women's Fashion", SubCategoryName = "Women's Shirts" },
                new Category { Id = 14, Name = "Women's Fashion", SubCategoryName = "Women's Jeans" },
                new Category { Id = 15, Name = "Women's Fashion", SubCategoryName = "Shalwars" },
                new Category { Id = 16, Name = "Accessories", SubCategoryName = "Others" }
                );

            builder.Entity<Product>().HasData(
                new Product{Id=1,ProductName= "Gaming Headset with Mic - Compatible with PS5", Price=4500,CategoryId=5,Quantity=3,Description= "This gaming headset comes with a bendable cardioid noise-canceling microphone. The closed ear cup design effectively reduces background noise interference, allowing you to communicate seamlessly with your teammates without interruption.", Image= "/images/GamingHeadset.jpg" },
                new Product { Id = 2, ProductName = "Wired Gaming Mouse", Price =1200 , CategoryId =1 , Quantity = 56, Description = "59G ULTRA-LIGHTWEIGHT DESIGN — Enjoy a level of speed and control favored by the world’s top players with one of the lightest ergonomic esports mice ever created", Image = "/images/Mouse.jfif" },
                new Product { Id = 3, ProductName = "Redragon M612 Predator RGB Gaming Mouse", Price = 2500, CategoryId = 1, Quantity = 30, Description = "Pentakill, 5 DPI Levels - Geared with 5 redefinable DPI levels (default as: 500/1000/2000/3000/4000), easy to switch between different game needs. Dedicated demand of DPI options between 500-8000 is also available to be processed by software.", Image = "/images/mouse2.jpg" },

                new Product { Id = 4, ProductName = "Sony PlayStation ", Price = 250000, CategoryId = 3, Quantity = 12, Description = "Ready to play as USB AC adaptor is included that supports 5 V, 1.0A USB output", Image = "/images/playstation.jfif" },
                new Product { Id =5 , ProductName = "SlimTech Laptop Case Fits Dell Chromebook", Price =450000 , CategoryId = 4, Quantity = 35, Description = "COMPATIBILITY - This hard shell laptop case is custom-made only to fit Dell Chromebook 3110/3100 11-inch (2-in-1). Incompatible with other device models. Please don't hesitate to reach out if you need further assistance.", Image = "/images/chrome.jfif" },
                new Product { Id = 6, ProductName = "Gaming Keyboard", Price =3000 , CategoryId =2 , Quantity =100 , Description = "ROX Gaming keyboard with LEDs", Image = "/images/keyboard.jpg" },

                new Product { Id = 7, ProductName = "INSIGNIA 32-inch Class F20 Series Smart HD 720p Fire TV", Price = 75000, CategoryId = 6, Quantity = 12, Description = "Products with electrical plugs are designed for use in the US. Outlets and voltage differ internationally and this product may require an adapter or converter for use in your destination. Please check compatibility before purchasing.", Image = "/images/insignia.jpg" },
                new Product { Id =8 , ProductName = "WiiM Mini AirPlay2 Wireless Audio Streamer, Multiroom Stereo, Preamplifier", Price = 25000, CategoryId = 6, Quantity = 200, Description = "WORKS WITH ALEXA & SIRI - WiiM Mini works with Alexa and Siri Voice Assistants. Use your voice to control music playback and smart home automation.", Image = "/images/51797CctBoL._AC_SX679_.jpg" },
                new Product { Id = 9, ProductName = "Car Radio with Bluetooth, Car Audio Receiver", Price = 4500, CategoryId = 6, Quantity = 78, Description = "Products with electrical plugs are designed for use in the US. Outlets and voltage differ internationally and this product may require an adapter or converter for use in your destination. Please check compatibility before purchasing.", Image = "/images/61i2nXFwvXL._AC_SX679_.jpg" },

                new Product { Id = 10, ProductName = "CUBOT Note 8 Smartphone Without Contract, 4G Android 11 Mobile Phone", Price = 80000, CategoryId = 7, Quantity = 300, Description = "4G Android 11 Mobile Phone, 5.5 Inch HD Display, 13MP + 5MP Camera, 3100mAh Battery, 2GB/16GB, 128GB Expandable, Dual SIM Black", Image = "/images/71D08-YlM2L._AC_SX679_.jpg" },
                new Product { Id = 11, ProductName = "UMIDIGI Unlocked Cell Phone", Price = 70000, CategoryId = 7, Quantity = 300, Description = "Power 5 (3+64g) Android 11 Smart Phone, 6150mAh Battery+ 6.53\" HD Display Smartphone with 16MP AI Triple Camera, Dual SIM Android Phone", Image = "/images/71IvlUbzpqL._AC_SX679_.jpg" },
                new Product { Id = 12, ProductName = "SAMSUNG Galaxy A54 5G A Series Cell Phone", Price = 90000, CategoryId = 7, Quantity =480 , Description = "Factory Unlocked Android Smartphone, 128GB w/ 6.4” Fluid Display Screen, Hi Res Camera, Long Battery Life, Refined Design, US Version, 2023, Awesome Black", Image = "/images/61MEp5HIdBL._AC_SX679_.jpg" },

                new Product { Id = 13, ProductName = "Hanes Men’s Short Sleeve Graphic T-shirt Collection", Price = 1200, CategoryId = 10, Quantity = 950, Description = "SOFT & LIGHTWEIGHT - Super-soft and lightweight fabric feels great up against your skin.\r\nSHORT-SLEEVES - Sporty short-sleeve design keeps you feeling cool and comfortable.", Image = "/images/81vCTr9UaEL._AC_UX679_.jpg" },
                new Product { Id = 14, ProductName = "COOFANDY Men's Casual Linen Button Down Shirt Short Sleeve Beach Shirt", Price = 750, CategoryId = 10, Quantity = 30, Description = "HIGH-QUALITY MATERIAL --- Button down shirt lightweight, soft and comfortable, casual, skin-friendly, relaxed fit, perfectly suitable for all seasons.", Image = "/images/81oTmSS7J3L._AC_UX569_.jpg" },
                new Product { Id = 15, ProductName = "Adibosy Women Summer Casual Shirts: Short Sleeve Striped Tunic Tops - Womens Crew Neck Tee Tshirt Blouses", Price =850 , CategoryId = 13, Quantity = 1000, Description = "Material: Womens Tops and Blouses is Made of Rayon/Polyester/Spandex. The Women Summer Casual Shirt Feels Very Soft and Comfortable. It Is a Breathable but Opaque Womens Short Sleeve T Shirts.\r\nFeature: This Summer Casual Short Sleeve Shirt designs with Leopard Print, Color Blocks, Round Neck Combined with Stylish Short Sleeve Design, Women Crew Neck Color Block, Reflects the Elegance of Women.", Image = "/images/7104Xrswi+L._AC_UY741_.jpg" }

                //new Product { Id = 16, ProductName = "", Price = , CategoryId = , Quantity = , Description = "", Image = "" },
                //new Product { Id = 17, ProductName = "", Price = , CategoryId = , Quantity = , Description = "", Image = "" },
                //new Product { Id = 18, ProductName = "", Price = , CategoryId = , Quantity = , Description = "", Image = "" },

                //new Product { Id = 19, ProductName = "", Price = , CategoryId = , Quantity = , Description = "", Image = "" },
                //new Product { Id = 20, ProductName = "", Price = , CategoryId = , Quantity = , Description = "", Image = "" },
                //new Product { Id = 21, ProductName = "", Price = , CategoryId = , Quantity = , Description = "", Image = "" },

                //new Product { Id = 22, ProductName = "", Price = , CategoryId = , Quantity = , Description = "", Image = "" },
                //new Product { Id = 23, ProductName = "", Price = , CategoryId = , Quantity = , Description = "", Image = "" },
                //new Product { Id = 24, ProductName = "", Price = , CategoryId = , Quantity = , Description = "", Image = "" },


                );

        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Category>().HasData(
        //        new Category { Id = 1, Name = "FootWear", },
        //        new Category { Id = 2, Name = "Clothes", },
        //        new Category { Id = 3, Name = "Horror", }
        //        );
        //}

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Category>().HasData(
        //        new Category { Id = 1, Name = "Action", DisplayOrder = 1 },
        //        new Category { Id = 2, Name = "Sci fi", DisplayOrder = 2 },
        //        new Category { Id = 3, Name = "Horror", DisplayOrder = 3 }
        //        );
        //}
    }
}



