﻿using ERPOpgave.Models;
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
		public override string Title { get; set; } = "LNE Security A/S";
		public string CustomerNumber { get; set; } = "Kundenummer";
		public string Name { get; set; } = "Navn";
		public string Phonenumber { get; set; } = "TelefonNummer";
		public string Email { get; set; } = "E-Mail";

		public string LastOrderDate { get; set; } = "Dato for sidste køb";

		public CustomerScreen()
        {
			CustomerDummies();
        }

		public void CustomerDummies()
        {
			//Add all the things you want on that list, with a string to represent them on the menu screen.
			listPage.Add(new Customer(1, "Mailadress1@dot.com", "Tom", "Jerrison", 29292929));
			listPage.Add(new Customer(2, "Mailadress2@dot.com", "Ben", "Jerrison", 292992929));
			listPage.Add(new Customer(3, "Mailadress3@dot.com", "Jerry", "Tommison", 88888888));
		}
		protected override void Draw()
		{
			Clear(this);
			//Make a Class to host our screen elements.
			//Make a List Of that classtype
			
			
			
			//We add a Column with (<A title taken from above> , <"The Variablename we gave them in their own class">)
			listPage.AddColumn(CustomerNumber, "CustomerID");
			listPage.AddColumn(Name, "FullName");
			listPage.AddColumn(Phonenumber, "Phone");
			listPage.AddColumn(Email, "Email");
			listPage.AddColumn(LastOrderDate.ToString(), "LastOrder");

			//Draw to see this printed out
			listPage.Draw();

			//Screen Prompt for our viewers to decide which of the two
			Console.WriteLine("Tryk på 1 for at redigere en Virksomhed");
			Console.WriteLine("Tryk på 2 for at oprette en Virksomhed");
			ConsoleKeyInfo info = Console.ReadKey();

			//Screen options 1 and 2, this doesnt work here, we need a proper menu to control this
			if (info.Key == ConsoleKey.NumPad1)
			{
				//CompanyMenu companyMenu = new CompanyMenu();
				this.EditCustomer();
			}
			if (info.Key == ConsoleKey.NumPad2)
			{
				CustomerScreen customerScreen = new CustomerScreen();
				customerScreen.AddCustomerToList();
			}

			//Draw to see this printed out // Or Select as was later added
			//selected = listPage.Select();
		}

		public void EditCustomer()
        {
			selected = listPage.Select();
			Clear();
			//Screen Prompt:
			Console.WriteLine("Redigering af kundens oplysninger:");
			Console.WriteLine("-----------------------------");
			Console.WriteLine("Indtast Venligst kundens oplysninger");

			//Run through each thing that needs to be edited in the employee
			Console.WriteLine("Kundenummer: "); selected.CustomerID = Convert.ToInt32(Console.ReadLine());
			Console.WriteLine("Kundens fornavn: "); selected.FirstName = Console.ReadLine();
			Console.WriteLine("Kundens efternavn: "); selected.LastName = Console.ReadLine();
			Console.WriteLine("Email "); selected.Email = Console.ReadLine();
			Console.WriteLine("Tlf nr: "); selected.Phone = Convert.ToInt32(Console.ReadLine());
			Console.WriteLine("Adresse: "); selected.Adress.Street = Console.ReadLine();
			Console.WriteLine("adresse nr: "); selected.Adress.Number = Convert.ToInt32(Console.ReadLine());
			Console.WriteLine("By: "); selected.Adress.City = Console.ReadLine();
			Console.WriteLine("Postnummer: "); selected.Adress.ZipCode = Convert.ToInt32(Console.ReadLine());
			
			


			//listPage.
			//This isn't going to work, I need to figure out how to target the selected company for its own edit.
			//listPage.Select() = new Company(name, companyStreet, companyStreetNumber, postNumber, companyCity, companyCountry, companyCurrency)
		}

		public void AddCustomerToList()
		{

			Clear();
			//Screen Prompt:
			Console.WriteLine("Opsætning af nye virksomhed");
			Console.WriteLine("-----------------------------");
			Console.WriteLine("Indtast Venligst virksomhedens oplysninger");
			//Run through each variable needed to create a new company
			Console.WriteLine("Kundenummer: "); var kundeNummer = Convert.ToInt32(Console.ReadLine());
			Console.WriteLine("Kundens fornavn: "); var fornavn = Console.ReadLine();
			Console.WriteLine("Kundens efternavn: "); var efterNavn = Console.ReadLine();
			Console.WriteLine("Email: "); var email = Console.ReadLine();
			Console.WriteLine("Tlf nr: "); var tlfNr = Convert.ToInt32(Console.ReadLine());
			Console.WriteLine("Adresse: "); var adresse = Console.ReadLine();
			Console.WriteLine("Adresse nr: "); var adresseNr = Convert.ToInt32(Console.ReadLine());
			Console.WriteLine("By: "); var by = Console.ReadLine();
			Console.WriteLine("Postnummer: "); var postnummer = Convert.ToInt32(Console.ReadLine());

			listPage.Add(new Customer(kundeNummer, fornavn, efterNavn, email, tlfNr, adresse, adresseNr, postnummer, by));



			// .Add to create a new company
			//listPage.Add(new Customer(adresse, kontaktInfo, email, fornavn, efterNavn, tlfNr, by, postnummer, kontaktInfo, valuta));
			//listPage.Add(new Customer(name, companyStreet, companyStreetNumber, postNumber, companyCity, companyCountry, companyCurrency));

			// tilbage til listen
			Draw();

		}
	}

		
	
}