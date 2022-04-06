using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERPOpgave.Models;
using System.Data.SqlClient;

namespace ERPOpgave.Data
{
    public partial class Database
    {
        List<Customer> customers = new List<Customer>();
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
            // det er vores sql string som tager i og finder alle informationer vi skal bruge for at lave et customer objekt.
            cmd.CommandText = $"select firstName, lastName FROM Customers JOIN where {i}= customerID";
            //vi skal bruge reader til at læse information 

            // brug reader til at lave customer objekt
            //Customer customer = new Customer()

            //til sidst returneres der customer objektet.
            //return customers;

            

            foreach(Customer customer in customers)
            {
                if (i == customer.CustomerID) { return customer; }
            }
            throw new Exception("No Customer by that ID");           
        }
        //Get all Customers
        public List<Customer> GetAllCustomers()
        {
            SqlCommand sql = conn.CreateCommand();
            sql.CommandText = "select firstName, lastName, email FROM Persons";
            sql.CommandType = System.Data.CommandType.Text;
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
