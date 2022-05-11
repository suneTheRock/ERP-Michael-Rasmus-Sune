using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERPOpgave.Models;
using ERPOpgave.Products;
using ERPOpgave.Order;
using ERPOpgave.Models;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using ERPOpgave.PersonalInfo;



namespace ERPOpgave.Data
{
    public static partial class Database
    {

        static List<Customer> customers = new List<Customer>();

        public static Product p;
        public static List<Product> productList = new List<Product>();
        public static List<SalesOrder> orderList = new List<SalesOrder>();


        public static Database Instance { get; private set; }

        static SqlConnection conn = null;
        static  Database() 
        {
            //Instance = new Database();
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = "docker.data.techcollege.dk";
            builder.UserID = "H1PD021122_Gruppe2";
            builder.InitialCatalog = "H1PD021122_Gruppe2";
            builder.Password = "H1PD021122_Gruppe2";
            Instance.conn = new SqlConnection(builder.ConnectionString);
            Instance.conn.Open();
        }
        //Getting Customer based on ID
        public static Customer GetCustomerByID(int i)
        {
            Customer customer = null;
            SqlCommand sql = conn.CreateCommand();
            // det er vores sql string som tager i og finder alle informationer vi skal bruge for at lave et customer objekt.
            sql.CommandText = @"SELECT customers.customerID, 
	            customers.lastOrder, 
	            Persons.personID, 
	            Persons.firstName,
	            Persons.lastName,
	            Persons.email,
	            Persons.phone,
	            Adress.adressID,
	            Adress.street,
	            Adress.streetNumber,
	            Adress.city,
	            Adress.zipCode,
	            ContactInfos.contactInfoID,
	            ContactInfos.value_
                FROM[H1PD021122_Gruppe2].[dbo].[Customers]
                JOIN[H1PD021122_Gruppe2].[dbo].[Persons]
                ON Customers.person_ID = Persons.personID
                JOIN[H1PD021122_Gruppe2].[dbo].[Adress]
                ON Customers.Adress_ID = Adress.adressID
                JOIN[H1PD021122_Gruppe2].[dbo].[ContactInfos]
                ON Customers.contactInfo_ID = ContactInfos.contactInfoID

                WHERE Customers.customerID =" + i;
                
            SqlDataReader reader = sql.ExecuteReader();
            while (reader.Read())
            {
                //de objekterne der bliver lavet, sættes til til hver klassens properties.
                int customId = reader.GetInt32(0);
                DateTime lastOrder = reader.GetDateTime(1);
                int personId = reader.GetInt32(2);
                string firstName = reader.GetString(3);
                string lastName = reader.GetString(4);
                string email = reader.GetString(5);
                string phone = reader.GetString(6);
                int adressId = reader.GetInt32(7);
                string street = reader.GetString(8);
                int streetNumber = reader.GetInt32(9);
                string city = reader.GetString(10);
                int zipCode = reader.GetInt32(11);
                int contactInfoId = reader.GetInt32(12);
                int contactInfoValue = reader.GetInt32(13);

                //de objekterne der bliver lavet, sættes til til hver klassens properties.
                ContactInfo contactInfo = new ContactInfo(contactInfoValue);
                contactInfo.ContactInfoID = contactInfoId;
                contactInfo.Value = contactInfoValue;

                Adress adress = new Adress();
                adress.Street = street;
                adress.Number = streetNumber;
                adress.City = city;
                adress.ZipCode = zipCode;

                customer = new Customer(firstName, lastName, email, phone, adress,contactInfo);
                customer.CustomerID = customId;
                customer.LastOrder = lastOrder;
                customer.ContactInfo = contactInfo;
            }
            
            reader.Close();
            
            return customer;
            //vi skal bruge reader til at læse information 

            // brug reader til at lave customer objekt
            //Customer customer = new Customer()

            //til sidst returneres der customer objektet.
                  
        }
        //Get all Customers
        public static List<Customer> GetAllCustomers()
        {
            List<Customer> customers = new List<Customer>();

            //i SQl Scriptet udplukker vi de data vi skal bruge fra tables til at hente fra databasen.
            SqlCommand sql = new SqlCommand
                (@"SELECT customers.customerID,
                                            customers.lastOrder,
                                            Persons.personID,
                                            Persons.firstName,
                                            Persons.lastName,
                                            Persons.email,
                                            Persons.phone,
                                            Adress.adressID,
                                            Adress.street,
                                            Adress.streetNumber,
                                            Adress.city,
                                            Adress.zipCode,
                                            ContactInfos.contactInfoID,
                                            ContactInfos.value_

                                            FROM[H1PD021122_Gruppe2].[dbo].[Customers]
                                            JOIN[H1PD021122_Gruppe2].[dbo].[Persons]
                                            ON Customers.person_ID = Persons.personID
                                            JOIN[H1PD021122_Gruppe2].[dbo].[Adress]
                                            ON Customers.Adress_ID = Adress.adressID
                                            JOIN[H1PD021122_Gruppe2].[dbo].[ContactInfos]
                                            ON Customers.contactInfo_ID = ContactInfos.contactInfoID", conn);
            //eksekverer sql scriptet
            SqlDataReader reader = sql.ExecuteReader();
            while(reader.Read())
            {
                //imens scriptet bliver læst fra SQL databasen, bliver der lavet objekter og tilføjes til hver kolonne 
                int customId = reader.GetInt32(0);
                DateTime lastOrder = reader.GetDateTime(1);
                int personId = reader.GetInt32(2);
                string firstName = reader.GetString(3);
                string lastName = reader.GetString(4);
                string email = reader.GetString(5);
                string phone = reader.GetString(6);
                int adressId = reader.GetInt32(7);
                string street = reader.GetString(8);
                int streetNumber = reader.GetInt32(9);
                string city = reader.GetString(10);
                int zipCode = reader.GetInt32(11);
                int contactInfoId = reader.GetInt32(12);
                int contactInfoValue = reader.GetInt32(13);

                //de objekterne der bliver lavet, sættes til til hver klassens properties.
                ContactInfo contactInfo = new ContactInfo(contactInfoValue);
                contactInfo.ContactInfoID = contactInfoId;
                contactInfo.Value = contactInfoValue;
                
                Adress adress = new Adress();
                adress.Street = street;
                adress.Number = streetNumber;
                adress.City = city;
                adress.ZipCode = zipCode;
                //der instatieres customer klassen.
                Customer customer = new Customer(firstName, lastName, email, phone, adress, contactInfo);
                customer.CustomerID = customId;
                customer.LastOrder = lastOrder;
                customer.ContactInfo = contactInfo;
                //customer tilføjes til en ny liste vi har lavet i global list i database klassen.
                //customers liste bliver kaldt i progra,.cs klassen og sættes til listpage.
                customers.Add(customer);
            }
            //så bliver der lukket forbindelse til databasen for at gøre det muligt for at læse flere kunder fra databasen. 
            reader.Close();
            return customers;
        }
        public static int getInsertId()
        {
            SqlCommand cmd1 = new SqlCommand("SELECT SCOPE_IDENTITY() ", conn);
            var reader = cmd1.ExecuteReader();

            return reader.GetInt32(0);
        }
        public static void DeleteCustomer(Customer customer)
        {
            //int customerId = 0;
            
            string query1 = "DELETE FROM Customers where customerID = '" + customer.CustomerID + "'";
            
            SqlCommand cmd1 = new SqlCommand(query1, conn);

            try
            {
                cmd1.ExecuteNonQuery();
                //customerId = (int)cmd1.ExecuteScalar();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            //string query2 = "DELETE FROM ContactInfos where contactInfoID = '" + id + "'";
            
            //SqlCommand cmd2 = new SqlCommand(query2, conn);

            //try
            //{
            //    cmd2.ExecuteNonQuery();
                
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}

            //string query3 = "DELETE FROM Adress where adressID = '" + id + "'";

            //SqlCommand cmd3 = new SqlCommand(query3, conn);

            //try
            //{
            //    cmd3.ExecuteNonQuery();

            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}

            //string query4 = "DELETE FROM Persons where personID = '" + id + "'";

            //SqlCommand cmd4 = new SqlCommand(query4, conn);

            //try
            //{
            //    cmd4.ExecuteNonQuery();

            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}

            //finally
            //{
            //    //conn.Close();
            //}
            customers.Remove(customer);
        }

        //Insert Customer
        public static void InsertCustomer(Customer customer)
        {
            
            string query1 = @"INSERT INTO Persons(
	                    firstName,
	                    lastName,
	                    email,
	                    phone)
	                    values(@firstName, @lastName, @email, @phone)";
            int personId = 0;

            SqlCommand cmdId = null;
            SqlCommand cmd1 = new SqlCommand(query1, conn);

            cmd1.Parameters.AddWithValue("@firstName", customer.FirstName);
            cmd1.Parameters.AddWithValue("@lastName", customer.LastName);
            cmd1.Parameters.AddWithValue("@email", customer.Email);
            cmd1.Parameters.AddWithValue("@phone", customer.Phone);
            try
            {
                cmd1.ExecuteNonQuery();
                cmdId = new SqlCommand("SELECT dbo.persons.personID FROM dbo.Persons where dbo.Persons.email = '" + customer.Email + "' ", conn);
                
                personId = (int) cmdId.ExecuteScalar();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            string query2 = @"INSERT INTO Adress
	                    (street,
	                    streetNumber,
	                    city,
	                    zipCode)
	                    values(@street, @streetNumber, @city, @zipCode)";
            int adressId = 0;

            SqlCommand cmd2 = new SqlCommand(query2, conn);

            cmd2.Parameters.AddWithValue("@street", customer.Adress.Street);
            cmd2.Parameters.AddWithValue("@streetNumber", customer.Adress.Number);
            cmd2.Parameters.AddWithValue("@city", customer.Adress.City);
            cmd2.Parameters.AddWithValue("@zipCode", customer.Adress.ZipCode);
            try
            {
               cmd2.ExecuteNonQuery();
                cmdId = new SqlCommand(@"(SELECT dbo.Adress.adressID FROM dbo.Adress

                      where dbo.Adress.city = '" + customer.Adress.City + @"' AND

                         dbo.Adress.street = '" + customer.Adress.Street + @"' AND

                          dbo.Adress.streetNumber = '" + customer.Adress.Number + @"' AND

                          dbo.Adress.zipCode = '" + customer.Adress.ZipCode + @"')", conn);
                adressId = (int)cmdId.ExecuteScalar();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            string query3 = @"INSERT INTO ContactInfos
                    (value_)
                    values(@value)";
            int concactInfoId = 0;
            SqlCommand cmd3 = new SqlCommand(query3, conn);
            cmd3.Parameters.AddWithValue("@value", customer.ContactInfo.Value);
            try
            {
                cmd3.ExecuteNonQuery();
                cmdId = new SqlCommand("(SELECT dbo.ContactInfos.contactInfoID FROM ContactInfos where ContactInfos.value_ = '" + customer.ContactInfo.Value + @"');", conn);
                concactInfoId = (int)cmdId.ExecuteScalar();
            }
            catch(Exception ex)
            {
                Console.Write(ex.Message);
            }

            string query4 = @$"INSERT INTO Customers
                   (
                    lastOrder,
                    person_ID,
                    adress_ID,
                    contactInfo_ID)
                    values('2022-06-04 00:00:00.000',{personId},{adressId},{concactInfoId})";
                    

            //string query4 = @"INSERT INTO Customers
            //       (
            //        lastOrder,
            //        person_ID,
            //        adress_ID,
            //        contactInfo_ID)
            //        values(
            //        @lastOrder,
            //        (SELECT dbo.persons.personID FROM dbo.Persons where dbo.Persons.email = "+ customer.Email + @" ),
            //        (SELECT dbo.Adress.adressID FROM dbo.Adress

            //          where dbo.Adress.city = " + customer.Adress.City + @" AND

            //             dbo.Adress.street = " + customer.Adress.Street + @" AND

            //              dbo.Adress.streetNumber = " + customer.Adress.Number + @" AND

            //              dbo.Adress.zipCode = " + customer.Adress.ZipCode + @"),
            //        (SELECT dbo.ContactInfos.contactInfoID FROM ContactInfos where ContactInfos.value_ = " + customer.ContactInfo.Value + @"));";

            SqlCommand cmd4 = new SqlCommand(query4, conn);
            //cmd3.Parameters.AddWithValue("@customers.customerID", customer.CustomerID);
            //cmd4.Parameters.AddWithValue("@lastOrder", customer.LastOrder);
            
            //cmd4.Parameters.AddWithValue("@email", customer.Email);
            //cmd4.Parameters.AddWithValue("@street", customer.Adress.Street);
            //cmd4.Parameters.AddWithValue("@streetNumber", customer.Adress.Number);
            //cmd4.Parameters.AddWithValue("@city", customer.Adress.City);
            //cmd4.Parameters.AddWithValue("@zipCode", customer.Adress.ZipCode);
            //cmd4.Parameters.AddWithValue("@value", customer.ContactInfo.Value);
            //string time = "null";
            //if (customer.LastOrder > DateTime.MinValue)
            //{
            //    time = customer.LastOrder.ToString();
            //}

            try
            {   
                cmd4.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                Console.WriteLine();
            }
            finally
            {
                //conn.Close();   
            }

            customers.Add(customer);
        }

        //Update Customer by ID
        public static void UpdateCustomerByID(Customer customername, int id)
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
        public static void DeleteCustomerByID(Customer customername, int id)
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
=========

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

>>>>>>>>> Temporary merge branch 2
    }
}
