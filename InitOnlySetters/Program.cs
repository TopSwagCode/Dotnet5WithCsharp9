using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace InitOnlySetters
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var product = new Product
            {
                Name = "TopSwag Product",
                Price = 1000000000
            };

            ValidationContext validationContext = new ValidationContext(product);

            var errorResults = new List<ValidationResult>();
            Validator.TryValidateObject(product, validationContext, errorResults);

            //product.Name = "Product"; // No go
        }
    }


    public class Product
    {
        public Product()
        {
        }

        [Required]
        [MaxLength(15)]
        public string Name { get; init; }

        [Required]
        public int? Price { get; init; }
    }
}
