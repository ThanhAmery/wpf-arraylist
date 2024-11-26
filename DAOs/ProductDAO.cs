using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAOs
{
    public class ProductDAO : GenericDAO<ProductDAO>
    {
        List<Product> listProducts;
        public ProductDAO()
        {
            Product chai = new Product(1, "Chai", 3, 12, 18);

            Product chang = new Product(2, "Chang", 1, 23, 19);

            Product aniseed = new Product(3, "Aniseed Syrup", 2, 23, 10);

            listProducts = new List<Product> { chai, chang, aniseed };

        }

        public List<Product> GetProducts()
        {
            return listProducts;
        }

        public int GetMaxProductId()
        {
            if(listProducts.Count > 0)
            {
                return listProducts.Max(p => p.ProductId) + 1;
            }
            else
            {
                return 0;
            }
        }


        public bool AddProduct(Product product)
        {
            var p = GetProductByid(product.ProductId);
            if(p == null)
            {
                listProducts.Add(product);
                return true;
            }
            return false;
        }

        

        public bool UpdateProduct(Product product)
        {
            var p = GetProductByid(product.ProductId);
            if( p != null)
            {
                p.ProductId = product.ProductId;
                p.ProductName = product.ProductName;
                p.UnitPrice = product.UnitPrice;
                p.UnitInStock = product.UnitInStock;
                p.CategoryId = product.CategoryId;

                return true;
            }
            return false;
        }



        public bool DeleteProductById(int id)
        {
            var p = GetProductByid(id);
            if(p != null)
            {
                listProducts.Remove(p);
                return true;
            }
            return false;
        }


        public Product GetProductByid(int id)
        {
            foreach (var p in listProducts.ToList())
            {
                if (p.ProductId == id)
                {
                    return p;
                }
            }
            return null;
        }

    }

}
