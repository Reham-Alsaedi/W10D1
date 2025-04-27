using System.Collections.Generic;
using ProductApp.Models;

namespace ProductApp.Services
{
    public interface IProductService
    {
        List<Product> GetAll();
        Product GetById(int id);
        void Add(Product product);
    }
}
