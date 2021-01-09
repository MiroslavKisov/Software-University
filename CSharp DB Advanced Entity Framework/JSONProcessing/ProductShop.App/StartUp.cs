namespace ProductShop.App
{
    using AutoMapper;
    using System.Runtime.Serialization.Json;
    using Data;
    using Models;
    using System;
    using System.Text;
    using System.IO;
    using System.Linq;
    using ProductShop.App.Dto;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Newtonsoft.Json;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ProductShopProfile>();
            });
            var mapper = config.CreateMapper();

            var context = new ProductShopContext();

            DatabaseInit(context);

            ImportUsers(context, mapper);
            ImportProducts(context, mapper);
            ImportCategories(context, mapper);
            ImportCategoriesProducts(context);
            ExportProductsInRange(context);
            ExportSuccessfullySoldProducts(context);
            ExportCategoriesByProductCount(context);
            ExportUsersAndProducts(context);
        }

        private static void ExportUsersAndProducts(ProductShopContext context)
        {
            var usersAndProducts = context.Users
                                          .Where(e => e.ProductsSold.Count >= 1)
                                          .Select(e => new
                                          {
                                              firstname = e.FirstName,
                                              lastName = e.LastName,
                                              age = e.Age,
                                              count = e.ProductsSold.Count,
                                              products = e.ProductsSold
                                                          .Select(z => new
                                                          {
                                                              name = z.Name,
                                                              price = z.Price
                                                          }).ToList()
                                                              
                                          })
                                          .OrderByDescending(e => e.count)
                                          .ThenBy(e => e.lastName)
                                          .ToArray();

            var jsonStr = JsonConvert.SerializeObject(usersAndProducts, Formatting.Indented);

            File.WriteAllText(@"..\..\..\ExportJson\users-and-products.json", jsonStr);
        }

        private static void ExportCategoriesByProductCount(ProductShopContext context)
        {
            var categoriesByProductCount = context.Categories
                                                  .Select(e => new
                                                  {
                                                      category = e.Name,

                                                      productsCount = e.CategoryProducts.Count,

                                                      averagePrice = e.CategoryProducts
                                                                      .Average(z => z.Product.Price),

                                                      totalRavenue = e.CategoryProducts.Sum(z => z.Product.Price),
                                                  })
                                                  .OrderBy(e => e.productsCount)
                                                  .ToArray();

            var jsonStr = JsonConvert.SerializeObject(categoriesByProductCount, Formatting.Indented);

            File.WriteAllText(@"..\..\..\ExportJson\categories-by-products.json", jsonStr);
        }

        private static void ExportSuccessfullySoldProducts(ProductShopContext context)
        {
            var soldProducts = context.Users
                                      .Where(e => e.ProductsSold.Count >= 1)
                                      .Select(e => new
                                      {
                                          firstName = e.FirstName,
                                          lastName = e.LastName,
                                          soldProducts = e.ProductsSold.Where(z => z.Buyer != null)
                                                          .Select(z => new
                                                          {
                                                              name = z.Name,
                                                              price = z.Price,
                                                              buyerFirstName = z.Buyer.FirstName,
                                                              buyerLastName = z.Buyer.LastName,
                                                          })
                                      })
                                      .OrderBy(e => e.lastName)
                                      .ThenBy(e => e.firstName)
                                      .ToArray();

            var jsonStr = JsonConvert.SerializeObject(soldProducts, Formatting.Indented);

            File.WriteAllText(@"..\..\..\ExportJson\users-sold-products.json", jsonStr);

        }

        private static void ExportProductsInRange(ProductShopContext context)
        {
            var products = context.Products
                                  .Where(e => e.Price >= 500 && e.Price <= 1000)
                                  .Select(e => new
                                  {
                                      name = e.Name,
                                      price = e.Price,
                                      seller = e.Seller.FirstName + " " + e.Seller.LastName,
                                  })
                                  .OrderBy(e => e.price)
                                  .ToArray();

            var jsonStr = JsonConvert.SerializeObject(products, Formatting.Indented);
            File.WriteAllText(@"..\..\..\ExportJson\products-in-range.json", jsonStr);
        }

        private static void ImportCategoriesProducts(ProductShopContext context)
        {
            var random = new Random();
            var categoriesProducts = new List<CategoryProduct>();

            for (int i = 1; i <= 192; i++)
            {
                var categotyProduct = new CategoryProduct()
                {
                    ProductId = i,
                    CategoryId = random.Next(1, 12),
                };

                categoriesProducts.Add(categotyProduct);
            }

            context.CategoryProducts.AddRange(categoriesProducts);
            context.SaveChanges();
        }

        private static void ImportCategories(ProductShopContext context, IMapper mapper)
        {
            var jsonStr = File.ReadAllText(@"..\..\..\ImportJson\categories.json");
            var serializer = new DataContractJsonSerializer(typeof(CategoryDto[]));
            var byteArray = Encoding.UTF8.GetBytes(jsonStr);
            var categories = new List<Category>();

            using (var stream = new MemoryStream(byteArray))
            {
                var categoriesDtos = (CategoryDto[])serializer.ReadObject(stream);

                foreach (var categoryDto in categoriesDtos)
                {
                    var category = mapper.Map<Category>(categoryDto);

                    if (IsValid(category))
                    {
                        categories.Add(category);
                    }
                }
            }

            context.Categories.AddRange(categories);
            context.SaveChanges();
        }

        private static void ImportProducts(ProductShopContext context, IMapper mapper)
        {
            var jsonStr = File.ReadAllText(@"..\..\..\ImportJson\products.json");
            var serializer = new DataContractJsonSerializer(typeof(ProductDto[]));
            var byteArray = Encoding.UTF8.GetBytes(jsonStr);
            var products = new List<Product>();
            var random = new Random();

            using (var stream = new MemoryStream(byteArray))
            {
                var productsDto = (ProductDto[])serializer.ReadObject(stream);

                foreach (var productDto in productsDto)
                {
                    var product = mapper.Map<Product>(productDto);

                    if (IsValid(product))
                    {
                        product.SellerId = random.Next(1, 20);
                        int buyerId = random.Next(21, 57);

                        if (buyerId % 2 != 0)
                        {
                            product.BuyerId = buyerId;
                        }

                        products.Add(product);
                    }
                }
            }

            context.Products.AddRange(products);
            context.SaveChanges();
        }

        private static void DatabaseInit(ProductShopContext context)
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
        }

        private static void ImportUsers(ProductShopContext context, IMapper mapper)
        {
            var jsonStr = File.ReadAllText(@"..\..\..\ImportJson\users.json");
            var serializer = new DataContractJsonSerializer(typeof(UserDto[]));
            var byteArray = Encoding.UTF8.GetBytes(jsonStr);
            var users = new List<User>();

            using (var stream = new MemoryStream(byteArray))
            {
                var usersDto = (UserDto[])serializer.ReadObject(stream);
                foreach (var userDto in usersDto)
                {
                    var user = mapper.Map<User>(userDto);

                    if (IsValid(user))
                    {
                        users.Add(user);
                    }
                }
            }

            context.Users.AddRange(users);
            context.SaveChanges();
        }

        public static bool IsValid(object obj)
        {
            var validationContext = new System.ComponentModel.DataAnnotations.ValidationContext(obj);
            var validationResults = new List<ValidationResult>();

            return Validator.TryValidateObject(obj, validationContext, validationResults, true);
        }
    }
}
