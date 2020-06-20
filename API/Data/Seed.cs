using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Models;

namespace API.Data
{
    public class Seed
    {
        public static async Task SeedData(DataContext context)
        {
            if (!context.Categories.Any())
            {
                var categories = new List<Category>
                {
                    new Category
                    {
                        Name = "Tech",
                        SubCategories = new List<Category>
                        {
                            new Category
                            {
                                Name = "Phones",
                                Products = new List<Product>
                                {
                                    new Product
                                    {
                                        Name = "Samsung A10",
                                        CategoryId = 2,
                                        Price = 210.65d
                                    },
                                    new Product
                                    {
                                        Name = "Apple iPhone 8",
                                        CategoryId = 2,
                                        Price = 290.99d
                                    }
                                }
                            },
                            new Category
                            {
                                Name = "TV sets",
                                Products = new List<Product>
                                {
                                    new Product
                                    {
                                        Name = "Vivax Star Eye C5560 Smart",
                                        CategoryId = 3,
                                        Price = 305.65d
                                    },
                                    new Product
                                    {
                                        Name = "Philips Ultra PIXE Graphics",
                                        CategoryId = 3,
                                        Price = 480.78d
                                    }
                                }
                            },
                        },
                        Products = new List<Product>
                        {
                            new Product
                            {
                                Name = "Sony A-500 Amplifier",
                                Price = 130.99d
                            },
                            new Product
                            {
                                Name = "JBL T550 Speakers",
                                Price = 98.00d
                            }
                        }
                    },
                    new Category
                    {
                        Name = "Furniture",
                        SubCategories = new List<Category>
                        {
                            new Category
                            {
                                Name = "Tables",
                                Products = new List<Product>
                                {
                                    new Product
                                    {
                                        Name = "Round Table Charry Wood Esal",
                                        CategoryId = 5,
                                        Price = 700.00d
                                    },
                                    new Product
                                    {
                                        Name = "Metal Glass Modern Inovation",
                                        CategoryId = 5,
                                        Price = 880.30d
                                    }
                                }
                            },
                            new Category
                            {
                                Name = "Chairs",
                                Products = new List<Product>
                                {
                                    new Product
                                    {
                                        Name = "Dream Chair Two",
                                        CategoryId = 6,
                                        Price = 160.00d
                                    },
                                    new Product
                                    {
                                        Name = "Wood Chair Larryman",
                                        CategoryId = 6,
                                        Price = 220d
                                    }
                                }
                            },
                        },
                        Products = new List<Product>
                        {
                            new Product
                            {
                                Name = "Stool Dco One",
                                CategoryId = 4,
                                Price = 99.90d
                            },
                            new Product
                            {
                                Name = "Shelf Black ITR",
                                CategoryId = 4,
                                Price = 20.67d
                            }
                        }
                    }
                };
                await context.Categories.AddRangeAsync(categories);
                await context.SaveChangesAsync();
            }
        }
    }
}