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
        public CompanyMenu()
        {
			this.populateList();
		}
		protected void populateList()
        {
            listPage.Add(new Company("CoolShop", "Danmarksgade", "20", "9000", "Aalborg", "Danmark", "DDK"));
            listPage.Add(new Company("BigBooty A/S", "Bitches Street", "69", "6969", "Gotham", "Vatican City", "Altar Boys"));
            listPage.Add(new Company("LongSchlong A/S", "Bitches Street", "70", "6969", "Gotham", "Vatican City 2000", "Dogecoin"));
            listPage.Add(new Company("Huge Tracks of land", "Bitches Street", "69", "6969", "Gotham", "Vatican City+ Premium Edition", "Altar Thems"));
        }

		protected override void Draw()
		{
			Clear(this);
		//Make a Class to host our screen elements.
		//Make a List Of that classtype
		//ListPage<Company> listPage = new ListPage<Company>();

		//Add all the things you want on that list, with a string to represent them on the menu screen.
		//This is all a placeholder untill we get the database running
		//listPage.Add(new Company("CoolShop", "Danmarksgade", "20", "9000", "Aalborg", "Danmark", "DDK"));
		//listPage.Add(new Company("BigBooty A/S", "Bitches Street", "69", "6969", "Gotham", "Vatican City", "Altar Boys"));
		//listPage.Add(new Company("LongSchlong A/S", "Bitches Street", "70", "6969", "Gotham", "Vatican City 2000", "Dogecoin"));
		//listPage.Add(new Company("Huge Tracks of land", "Bitches Street", "69", "6969", "Gotham", "Vatican City+ Premium Edition", "Altar Thems"));

		//We add a Column with (<A title taken from above> , <"The Variablename we gave them in their own class">)
		listPage.AddColumn("CompanyName", "CompanyName");
            listPage.AddColumn("Street", "Street");
			listPage.AddColumn("Housenumber", "HouseNumber");
			listPage.AddColumn("PostalNumber", "PostalNumber");
			listPage.AddColumn("City", "City");
			listPage.AddColumn("Country", "Country");
			listPage.AddColumn("Currency", "Currency");

			
		listPage.Draw();
			//Screen Prompt for our viewers to decide which of the two
			Console.WriteLine("Tryk på 1 for at redigere en Virksomhed");
			Console.WriteLine("Tryk på 2 for at oprette en Virksomhed");
			ConsoleKeyInfo info = Console.ReadKey();

			//Screen options 1 and 2, this doesnt work here, we need a proper menu to control this
			if (info.Key == ConsoleKey.F1)
			{
				//CompanyMenu companyMenu = new CompanyMenu();
				this.EditCompany();
			}
			if (info.Key == ConsoleKey.NumPad2)
			{
				CompanyMenu companyMenu = new CompanyMenu();
				companyMenu.CreateNewCompanyToList();
			}

			//Draw to see this printed out // Or Select as was later added
			//selected = listPage.Select();
		}
		
		public void EditCompany()
        {
			selected = listPage.Select();
			Clear();
			//Screen Prompt:
            Console.WriteLine("Redigering af virksomhed oplysninger:");
			Console.WriteLine("-----------------------------");
			Console.WriteLine("Indtast Venligst virksomhedens oplysninger");

			//Run through each thing that needs to be edited in the employee
			Console.WriteLine("Navn: "); selected.CompanyName = Console.ReadLine();
            Console.WriteLine("Virksomhedens adresse: "); selected.Street = Console.ReadLine();
			Console.WriteLine("adresse nr: "); selected.HouseNumber = Console.ReadLine();
			Console.WriteLine("postnummer: "); selected.PostalNumber = Console.ReadLine();
			Console.WriteLine("By: "); selected.City = Console.ReadLine();
			Console.WriteLine("Land: "); selected.Country = Console.ReadLine();			
			Console.WriteLine("Valuta: "); selected.Currency = Console.ReadLine();

			//listPage.
			//This isn't going to work, I need to figure out how to target the selected company for its own edit.
			//listPage.Select() = new Company(name, companyStreet, companyStreetNumber, postNumber, companyCity, companyCountry, companyCurrency)
		}
		public void CreateNewCompanyToList()
        {
			Clear();
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

			// tilbage til listen
			Draw();
		}
	}

}
