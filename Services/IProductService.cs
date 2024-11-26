using BusinessObjects;
using DAOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IProductService
    {

        bool AddProduct(Product p);

        bool UpdateProduct(Product p);
        bool DeleteProductById(int id);

        List<Product> GetProducts();

        Product GetProductById(int id);
    }
}
