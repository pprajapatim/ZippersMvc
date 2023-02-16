using System;
using System.ComponentModel.DataAnnotations;

namespace ZippersMvc.Models
{
    public class Zippers
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public decimal Price { get; set; }
        public string Durability { get; set; }
        public string WaterResistance { get; set; }
        public string Strength { get; set; }
        public string Flexibility { get; set; }
        
    }
}
