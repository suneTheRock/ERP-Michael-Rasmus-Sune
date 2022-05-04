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
		public string Unittype { get; set; } = "unittype";

		public string Location { get; set; } = "Location";
		public string ProfitMargin { get; set; } = "Profit Margin";



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
		}
		protected override void Draw()
		{
			Clear(this);
			//Make a Class to host our screen elements.
			//Make a List Of that classtype



			//We add a Column with (<A title taken from above> , <"The Variablename we gave them in their own class">)
			listPage.AddColumn(ProductNumber, "ProductId");
            listPage.AddColumn(Name, "Name");
            //listPage.AddColumn(Description, "Description");
            listPage.AddColumn(CostPrice, "Costprice");
            listPage.AddColumn(SalesPrice, "Salesprice");
			//listPage.AddColumn(Location,"Location");
			listPage.AddColumn(Stock, "Stock");
			//listPage.AddColumn(Unittype, "Unittype");
			listPage.AddColumn(ProfitMargin, "tempBeans");

			//Draw to see this printed out
			listPage.Draw();

			//Screen Prompt for our viewers to decide which of the three
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
			Product.UnitType tempUnitType = 0;

			Clear();
			selected = listPage.Select();
			Clear();
			//Screen Prompt:
			Console.WriteLine("Redigering af produktets oplysninger:");
			Console.WriteLine("-----------------------------");
			Console.WriteLine("Indtast Venligst produktets oplysninger");

			try
			{
                Console.WriteLine("Produkt ID: "); selected.ItemNumber = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Product navn: "); selected.Name = Console.ReadLine();
                Console.WriteLine("Produkt beskrivelse: "); selected.Description = Console.ReadLine();
                Console.WriteLine("Købspris: "); selected.Costprice = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Salgspris: "); selected.Salesprice = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Lokation: "); selected.Location = Console.ReadLine();
                Console.WriteLine("På lager: "); selected.Stock = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enhedstype : "); Enum.TryParse(Console.ReadLine(), out tempUnitType);
                 selected.Unittype = tempUnitType; 
					


            }
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}

			Draw();

			//Run through each thing that needs to be edited in the product


		}

        public void ShowDetailsOfproductFromList()
        {
            Clear();
            selected = listPage.Select();
            Clear();
            Console.WriteLine("Produktets detaljer");
            Console.WriteLine("																				Tryk Esc + Enter for at gå tilbage til Menuen");
            Console.WriteLine("-------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("Produkt ID: " + selected.ProductId);
            Console.WriteLine("Navn: " + selected.Name);
            Console.WriteLine("Beskrivelse: " + selected.Description);
            Console.WriteLine("Købspris: " + selected.Costprice);
            Console.WriteLine("Salgspris: " + selected.Salesprice);
            Console.WriteLine("Lokation: " + selected.Location);
            Console.WriteLine("På lager: " + selected.Stock);
            Console.WriteLine("Enhedstype: " + selected.Unittype);


			Console.ReadLine();
			Draw();

			
        }

		public void AddProductToList()
		{

			Clear();

			try
			{
				Console.WriteLine("Opsætning af nye produkt oplysninger");
				Console.WriteLine("-----------------------------");
				Console.WriteLine("Indtast venligst produktets oplysninger");
				//Run through each variable needed to create a new Product
				Console.WriteLine("ProduktID: "); var produktID = Convert.ToInt32(Console.ReadLine());
				Console.WriteLine("Navn: "); var navn = Console.ReadLine();
				Console.WriteLine("Beskrivelse: "); var beskrivelse = Console.ReadLine();
				Console.WriteLine("købspris: "); var købspris = Convert.ToInt32(Console.ReadLine());
				Console.WriteLine("Salgspris: "); var salgspris = Convert.ToInt32(Console.ReadLine());
				Console.WriteLine("Lokation: "); var lokation = (Console.ReadLine());
				Console.WriteLine("På lager: "); var lager = Convert.ToInt32(Console.ReadLine());
				Console.WriteLine("Enhedstype: "); Enum.TryParse<Product.UnitType>(Console.ReadLine(), ignoreCase: true, out var enhedsType);


				listPage.Add(new Product(produktID,navn,beskrivelse,købspris,salgspris,lokation,lager,enhedsType));


			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
			Draw();

		}


	}



}