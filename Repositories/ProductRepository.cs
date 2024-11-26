using BusinessObjects;
using DAOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class ProductRepository : IProductRepository
    {

        public bool AddProduct(Product p) => ProductDAO.Instance.AddProduct(p);

        public bool UpdateProduct(Product p) => ProductDAO.Instance.UpdateProduct(p);

        public bool DeleteProductById(int id) => ProductDAO.Instance.DeleteProductById(id);


        public Product GetProductById(int id) => ProductDAO.Instance.GetProductByid(id);
        

        public List<Product> GetProducts() => ProductDAO.Instance.GetProducts();
        
    }
}
