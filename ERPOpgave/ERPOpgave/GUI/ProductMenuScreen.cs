using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TECHCOOL.UI;
using ERPOpgave.Products;

namespace ERPOpgave.GUI
{
    internal class ProductMenuScreen : Screen
    {
        public override string Title { get; set; } = "LINE Security A/S";
        public string ItemNumber = "Varenummer";
        public string Name = "Navn";
        public string Stock = "Lagerantal";
        public string Costprice = "Indkøbspris";
        public string SalesPrice = "Salgspris";
        public string AvancePercent = "Avance i procent";

        protected Product selected;

        protected override void Draw()
        {
            Clear(this);
            //Make a Class to host our screen elements.
            //Make a List Of that classtype
            ListPage<Product> listPage = new ListPage<Product>();
            //Add all the things you want on that list, with a string to represent them on the menu screen.
            listPage.Add(new Product(1,"Skrue", "Dette er en skrue", 20, 80, "1222", 200, Product.UnitType.Pieces));
            listPage.Add(new Product(2, "Bor", "Dette er et bor", 19, 90, "1233", 180, Product.UnitType.Hours));
            listPage.Add(new Product(3, "Bord", "Dette er et bord", 2, 120, "1256", 500, Product.UnitType.Meters));
            //We add a Column with (<A title taken from above> , <"The Variablename we gave them in their own class">)
            listPage.AddColumn(ItemNumber, "ItemNumber");
            listPage.AddColumn(Name, "Name");
            listPage.AddColumn(Stock, "Stock");
            listPage.AddColumn(Costprice, "Costprice");
            listPage.AddColumn(SalesPrice, "Salesprice");
            listPage.AddColumn(AvancePercent, "ProfitMarginPct");
            //use Select to make this our current object
            selected = listPage.Select();
          

        }
    }
    internal class ShowProductScreen : ProductMenuScreen
    {
        protected override void Draw()
        {
            base.Draw();
            Clear(this);
            //Print out current Object's details
            Console.WriteLine($"Varenummer: {selected.ItemNumber} \nNavn: {selected.Name} \nBeskrivelse: {selected.Description} \nSalgspris: {selected.Salesprice} \nIndkøbspris: {selected.Costprice} \nLokation: {selected.Location} \nAntal på lager: {selected.Stock} \nEnhedstype: {selected.Unittype} \nAvance I procent: {selected.ProfitMarginPct} \nAvance I kr: {selected.ProfitMargin}");


        }
    }
    internal class UpdateProductScreen : ProductMenuScreen
    {
        protected override void Draw()
        {
            base.Draw();
            Clear(this);
            //Print out current Object's details
            Console.WriteLine( "update screen");

        }
    }
}
