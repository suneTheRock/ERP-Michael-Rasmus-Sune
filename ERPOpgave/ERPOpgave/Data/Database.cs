using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERPOpgave.Products;
using ERPOpgave.Order;

namespace ERPOpgave.Data
{
    partial class Database
    {
        public Product p;
        public List<Product> productList = new List<Product>();
        public List<SalesOrder> orderList = new List<SalesOrder>();


        public static Database Instance { get; private set; }
        static Database()
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
        public Product GetOrderById(int id)
        {
            foreach (Product p in productList)
            {
                if (p.ProductId == id)
                    return p;
            }
            return p;
        }

        public void GetAllProducts()
        {
            foreach (Product p in productList)
            {
                Console.WriteLine(p);
            }

        }
        public void GetAllSalesOrder()
        {
            foreach (SalesOrder order in orderList)
            {
                Console.WriteLine(order);
            }
        }
        public void AddProduct(Product product)
        {
            productList.Add(product);
        }
        public void AddSalesOrder(SalesOrder order)
        {
            orderList.Add(order);
        }
        public void UpdateProduct(Product p, int Id)
        {
            p.ProductId = Id;
        }
        public void UpdateProduct(SalesOrder order, int Id)
        {
            order.ID = Id;
        }

        public void DeleteProductById(int id)
        {
            foreach (Product p in productList)
            {
                if (p.ProductId == id)
                {
                    productList.Remove(p);
                }
            }         
        }
        public void DeleteSalesOrderById(int id)
        {
            foreach (SalesOrder order in orderList)
            {
                if (order.ID == id)
                {
                    orderList.Remove(order);
                }
            }               
        }
    }
}
