using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection;
using MyStore.Domain.DTO;
using MyStore.Domain.Models;
using MyStore.Repository.Context;
using MyStore.Repository.DomainMapper;

namespace MyStore.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //Order order = new Order()
            //{
            //    Provider = new Provider()
            //    {
            //        Email = "ttt",
            //        Name = "coca=cola",
            //        Location = "Tbilisi"
            //    },
            //    User = null
            //};

            //OrderDetailsDTO orderDetails = new OrderDetailsDTO();
            //{

            //};

            //var x = ModelMapper.GetMapper<OrderDetails, OrderDetailsDTO>().Map<OrderDTO>(orderDetails);
            //Console.WriteLine(x);

            ProductDTO productDTO = new ProductDTO()
            {
                CategoryID = 1,
                Name = "ZURAIE",
                Price = 105.90m
            };

            using (AppDbContext context = new AppDbContext())
            {
                context.Products.Add(productDTO);
                context.SaveChanges();
                Console.WriteLine(productDTO.Category.Name);
            }
        }
    }
}