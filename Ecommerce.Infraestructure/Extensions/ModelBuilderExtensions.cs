using ECommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Infraestructure.Extensions
{
    internal static class ModelBuilderExtensions
    {
        public static ModelBuilder Seed(this ModelBuilder builder)
        {
            builder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Vehicles" },
                new Category { Id = 2, Name = "Sport" },
                new Category { Id = 3, Name = "Services" }
            );

            builder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "Mazda 3", Price = 2314, CategoryId = 1 },
                new Product { Id = 2, Name = "Mazda 2", Price = 2314, CategoryId = 1 },
                new Product { Id = 3, Name = "Chevrolet Aveo", Price = 2014, CategoryId = 1 },
                new Product { Id = 4, Name = "Chevrolet Captiva", Price = 2100, CategoryId = 1 },
                new Product { Id = 5, Name = "Chevrolet Spark", Price = 1300, CategoryId = 1 },
                new Product { Id = 6, Name = "Chevrolet Corsa", Price = 1550, CategoryId = 1 },
                new Product { Id = 7, Name = "Renault Logan", Price = 1470, CategoryId = 1 },
                new Product { Id = 8, Name = "Renault Duster", Price = 1595, CategoryId = 1 },
                new Product { Id = 9, Name = "Renault Sandero", Price = 1540, CategoryId = 1 },
                new Product { Id = 10, Name = "Renault Stepway", Price = 1600, CategoryId = 1 },
                new Product { Id = 11, Name = "Ford Fiesta", Price = 1800, CategoryId = 1 },
                new Product { Id = 12, Name = "Ford Explorer", Price = 1950, CategoryId = 1 },
                new Product { Id = 13, Name = "Ford Ranger", Price = 1900, CategoryId = 1 },
                new Product { Id = 14, Name = "Ford Focus", Price = 2050, CategoryId = 1 },
                new Product { Id = 15, Name = "Nissan Versa", Price = 1700, CategoryId = 1 },
                new Product { Id = 16, Name = "Nissan March", Price = 1600, CategoryId = 1 },
                new Product { Id = 17, Name = "Nissan Frontier", Price = 1855, CategoryId = 1 },
                new Product { Id = 18, Name = "Nissan Sentra", Price = 1700, CategoryId = 1 },
                new Product { Id = 19, Name = "Nissan Tiida", Price = 1650, CategoryId = 1 },
                new Product { Id = 20, Name = "Volkswagen Jetta", Price = 2400, CategoryId = 1 },
                new Product { Id = 21, Name = "Volkswagen Gol", Price = 2200, CategoryId = 1 },
                new Product { Id = 22, Name = "Volkswagen Amarok", Price = 2450, CategoryId = 1 },
                new Product { Id = 23, Name = "Volkswagen Virtus", Price = 2100, CategoryId = 1 }
            );

            builder.Entity<Customer>().HasData(
                new Customer { Id = 1, Name = "Luca Sandoval", Address = "1159 NE 153 ST", PhoneNumber = "1254454588", Email = "usuario1@ymail.com" },
                new Customer { Id = 2, Name = "Luca Sandoval", Address = "Independence Avenue, S.E.", Email = "usuario2@ymail.com" }
            );

            builder.Entity<Stock>().HasData(
                new Stock { Id = 1, ProductId = 1, Quantity = 50 },
                new Stock { Id = 2, ProductId = 2, Quantity = 50 },
                new Stock { Id = 3, ProductId = 3, Quantity = 50 },
                new Stock { Id = 4, ProductId = 4, Quantity = 50 },
                new Stock { Id = 5, ProductId = 5, Quantity = 50 },
                new Stock { Id = 6, ProductId = 6, Quantity = 50 },
                new Stock { Id = 7, ProductId = 7, Quantity = 50 },
                new Stock { Id = 8, ProductId = 8, Quantity = 50 },
                new Stock { Id = 9, ProductId = 9, Quantity = 50 },
                new Stock { Id = 10, ProductId = 10, Quantity = 50 },
                new Stock { Id = 11, ProductId = 11, Quantity = 50 },
                new Stock { Id = 12, ProductId = 12, Quantity = 50 },
                new Stock { Id = 13, ProductId = 13, Quantity = 50 },
                new Stock { Id = 14, ProductId = 14, Quantity = 50 },
                new Stock { Id = 15, ProductId = 15, Quantity = 50 },
                new Stock { Id = 16, ProductId = 16, Quantity = 50 },
                new Stock { Id = 17, ProductId = 17, Quantity = 50 },
                new Stock { Id = 18, ProductId = 18, Quantity = 50 },
                new Stock { Id = 19, ProductId = 19, Quantity = 50 },
                new Stock { Id = 20, ProductId = 20, Quantity = 50 },
                new Stock { Id = 21, ProductId = 21, Quantity = 50 },
                new Stock { Id = 22, ProductId = 22, Quantity = 50 },
                new Stock { Id = 23, ProductId = 23, Quantity = 50 }
            );

            return builder;
        }
    }
}
