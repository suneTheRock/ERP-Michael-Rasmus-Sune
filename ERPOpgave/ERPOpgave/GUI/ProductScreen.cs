using ERPOpgave.Models;
using ERPOpgave.PersonalInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TECHCOOL.UI;

namespace ERPOpgave.GUI
{
	internal class ProductScreen : Screen
	{
		public ListPage<Product> listPage = new ListPage<Product>();
		protected Product selected;


		public override string Title { get; set; } = "LNE Security A/S";
		public string ProductNumber { get; set; } = "Produkt ID";
		public string Name { get; set; } = "Navn";
		public string Description { get; set; } = "Beskrivelse";
		public string CostPrice { get; set; } = "Købspris";

		public string SalesPrice { get; set; } = "Salgspris";

		public string Stock { get; set; } = "På lager";
		public string UnitType { get; set; } = "Enhedstype";



		public ProductScreen()
		{
			//Call Product dummies method to create users for Test.
			ProductDummies();
		}

		public void ProductDummies()
		{
			//Add all the things you want on that list, with a string to represent them on the menu screen.
			listPage.Add(new Product(1, "Skrue", "Dette er en skrue", 20, 80, "1222", 200, Product.UnitType.Pieces));
			listPage.Add(new Product(2, "Bor", "Dette er et bor", 19, 90, "1233", 180, Product.UnitType.Hours));
			listPage.Add(new Product(3, "Bord", "Dette er et bord", 2, 120, "1256", 500, Product.UnitType.Meters));
			//listPage.Add(new Product(1, "sune", "bech", "sune401@hotmail.dk", 23123321, "forsend", 999, 200, "svvcc"));
		}
		protected override void Draw()
		{
			Clear(this);
			//Make a Class to host our screen elements.
			//Make a List Of that classtype



			//We add a Column with (<A title taken from above> , <"The Variablename we gave them in their own class">)
			listPage.AddColumn(ProductNumber, "Produkt ID");
			listPage.AddColumn(Name, "Navn");
			listPage.AddColumn(Description, "Beskrivelse");
			listPage.AddColumn(CostPrice, "Købspris");
			listPage.AddColumn(SalesPrice, "Salgspris");

			//Draw to see this printed out
			listPage.Draw();

			//Screen Prompt for our viewers to decide which of the two
			Console.WriteLine("Tryk på F1 for at redigere en kunde");
			Console.WriteLine("Tryk på F2 for at oprette en kunde");
			Console.WriteLine("Tryk på F5 for at kunde detalje");

			bool loop = true;
			while (loop)
			{
				ConsoleKeyInfo info = Console.ReadKey();

				//Screen options 1 and 2, this doesnt work here, we need a proper menu to control this
				if (info.Key == ConsoleKey.F1)
				{
					//CustommerScreen productScreen = new ProductScreen();
					this.EditProduct();
				}
				if (info.Key == ConsoleKey.F2)
				{
					ProductScreen productScreen = new ProductScreen();
					productScreen.AddProductToList();
				}
				if (info.Key == ConsoleKey.F5)
				{
					this.ShowDetailsOfproductFromList();

				}
				if (info.Key == ConsoleKey.Escape)
				{
					loop = false;
				}

				//Draw to see this printed out // Or Select as was later added
				//selected = listPage.Select();
			}

		}

		public void EditProduct()
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
				Console.WriteLine("Produkt ID: "); selected.ItemNumber = Convert.ToInt32(Console.ReadLine());
				Console.WriteLine("Product navn: "); selected.Name = Console.ReadLine();
				Console.WriteLine("Produkt beskrivelse: "); selected.Description = Console.ReadLine();
				Console.WriteLine("Købspris: "); selected.Costprice =Convert.ToInt32(Console.ReadLine());
				Console.WriteLine("Salgspris: "); selected.Salesprice = Convert.ToInt32(Console.ReadLine());
				Console.WriteLine("Lokation: "); selected.Location = Console.ReadLine();
				Console.WriteLine("På lager: "); selected.Stock = Convert.ToInt32(Console.ReadLine());
				//Console.WriteLine("Enhedstype : "); selected.Unittype = (Console.ReadLine());


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

        public void ShowDetailsOfproductFromList()
        {
            Clear();
            selected = listPage.Select();
            Clear();
            Console.WriteLine("Kundens Detalje ");
            Console.WriteLine("																				Tryk Esc + Enter for at gå tilbage til Menuen");
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

		public void AddProductToList()
		{
			Clear();

			try
			{
				Console.WriteLine("Opsætning af nye kundeoplysning");
				Console.WriteLine("-----------------------------");
				Console.WriteLine("Indtast Venligst kundens oplysninger");
				//Run through each variable needed to create a new Product
				Console.WriteLine("Kundenummer: "); var kundeNummer = Convert.ToInt32(Console.ReadLine());
				Console.WriteLine("Kundens fornavn: "); var fornavn = Console.ReadLine();
				Console.WriteLine("Kundens efternavn: "); var efterNavn = Console.ReadLine();
				Console.WriteLine("Email: "); var email = Console.ReadLine();
				Console.WriteLine("Tlf nr: "); var tlfNr = Convert.ToInt32(Console.ReadLine());
				Console.WriteLine("Adresse: "); var adressen = Console.ReadLine();
				Console.WriteLine("Adresse nr: "); var adresseNr = Convert.ToInt32(Console.ReadLine());
				Console.WriteLine("By: "); var by = Console.ReadLine();
				Console.WriteLine("Postnummer: "); var postnummer = Convert.ToInt32(Console.ReadLine());

				Adress adr = new Adress(by, adresseNr, adressen, postnummer);
				listPage.Add(new Product(kundeNummer, fornavn, efterNavn, email, tlfNr, adr));


			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}

			//Screen Prompt:

			// .Add to create a new company
			//listPage.Add(new Product(adresse, kontaktInfo, email, fornavn, efterNavn, tlfNr, by, postnummer, kontaktInfo, valuta));
			//listPage.Add(new Product(name, companyStreet, companyStreetNumber, postNumber, companyCity, companyCountry, companyCurrency));

			// tilbage til listen
			Draw();

		}


	}



}