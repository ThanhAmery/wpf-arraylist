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

			Product chef = new Product(4, "Chef Anton's Cajun Seasoning", 2, 34, 22);

			Product chefMix = new Product(5, "Chef Anton's Gumbo Mix", 2, 45, 34);

			Product grandma = new Product(6, "Grandma's Boysenberry Spread", 2, 21, 25);

			Product uncle = new Product(7, "Uncle Bob's Organic Dried Pears", 7, 22, 30);

			//Product mishi = new Product(8, "Mishi Kobe Niku", 6, 97, 29);

			//Product ikura = new Product(9, "Ikura", 8, 31, 31);

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
