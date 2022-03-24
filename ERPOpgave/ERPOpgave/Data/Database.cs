using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPOpgave.Data
{
        public Product p;
        public List<Product> productList = new List<Product>();

        public static Database Instance { get; private set; }
        static  Database() 
        {
            Instance = new Database();
            
        }

        public Product GetProductById(int id)
        {
            foreach (Product p in productList)
            {
                if (p.ProductId == id)
                    return p;
            }
            return p;
        }

        public Product GetAllProducts()
        {
            foreach(Product p in productList)
            {
                Console.WriteLine(p);
            }
            return p;

        }

        public void AddProduct()
        {
            productList.Add(p);
        }

        public void UpdateProduct(Product p,int Id)
        {
            p.ProductId = Id;
        }

        public void DeleteProductById(int id)
        {
            if(p.ProductId == id )
            {
                productList.Remove(p);
            }
            
        }
}
