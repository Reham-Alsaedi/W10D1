using System.Collections.Generic;
using System.Linq;
using ProductApp.Models;

namespace ProductApp.Services
{
    public class ProductService : IProductService
    {
        private readonly List<Product> _products = new List<Product>();

        public ProductService()
        {
            _products.Add(
                new Product
                {
                    Id = 1,
                    Name = "MacBook Pro",
                    Price = 6500,
                }
            );
            _products.Add(
                new Product
                {
                    Id = 2,
                    Name = "Iphone 14",
                    Price = 4500,
                }
            );
            _products.Add(
                new Product
                {
                    Id = 3,
                    Name = "Ipad Pro",
                    Price = 3500,
                }
            );
        }

        public List<Product> GetAll() => _products;

        public Product GetById(int id) => _products.FirstOrDefault(p => p.Id == id);

        public void Add(Product product)
        {
            _products.Add(product);
        }
    }
}
