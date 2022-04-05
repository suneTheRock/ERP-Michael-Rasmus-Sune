using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
<<<<<<< HEAD
using ERPOpgave.Products;
using ERPOpgave.Order;
=======
using ERPOpgave.Models;
>>>>>>> origin/Customer

namespace ERPOpgave.Data
{
    partial class Database
    {
<<<<<<< HEAD
        public Product p;
        public List<Product> productList = new List<Product>();
        public List<SalesOrder> orderList = new List<SalesOrder>();


=======
        List<Customer> customers = new List<Customer>();
>>>>>>> origin/Customer
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
        //Getting Customer based on ID
        public Customer GetCustomerFromID(int i)
        {
            foreach(Customer customer in customers)
            {
                if (i == customer.CustomerID) { return customer; }
            }
            throw new Exception("No Customer by that ID");           
        }
        //Get all Customers
        public List<Customer> GetAllCustomers()
        {
            return customers;
        }

        //Insert Customer
        public void InsertCustomer(Customer customername)
        {
            customers.Add(customername);
        }

        //Update Customer by ID
        public void UpdateCustomerByID(Customer customername, int id)
        {
            for (int i = 0; i < customers.Count; i++)
            {
                if (id == customers[i].CustomerID)
                {
                    customers[i] = customername;
                }
            }
            throw new Exception("No Customer by that ID");
        }

        //Delete Customer by ID
        public void DeleteCustomerByID(Customer customername, int id)
        {
            for (int i = 0; i < customers.Count; i++)
            {
                if (id == customers[i].CustomerID)
                {
                    customers.RemoveAt(i);
                }
            }
            throw new Exception("No Customer by that ID");
        }
    }
}
