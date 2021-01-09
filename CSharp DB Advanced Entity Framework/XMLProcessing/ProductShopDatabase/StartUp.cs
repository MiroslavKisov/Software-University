namespace ProductShopDatabase
{
    using AutoMapper;
    using ProductShopDatabase.Data;
    using ProductShopDatabase.Dto;
    using ProductShopDatabase.Models;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Xml;
    using System.Xml.Serialization;

    public class StartUp
    {
        public static void Main()
        {
            using (var context = new ProductShopDatabaseContext())
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.AddProfile<ProductShopProfile>();
                });

                var mapper = config.CreateMapper();

                DatabaseInit(context);

                ImportUsers(context, mapper);
                ImportProducts(context, mapper);
                ImportCategories(context, mapper);
                ImportCategoriesAndProducts(context);
                ProductsInRange(context, mapper);
            }
        }

        private static void ProductsInRange(ProductShopDatabaseContext context, IMapper mapper)
        {
            var products = context.Products
                                  .Where(e => e.Price >= 1000 && e.Price <= 2000 && e.Buyer != null)
                                  .OrderByDescending(p => p.Price)
                                  .Select(e => new ProductsInRangeDto
                                  {
                                      Name = e.Name,
                                      Price = e.Price,
                                      Buyer = e.Buyer.FirstName + " " + e.Buyer.LastName,
                                  })
                                  .ToArray();

            var serializer = new XmlSerializer(typeof(ProductsInRangeDto[]), new XmlRootAttribute("products"));

            using (var writer = new StreamWriter(@"C:\Users\mirom\OneDrive\Документи\Visual Studio 2017\Projects\XMLProcessing\ProductShopDatabase\XML\products-in-range.xml"))
            {
                serializer.Serialize(writer, products);
            }
            
        }

        private static void ImportCategoriesAndProducts(ProductShopDatabaseContext context)
        {
            var random = new Random();

            var categoryProducts = new List<CategoryProducts>();

            for (int i = 1; i <= 199; i++)
            {
                var categoryProduct = new CategoryProducts()
                {
                    CategoryId = random.Next(1, 12),
                    ProductId = i,
                };

                categoryProducts.Add(categoryProduct);
            }

            context.CategoryProducts.AddRange(categoryProducts);
            context.SaveChanges();
        }

        private static void ImportCategories(ProductShopDatabaseContext context, IMapper mapper)
        {
            string path = @"..\..\..\XML\categories.xml";
            var xmlCategoriesAsString = File.ReadAllText(path);

            var serializer = new XmlSerializer(typeof(CategoryDto[]), new XmlRootAttribute("categories"));
            var deserializedCategories = (CategoryDto[])serializer.Deserialize(new StringReader(xmlCategoriesAsString));

            List<Category> categories = new List<Category>();

            foreach (var categoryDto in deserializedCategories)
            {
                if (!IsValid(categoryDto))
                {
                    continue;
                }

                var category = mapper.Map<Category>(categoryDto);

                categories.Add(category);
            }

            context.Categories.AddRange(categories);
            context.SaveChanges();
        }

        private static void DatabaseInit(ProductShopDatabaseContext context)
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
        }

        private static void ImportProducts(ProductShopDatabaseContext context, IMapper mapper)
        {
            string path = @"..\..\..\XML\products.xml";
            var xmlProductsAsString = File.ReadAllText(path);

            var serializer = new XmlSerializer(typeof(ProductDto[]), new XmlRootAttribute("products"));
            var deserializedProducts = (ProductDto[])serializer.Deserialize(new StringReader(xmlProductsAsString));

            List<Product> products = new List<Product>();

            int counter = 0;

            foreach (var productDto in deserializedProducts)
            {
                if (!IsValid(productDto))
                {
                    continue;
                }

                var product = mapper.Map<Product>(productDto);

                var buyerId = new Random().Next(1, 22);
                var sellerId = new Random().Next(23, 56);

                product.BuyerId = buyerId;
                product.SellerId = sellerId;

                counter++;

                if (counter == 4)
                {
                    product.BuyerId = null;
                    counter = 0;
                }

                products.Add(product);
            }

            context.Products.AddRange(products);
            context.SaveChanges();
        }

        private static void ImportUsers(ProductShopDatabaseContext context, IMapper mapper)
        {
            string path = @"..\..\..\XML\users.xml";
            var xmlUsersAsString = File.ReadAllText(path);

            var serializer = new XmlSerializer(typeof(UserDto[]), new XmlRootAttribute("users"));
            var deserializedUsers = (UserDto[])serializer.Deserialize(new StringReader(xmlUsersAsString));

            List<User> users = new List<User>();

            foreach (var userDto in deserializedUsers)
            {
                if (!IsValid(userDto))
                {
                    continue;
                }

                var user = mapper.Map<User>(userDto);

                users.Add(user);
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


