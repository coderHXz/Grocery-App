using GroceryHX.Data.Enums;
using GroceryHX.Models;
using Microsoft.AspNetCore.Builder;
using System.Collections.Generic;
using System;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using GroceryHX.Data.Static;

namespace GroceryHX.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

                context.Database.EnsureCreated();

                if (!context.Suppliers.Any())
                {
                    context.Suppliers.AddRange(new List<Supplier>()
                    {
                        new Supplier()
                        {
                            Name = "Delhivery",
                            Logo = "https://th.bing.com/th/id/OIP._JBq2bkNYja_ETDrPyIUfQHaE8?pid=ImgDet&rs=1",
                            Description = "One of the best suppliers for grocery product known for there fast service."
                        },
                        new Supplier()
                        {
                            Name = "IndiaMART",
                            Logo = "https://indian-retailer.s3.ap-south-1.amazonaws.com/s3fs-public/2019-10/final_indiamart.jpg",
                            Description = "We provide supply for grocery product in best way possible with care."
                        },
                        new Supplier()
                        {
                            Name = "Ekart",
                            Logo = "https://images.yourstory.com/cs/wordpress/2017/09/ekart-image.png?fm=png&auto=format&blur=500",
                            Description = "Safe and Secure Delivery"
                        },
                    });
                    context.SaveChanges();
                }
                //Actors
                if (!context.Countries.Any())
                {
                    context.Countries.AddRange(new List<Country>()
                    {
                        new Country()
                        {
                            Name = "India",
                            Description = "India has been bestowed with wide range of climate and physic-geographical conditions and as such is most suitable for growing various kinds of horticultural crops such as fruits, vegetables, flowers, nuts, spices and plantation crops.",
                            CountryImageUrl = "https://wri-india.org/sites/default/files/styles/large/public/How-Indian-Cities-Could-Become-Climate-Resilient-featured-image.jpg?itok=JXy5rvj7"

                        },
                        new Country()
                        {
                            Name = "Australia",
                            Description = "Australia is a major agricultural producer and exporter, with over 325,300 employed in agriculture, forestry and fishing",
                            CountryImageUrl = "https://www.holidayvacations.com/content/uploads/2018/07/wonders-of-australia-2.jpg"
                        },
                        new Country()
                        {
                            Name = "Canada",
                            Description = "Canada is famous for Oilseed and Apples.",
                            CountryImageUrl = "https://www.tripsavvy.com/thmb/No4T25ijkszr6NHX8RLpdp_thuI=/3865x2576/filters:fill(auto,1)/illuminated-chenghuang-pagoda-against-west-lake-hangzhou-china-849806970-5b0aecbba474be003707ba1d.jpg"
                        },
                    });
                    context.SaveChanges();
                }
                //Producers
                if (!context.Producers.Any())
                {
                    context.Producers.AddRange(new List<Producer>()
                    {
                        new Producer()
                        {
                            Name = "Farmers",
                            Details = "Farmers are the backbone of many countries and these small farmers help country in economy Boost.",
                            ProfilePictureURL = "https://th.bing.com/th/id/OIP.TIP2hfWkRfXXVQUs6ToDYwHaEK?w=333&h=187&c=7&r=0&o=5&dpr=1.5&pid=1.7"

                        },
                        new Producer()
                        {
                            Name = "Organization",
                            Details = "Organization Provides Products which are very carefully processed and have best quality.",
                            ProfilePictureURL = "https://th.bing.com/th/id/OIP.Ok01TtzEJsILK0HPEbL2IAHaFj?w=203&h=180&c=7&r=0&o=5&dpr=1.5&pid=1.7"
                        },
                        new Producer()
                        {
                            Name = "NGOs",
                            Details = "NGOs Help Poor peoples in best way possible for free or on discount.",
                            ProfilePictureURL = "https://www.ngogrocer.com/image/ngogrocer/image/data/IMG_4044.JPG"
                        },
                    });
                    context.SaveChanges();
                }
                //Movies
                if (!context.Products.Any())
                {
                    context.Products.AddRange(new List<Product>()
                    {
                        new Product()
                        {
                            Name = "Mango",
                            Description = "A mango is an edible stone fruit produced by the tropical tree Mangifera indica.",
                            Price = 39.50,
                            ImageURL = "https://th.bing.com/th/id/OIP.EPVnGwKiGJ0KL3K-lNjexAHaFA?w=248&h=180&c=7&r=0&o=5&dpr=1.5&pid=1.7",
                            ExpiryDate = DateTime.Now.AddDays(10),
                            SupplierId = 3,
                            ProducerId = 3,
                            ProductCatogary = ProductCatogary.Fruit
                        },
                        new Product()
                        {
                            Name = "Onion",
                            Description = "Fresh Bulb-Shaped Onions",
                            Price = 29.50,
                            ImageURL = "https://www.bing.com/th?id=OIP.EzcA3G1RCbb8lcSMD7Og9QHaFy&w=176&h=185&c=8&rs=1&qlt=90&o=6&dpr=1.5&pid=3.1&rm=2",
                            ExpiryDate = DateTime.Now.AddDays(3),
                            SupplierId = 1,
                            ProducerId = 1,
                            ProductCatogary = ProductCatogary.Vegetable
                        },
                        new Product()
                        {
                            Name = "Amul-Milk",
                            Description = "!00% Pure Milk",
                            Price = 39.50,
                            ImageURL = "https://th.bing.com/th/id/OIP.Tnm2wuDbIrbzmiju4LDJWQHaIq?w=176&h=206&c=7&r=0&o=5&dpr=1.5&pid=1.7",
                            ExpiryDate = DateTime.Now.AddDays(7),
                            SupplierId = 2,
                            ProducerId = 2,
                            ProductCatogary = ProductCatogary.DairyProduct
                        },
                        new Product()
                        {
                            Name = "Moong_Dal",
                            Description = "Fresh Dal rich in Protien",
                            Price = 39.50,
                            ImageURL = "https://th.bing.com/th/id/R.8e43bd9c1cb4d6a1e38f578caa5f2fdb?rik=RwsMM%2bvMsp9RKg&riu=http%3a%2f%2f4.imimg.com%2fdata4%2fTW%2fOX%2fMY-5386842%2ft-dall-250x250.jpg&ehk=wK4aerax4uwCvce8%2bTU85hfnEZnJcsTCOcbSjEs2XoI%3d&risl=&pid=ImgRaw&r=0",
                            ExpiryDate = DateTime.Now.AddDays(-5),
                            SupplierId = 1,
                            ProducerId = 2,
                            ProductCatogary = ProductCatogary.Pulse
                        },
                    });
                    context.SaveChanges();
                }
                //Actors & Movies
                if (!context.Country_Product.Any())
                {
                    context.Country_Product.AddRange(new List<Country_Product>()
                    {
                        new Country_Product()
                        {
                            CountryId = 1,
                            ProductId = 1
                        },
                        new Country_Product()
                        {
                            CountryId = 3,
                            ProductId = 1
                        },

                         new Country_Product()
                        {
                            CountryId = 1,
                            ProductId = 2
                        },
                         new Country_Product()
                        {
                            CountryId = 3,
                            ProductId = 2
                        },

                        new Country_Product()
                        {
                            CountryId = 1,
                            ProductId = 3
                        },
                        new Country_Product()
                        {
                            CountryId = 2,
                            ProductId = 3
                        },
                        new Country_Product()
                        {
                            CountryId = 3,
                            ProductId = 3
                        },


                        new Country_Product()
                        {
                            CountryId = 2,
                            ProductId = 4
                        },
                        new Country_Product()
                        {
                            CountryId = 3,
                            ProductId = 4
                        },
                    });
                    context.SaveChanges();
                }
            }

        }

        public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {

                //Roles
                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
                if (!await roleManager.RoleExistsAsync(UserRoles.User))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.User));

                //Users
                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                string adminUserEmail = "admin@groceryhx.com";

                var adminUser = await userManager.FindByEmailAsync(adminUserEmail);
                if (adminUser == null)
                {
                    var newAdminUser = new ApplicationUser()
                    {
                        FullName = "Admin User",
                        UserName = "admin-user",
                        Email = adminUserEmail,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newAdminUser, "Harsh@123");
                    await userManager.AddToRoleAsync(newAdminUser, UserRoles.Admin);
                }


                string appUserEmail = "user@groceryhx.com";

                var appUser = await userManager.FindByEmailAsync(appUserEmail);
                if (appUser == null)
                {
                    var newAppUser = new ApplicationUser()
                    {
                        FullName = "Application User",
                        UserName = "app-user",
                        Email = appUserEmail,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newAppUser, "Harsh@123");
                    await userManager.AddToRoleAsync(newAppUser, UserRoles.User);
                }
            }
        }

    }
}
