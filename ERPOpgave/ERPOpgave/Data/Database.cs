using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        //private static Database Instance { get; set; }
        static Person person = new Person();
        static SqlConnection conn = null;
        public static void Init() 
        {
            //Instance = new Database();
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = "docker.data.techcollege.dk";
            builder.UserID = "H1PD021122_Gruppe2";
            builder.Password = "H1PD021122_Gruppe2";
            conn = new SqlConnection(builder.ConnectionString);
            conn.Open();
            
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
                int phone = reader.GetInt32(6);
                int adressId = reader.GetInt32(7);
                string street = reader.GetString(8);
                int streetNumber = reader.GetInt32(9);
                string city = reader.GetString(10);
                int zipCode = reader.GetInt32(11);
                int contactInfoId = reader.GetInt32(12);
                int contactInfoValue = reader.GetInt32(13);

                //de objekterne der bliver lavet, sættes til til hver klassens properties.
                ContactInfo contactInfo = new ContactInfo();
                contactInfo.ContactInfoID = contactInfoId;
                contactInfo.Value = contactInfoValue;

                Adress adress = new Adress();
                adress.Street = street;
                adress.Number = streetNumber;
                adress.City = city;
                adress.ZipCode = zipCode;

                customer = new Customer(customId, firstName, lastName, email, phone, adress);
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
                int phone = reader.GetInt32(6);
                int adressId = reader.GetInt32(7);
                string street = reader.GetString(8);
                int streetNumber = reader.GetInt32(9);
                string city = reader.GetString(10);
                int zipCode = reader.GetInt32(11);
                int contactInfoId = reader.GetInt32(12);
                int contactInfoValue = reader.GetInt32(13);

                //de objekterne der bliver lavet, sættes til til hver klassens properties.
                ContactInfo contactInfo = new ContactInfo();
                contactInfo.ContactInfoID = contactInfoId;
                contactInfo.Value = contactInfoValue;
                
                Adress adress = new Adress();
                adress.Street = street;
                adress.Number = streetNumber;
                adress.City = city;
                adress.ZipCode = zipCode;
                //der instatieres customer klassen.
                Customer customer = new Customer(customId, firstName, lastName, email, phone, adress);
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

        //Insert Customer
        public static void InsertCustomer(Customer customer)
        {
            string query1 = @"INSERT INTO persons(
	                    Persons.firstName,
	                    Persons.lastName,
	                    Persons.email,
	                    Persons.phone)
	                    values(@persons.firstName, @persons.lastName, @persons.email, @persons.phone)";
            
            SqlCommand cmd1 = new SqlCommand(query1, conn);

            cmd1.Parameters.AddWithValue("@persons.firstName", person.FirstName);
            cmd1.Parameters.AddWithValue("@persons.lastName", person.LastName);
            cmd1.Parameters.AddWithValue("@persons.email", person.Email);
            cmd1.Parameters.AddWithValue("@persons.phone", person.Phone);
            try
            {
                cmd1.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            string query2 = @"INSERT INTO Adress
	                    (Adress.street,
	                    Adress.streetNumber,
	                    Adress.city,
	                    Adress.zipCode)
	                    values(@Adress.street, @Adress.streetNumber, @Adress.city, @Adress.zipCode)";

            SqlCommand cmd2 = new SqlCommand(query2, conn);

            cmd2.Parameters.AddWithValue("@Adress.street", customer.Adress.Street);
            cmd2.Parameters.AddWithValue("@Adress.streetNumber", customer.Adress.Number);
            cmd2.Parameters.AddWithValue("@Adress.city", customer.Adress.City);
            cmd2.Parameters.AddWithValue("@Adress.zipCode", customer.Adress.ZipCode);
            try
            {
                cmd2.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            string query3 = @"INSERT INTO Customers
                    (customers.lastOrder,
                    customer.person_ID,
                    customers.adress_ID,
                    customers.contactInfo_ID)
                    values(
                    '2022-06-04 00:00:00.000',
                    (SELECT persons.personID FROM Persons where persons.email = 'peter@hotmailcom'),
                    (SELECT dbo.Adress.adressID FROM dbo.Adress

                        where dbo.Adress.city = 'købehavn' AND

                            Adress.street = 'nytorvet' AND

                            Adress.streetNumber = 12 AND

                            Adress.zipCode = 7322),
                    (SELECT ContactInfos.contactInfoID FROM ContactInfos where ContactInfos.value_ = 900))";

            SqlCommand cmd3 = new SqlCommand(query3, conn);

            cmd3.Parameters.AddWithValue("@customers.lastOrder", customer.LastOrder);
            cmd3.Parameters.AddWithValue("@customers.@SELECT persons.personID FROM Persons where persons.email =", customer.Email);
            cmd3.Parameters.AddWithValue("@SELECT dbo.Adress.adressID FROM dbo.Adress where dbo.Adress.city =",customer.Adress.City);
            
            try
            {
                cmd3.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                Console.WriteLine();
            }
            finally
            {
                conn.Close();   
            }

            customers.Add(customer);
        }

        //Update Customer by ID
        public static void UpdateCustomerByID(Customer customername, int id)
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
        public static void DeleteCustomerByID(Customer customername, int id)
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
