using BusinessObjects;
using DAOs;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository iProductRepository;

        public ProductService()
        {
            iProductRepository = new ProductRepository();
        }


        public Product GetProductById(int id) => iProductRepository.GetProductById(id);
        

        public List<Product> GetProducts() => iProductRepository.GetProducts();
        
        public bool AddProduct(Product p)
        {
            return iProductRepository.AddProduct(p);
        }

        public bool UpdateProduct(Product p)
        {
            return iProductRepository.UpdateProduct(p);
        }

        public bool DeleteProductById(int id)
        {
            return iProductRepository.DeleteProductById(id);
        }

    }
}
