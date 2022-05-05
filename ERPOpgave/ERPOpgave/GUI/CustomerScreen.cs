using ERPOpgave.Models;
using ERPOpgave.PersonalInfo;
using ERPOpgave.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TECHCOOL.UI;

namespace ERPOpgave.GUI
{
    internal class CustomerScreen : Screen
    {
		public ListPage<Customer> listPage = new ListPage<Customer>();
		protected Customer selected;
		public Adress adress;
		
		
		public override string Title { get; set; } = "LNE Security A/S";
		public string CustomerNumber { get; set; } = "Kundenummer";
		public string Name { get; set; } = "Navn";
		public string EfterNavn { get; set; } = "Efternavn";
		public string Phonenumber { get; set; } = "TelefonNummer";
		public string Email { get; set; } = "E-Mail";

		public string adresse { get; set; } = "Adresse";

		public string LastOrderDate { get; set; } = "Dato for sidste køb";

		

		public CustomerScreen()
        {
			//Call Customer dummies method to create users for Test.
			//CustomerDummies();
			
		}

		public void CustomerDummies()
        {
			//Add all the things you want on that list, with a string to represent them on the menu screen.
			//listPage.Add(new Customer(1, "Mailadress1@dot.com", "Tom", "Jerrison", 29292929));
			//listPage.Add(new Customer(2, "Mailadress2@dot.com", "Ben", "Jerrison", 292992929));
			//listPage.Add(new Customer(3, "Mailadress3@dot.com", "Jerry", "Tommison", 88888888));
			
	//listPage.Add(new Customer(1, "sune", "bech", "sune401@hotmail.dk", 23123321, "forsend", 999, 200, "svvcc"));
		}
		protected override void Draw()
		{
			Clear(this);
			//Make a Class to host our screen elements.
			//Make a List Of that classtype
			
			
			
			//We add a Column with (<A title taken from above> , <"The Variablename we gave them in their own class">)
			listPage = new ListPage<Customer>();
			listPage.Add(Database.GetAllCustomers());
			listPage.AddColumn(CustomerNumber, "CustomerID");
			listPage.AddColumn(Name, "FirstName");
			listPage.AddColumn(EfterNavn, "LastName");
			listPage.AddColumn(Phonenumber, "Phone");
			listPage.AddColumn(Email, "Email");
			listPage.AddColumn(LastOrderDate.ToString(), "LastOrder");
			
			//Draw to see this printed out
			listPage.Draw();

			//Screen Prompt for our viewers to decide which of the two
			Console.WriteLine("Tryk på F1 for at redigere en kunde");
			Console.WriteLine("Tryk på F2 for at oprette en kunde");
			Console.WriteLine("Tryk på F5 for at kunde detalje");
			Console.WriteLine("Tryk på F6 for at finde kunde via kundenummer");
			Console.WriteLine("Tryk på F7 for at slette en eksisterende kunde i systemet");
			//CustomerScreen customerScreen = new CustomerScreen();

			bool loop = true;
			while (loop)
            {
				ConsoleKeyInfo info = Console.ReadKey();

				//Screen options 1 and 2, this doesnt work here, we need a proper menu to control this
				if (info.Key == ConsoleKey.F1)
				{
					//den sørger for at den ikke crasher når der er ingen kunde(r) på listen.
					try
					{
						this.EditCustomer();
					}
					catch (ArgumentOutOfRangeException ex)
                    {
						Console.WriteLine("Kan ikke redigere en kunde, da der er ingen kunde i systemet");
						Console.ReadLine();
                        
						Draw();
                        
						
                    }
					
					
				}
				if (info.Key == ConsoleKey.F2)
				{
					this.AddCustomerToList();
				}
				if(info.Key == ConsoleKey.F5)
                {
					//den sørger for at den ikke crasher når der er ingen kunde(r) på listen.
					try
					{

						this.ShowDetailsOfcustomerFromList();
					}
					catch (ArgumentOutOfRangeException ex)
					{
						Console.WriteLine("Kan ikke vise kundeoplysninger, da der er ingen kunde i systemet");
						Console.ReadLine();

						Draw();
					}
				}

				//tilbage til Hovedmenuen
				if(info.Key == ConsoleKey.F4)
				{
					Clear();
					Draw();
                }

				if(info.Key == ConsoleKey.F6)
                {
					Clear();
					Console.WriteLine("Venligst indtast Kundenummer for at finde kunde ");
					
					findCustomerById();
                    
				}
				if(info.Key == ConsoleKey.F7)
                {
					deleteCustomerById();
                }
				if(info.Key == ConsoleKey.Escape)
                {
					loop = false;
                }

				//Draw to see this printed out // Or Select as was later added
				//selected = listPage.Select();
			}

		}

		public void EditCustomer()
        {
			
			Clear();

			selected = listPage.Select();
			Clear();
			//Screen Prompt:
			Console.WriteLine("Redigering af kundens oplysninger:");
			Console.WriteLine("-----------------------------");
			Console.WriteLine("Indtast Venligst kundens oplysninger");

			try
            {
				Console.WriteLine("Kundens fornavn: "); selected.FirstName = Console.ReadLine();
				Console.WriteLine("Kundens efternavn: "); selected.LastName = Console.ReadLine();
				Console.WriteLine("Email "); selected.Email = Console.ReadLine();
				Console.WriteLine("Tlf nr: "); selected.Phone = Convert.ToString(Console.ReadLine());
				Console.WriteLine("Adresse: "); selected.Adress.Street = Console.ReadLine();
				Console.WriteLine("adresse nr: "); selected.Adress.Number = Convert.ToInt32(Console.ReadLine());
				Console.WriteLine("By: "); selected.Adress.City = Console.ReadLine();
				Console.WriteLine("Postnummer: "); selected.Adress.ZipCode = Convert.ToInt32(Console.ReadLine());


			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}

			Draw();

			//Run through each thing that needs to be edited in the employee
			
			//listPage.
			//This isn't going to work, I need to figure out how to target the selected company for its own edit.
			
		}

		public void ShowDetailsOfcustomerFromList()
        {
			Clear();
			selected = listPage.Select();
			Clear();
			Console.WriteLine("Kundens Detalje ");
			Console.WriteLine("																				Tryk F4 for at gå tilbage til Menuen");
			Console.WriteLine("-------------------------------------------------------------------------------------------------------------------");
			Console.WriteLine("Navn: " + selected.FirstName);
			Console.WriteLine("Efternavn: " + selected.LastName);
			Console.WriteLine("Adresse: " + selected.Adress.Street);
			Console.WriteLine("Husnummer: " + selected.Adress.Number);
			Console.WriteLine("Postnummer: " + selected.Adress.ZipCode);
			Console.WriteLine("By: " + selected.Adress.City);
			Console.WriteLine("Telefonnummer: " + selected.Phone);
			Console.WriteLine("Email: " + selected.Email);
		}

		public void findCustomerById()
        {

			Clear();
			Console.WriteLine("Kundens Detalje ");
			Console.WriteLine("																				Tryk F4 for at gå tilbage til Menuen");
			Console.WriteLine("-------------------------------------------------------------------------------------------------------------------");
			var input = Console.ReadLine();
			Database.GetCustomerByID(Convert.ToInt32(input));
			Console.WriteLine("Navn: " + selected.FirstName);
			Console.WriteLine("Efternavn: " + selected.LastName);
			Console.WriteLine("Adresse: " + selected.Adress.Street);
			Console.WriteLine("Husnummer: " + selected.Adress.Number);
			Console.WriteLine("Postnummer: " + selected.Adress.ZipCode);
			Console.WriteLine("By: " + selected.Adress.City);
			Console.WriteLine("Telefonnummer: " + selected.Phone);
			Console.WriteLine("Email: " + selected.Email);
		}

		public void AddCustomerToList()
		{
			
			Clear();

			try
            {
				Console.WriteLine("Opsætning af nye kundeoplysning");
				Console.WriteLine("-----------------------------");
				Console.WriteLine("Indtast Venligst kundens oplysninger");
				//Run through each variable needed to create a new Customer
				//Console.WriteLine("Kundenummer: "); var kundeNummer = Convert.ToInt32(Console.ReadLine());
				Console.WriteLine("Kundens fornavn: "); var fornavn = Console.ReadLine();
				Console.WriteLine("Kundens efternavn: "); var efterNavn = Console.ReadLine();
				Console.WriteLine("Email: "); var email = Console.ReadLine();
				Console.WriteLine("Tlf nr: "); var tlfNr = Convert.ToString(Console.ReadLine());
				Console.WriteLine("Adresse: "); var adressen = Console.ReadLine();
				Console.WriteLine("Adresse nr: "); var adresseNr = Convert.ToInt32(Console.ReadLine());
				Console.WriteLine("By: "); var by = Console.ReadLine();
				Console.WriteLine("Postnummer: "); var postnummer = Convert.ToInt32(Console.ReadLine());
				Console.WriteLine("værdien : "); var value = Convert.ToInt32(Console.ReadLine());


				Adress adr = new Adress(by,adresseNr,adressen, postnummer);
				ContactInfo contactInfo = new ContactInfo(value);
				Customer cs = new Customer(fornavn, efterNavn, email, tlfNr, adr, contactInfo);
				Database.InsertCustomer(cs);
				
				
				
				

			}
			catch (Exception ex)
            {
				Console.WriteLine(ex.Message);
            }

			//Screen Prompt:

			// .Add to create a new company
			//listPage.Add(new Customer(adresse, kontaktInfo, email, fornavn, efterNavn, tlfNr, by, postnummer, kontaktInfo, valuta));
			//listPage.Add(new Customer(name, companyStreet, companyStreetNumber, postNumber, companyCity, companyCountry, companyCurrency));

			// tilbage til listen
			Database.GetAllCustomers();
			Draw();

		}

		public void deleteCustomerById()
        {
			Clear();
			Console.WriteLine("venligst indtaste kundenummer for at slette kunden");
			Console.ReadLine();
			Console.WriteLine("																				Tryk F4 for at gå tilbage til Menuen");
			Console.WriteLine("-------------------------------------------------------------------------------------------------------------------");
		}

		
	}

		
	
}
