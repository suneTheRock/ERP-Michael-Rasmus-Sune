using ERPOpgave.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TECHCOOL.UI;

namespace ERPOpgave.GUI
{
    internal class CompanyMenu :Screen
	{// HOW TO MENU:
		public override string Title { get; set; } = "LNE Security A/S";
		public string CompanyName { get; set; } = "";
		public string Street { get; set; } = "";
		public string HouseNumber { get; set; } = "";
		public string PostalNumber { get; set; } = "";
		public string City { get; set; } = "";
		public string Country { get; set; } = "";
		public string Currency { get; set; } = "";

		public ListPage<Company> listPage = new ListPage<Company>();
		protected Company selected;

		// Creating a constructor so our listpage gets all the info it needs ONCE. Remove listPage.Add from Draw!!!
        public CompanyMenu()
        {
			//This is all a placeholder untill we get the database running
			listPage.Add(new Company("CoolShop", "Danmarksgade", "20", "9000", "Aalborg", "Danmark", "DDK"));
			listPage.Add(new Company("BigBooty A/S", "Bitches Street", "69", "6969", "Gotham", "Vatican City", "Altar Boys"));
			listPage.Add(new Company("LongSchlong A/S", "Bitches Street", "70", "6969", "Gotham", "Vatican City 2000", "Dogecoin"));
			listPage.Add(new Company("Huge Tracks of land", "Bitches Street", "69", "6969", "Gotham", "Vatican City+ Premium Edition", "Altar Thems"));
		}

		protected override void Draw()
		{
			Clear(this); //Keeping it Clean
			//Make a List Of that classtype
			//ListPage<Company> listPage = new ListPage<Company>();
			//Add all the things you want on that list, with a string to represent them on the menu screen.
		
			//We add a Column with (<A title taken from above> , <"The Variablename we gave them in their own class">)
			listPage.AddColumn("CompanyName", "CompanyName");
            listPage.AddColumn("Street", "Street");
			listPage.AddColumn("Housenumber", "HouseNumber");
			listPage.AddColumn("PostalNumber", "PostalNumber");
			listPage.AddColumn("City", "City");
			listPage.AddColumn("Country", "Country");
			listPage.AddColumn("Currency", "Currency");

            listPage.Draw();

            //Screen Prompt for our viewers to decide which of our options they want:
            Console.WriteLine("Tryk på F1 for at redigere en Virksomhed");
			Console.WriteLine("Tryk på F2 for at oprette en Virksomhed");
			Console.WriteLine("Tryk på F5 for at slette en Virksomhed");

			//Controller for which option is chosen, including an escape bool to fuckin leave
			bool loop = true;
			while (loop = true)
            {
				ConsoleKeyInfo info = Console.ReadKey();
				if (info.Key == ConsoleKey.F1)
				{
					//Edit Method with its own structure
					EditCompany();
				}
				if (info.Key == ConsoleKey.F2)
				{
					//Create Method with its own structure
					CreateNewCompanyToList();
				}
				if (info.Key == ConsoleKey.F5)
				{
					//Create Method with its own structure
					CreateNewCompanyToList();
				}
				if (info.Key == ConsoleKey.Escape)
				{
					//Escape to leave
					loop= false;
				}
			}
		}
		
		public void EditCompany()
        {
			Clear(); //Clean
			selected = listPage.Select(); //Choose what Company to Edit
			Clear(); //Clean Again

			//Screen Prompt:
			Console.WriteLine("Redigering af virksomhed oplysninger:");
			Console.WriteLine("-----------------------------");
			Console.WriteLine("Indtast Venligst virksomhedens oplysninger");

			//Run through each thing that needs to be edited in the employee 
			//These are showing wierd untill we make them parse the info into the right variable type
			Console.WriteLine("Navn: "); selected.CompanyName = Console.ReadLine();
            Console.WriteLine("Virksomhedens adresse: "); selected.Street = Console.ReadLine();
			Console.WriteLine("adresse nr: "); selected.HouseNumber = Console.ReadLine();
			Console.WriteLine("postnummer: "); selected.PostalNumber = Console.ReadLine();
			Console.WriteLine("By: "); selected.City = Console.ReadLine();
			Console.WriteLine("Land: "); selected.Country = Console.ReadLine();			
			Console.WriteLine("Valuta: "); selected.Currency = Console.ReadLine();
		}
		public void DeleteCompany()
		{
			Clear(); //Clean
			listPage.Remove(listPage.Select()); //Choose what Company to remove
			Clear(); //Clean Again
		}
		public void CreateNewCompanyToList()
        {
			Clear(); //Clean
			//Screen Prompt:
			Console.WriteLine("Opsætning af nye virksomhed");
			Console.WriteLine("-----------------------------");
			Console.WriteLine("Indtast Venligst virksomhedens oplysninger");
			//Run through each variable needed to create a new company
			Console.WriteLine("Navn: "); var name = Console.ReadLine();
			Console.WriteLine("Virksomhedens adresse: "); var companyStreet = Console.ReadLine();
			Console.WriteLine("adresse nr: "); var companyStreetNumber = Console.ReadLine();
			Console.WriteLine("postnummer: "); var postNumber = Console.ReadLine();
			Console.WriteLine("By: "); var companyCity = Console.ReadLine();
			Console.WriteLine("Land: "); var companyCountry = Console.ReadLine();
			Console.WriteLine("Valuta: "); var companyCurrency = Console.ReadLine();

			// .Add to create a new company
			listPage.Add(new Company(name, companyStreet, companyStreetNumber, postNumber, companyCity, companyCountry, companyCurrency));
		}
	}

}
