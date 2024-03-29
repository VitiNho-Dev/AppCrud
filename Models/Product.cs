using System;
using System.Collections.Generic;
namespace AppCrud.Models
{
    public class Product
    {
        public int Id { get; set; }

        public required string Name { get; set; }

        public double Price { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}
