using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ZippersMvc.Data;
using System;
using System.Linq;
using System.Security.Cryptography;

namespace ZippersMvc.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<ApplicationDbContext>>()))
            {
                if (context.Zippers.Any())
                {
                    return;   // DB has been seeded
                }

                context.Zippers.AddRange(
                    new Zippers
                    {
                        Type = "Metal",
                        Price = 200,
                        Durability = "High",
                        WaterResistance = "Highly water - resistant",
                        Strength = "High",
                        Flexibility = "Medium",
                        Rating = "5",
                    },
                    new Zippers
                    {
                        Type = "Plastic",
                        Price = 100,
                        Durability = "Low",
                        WaterResistance = "Minimal water - resistance",
                        Strength = "Low",
                        Flexibility = "Rigid construction",
                        Rating = "3",
                    },
                    new Zippers
                    {
                        Type = "Coil",
                        Price = 100,
                        Durability = "Medium",
                        WaterResistance = "Minimal water - resistance",
                        Strength = "Fragile slider",
                        Flexibility = "Limited range of motion",
                        Rating = "2",
                    },
                    new Zippers
                    {
                        Type = "Invisible",
                        Price = 300,
                        Durability = "Low",
                        WaterResistance = "Medium water - resistance",
                        Strength = "Weak grip",
                        Flexibility = "Medium",
                        Rating = "4",
                    },
                    new Zippers
                    {
                        Type = "Reverse",
                        Price = 200,
                        Durability = "Medium",
                        WaterResistance = "highly water - resistance",
                        Strength = "High",
                        Flexibility = "Medium",
                        Rating = "5",
                    },
                    new Zippers
                    {
                        Type = "Two-way",
                        Price = 300,
                        Durability = "High",
                        WaterResistance = "Medium water - resistance",
                        Strength = "Medium",
                        Flexibility = "High",
                        Rating = "5",
                    },
                    new Zippers
                    {
                        Type = "Decorative",
                        Price = 400,
                        Durability = "Low",
                        WaterResistance = "Not water - resistance",
                        Strength = "Low",
                        Flexibility = "Rigid construction",
                        Rating = "2",
                    },
                    new Zippers
                    {
                        Type = "Separating",
                        Price = 300,
                        Durability = "High",
                        WaterResistance = "Highly water - resistance",
                        Strength = "Medium",
                        Flexibility = "Good Flexibility",
                        Rating = "3",
                    },
                    new Zippers
                    {
                        Type = "Simple",
                        Price = 100,
                        Durability = "Medium",
                        WaterResistance = "Basic water repellent treatment",
                        Strength = "Low",
                        Flexibility = "Medium",
                        Rating = "3",
                    },
                    new Zippers
                    {
                        Type = "Standard",
                        Price = 500,
                        Durability = "High",
                        WaterResistance = "Highly water - resistance",
                        Strength = "High",
                        Flexibility = "High flexibility",
                        Rating = "5",
                    }
                );
                context.SaveChanges();
            }
        }
    }
}