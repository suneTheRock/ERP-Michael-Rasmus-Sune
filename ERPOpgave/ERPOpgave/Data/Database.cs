using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERPOpgave.Models;



namespace ERPOpgave.Data
{
    public class Database
    {

        List<Customer> customers = new List<Customer>();

        public Product p;
        public List<Product> productList = new List<Product>();


        public static Database Instance { get; private set; }
        static Database()
        {
            Instance = new Database();


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
            foreach (Product p in productList)
            {
                Console.WriteLine(p);
            }
            return p;

        }

        public void AddProduct()
        {
            productList.Add(p);
        }

        public void UpdateProduct(Product p, int Id)
        {
            p.ProductId = Id;
        }

        public void DeleteProductById(int id)
        {
            if (p.ProductId == id)
            {
                productList.Remove(p);
            }

        }

    }
}
