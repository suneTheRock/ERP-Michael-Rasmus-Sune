using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERPOpgave.Products;
using ERPOpgave.Order;
using ERPOpgave.Models;
using System.Data.SqlClient;

namespace ERPOpgave.Data
{
    partial class Database
    {
        public Product p;
        public List<Product> productList = new List<Product>();
        public List<SalesOrder> orderList = new List<SalesOrder>();

        /// <summary>
        /// TEMPOARY
        public Customer c;
        public List<Customer> customerList = new List<Customer>();
        /// </summary>

        public static Database Instance { get; private set; }

        SqlConnection conn = null;
        static  Database() 
        {
            Instance = new Database();
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = "docker.data.techcollege.dk";
            builder.UserID = "H1PD021122_Gruppe2";
            builder.Password = "H1PD021122_Gruppe2";
            Instance.conn = new SqlConnection(builder.ConnectionString);
            Instance.conn.Open();
        }
        //Getting Customer based on ID
        public Customer GetCustomerFromID(int i)
        {
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT firstName FROM Customers JOIN";
            foreach(Customer customer in customerList)
            {
                if (i == customer.CustomerID) { return customer; }
            }
            throw new Exception("No Customer by that ID");           
        }
        //Get all Customers
        public List<Customer> GetAllCustomers()
        {
            return customerList;
        }

        //Insert Customer
        public void InsertCustomer(Customer customername)
        {
            customerList.Add(customername);
        }

        //Update Customer by ID
        public void UpdateCustomerByID(Customer customername, int id)
        {
            for (int i = 0; i < customerList.Count; i++)
            {
                if (id == customerList[i].CustomerID)
                {
                    customerList[i] = customername;
                }
            }
            throw new Exception("No Customer by that ID");
        }

        //Delete Customer by ID
        public void DeleteCustomerByID(Customer customername, int id)
        {
            for (int i = 0; i < customerList.Count; i++)
            {
                if (id == customerList[i].CustomerID)
                {
                    customerList.RemoveAt(i);
                }
            }
            throw new Exception("No Customer by that ID");
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
