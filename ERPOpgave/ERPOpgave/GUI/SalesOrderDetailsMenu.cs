using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TECHCOOL.UI;
using ERPOpgave.Models;

namespace ERPOpgave.GUI
{
    internal class SalesOrderDetailsMenu : Screen
    {
//Salgsordredetaljer: Skærmen viser detaljer fra
//kunden:
//• Salgsordrenummer
//• Dato
//• Kundenummer
//• Fornavn og efternavn på kunde(i samme
//kolonne adskilt af mellemrum)

		public override string Title { get; set; } = "LNE Security A/S";
		public string SalesOrderNumber { get; set; } = "Sales Order Number";
		public string Date { get; set; } = "Date";
		public string CustomerID { get; set; } = "Customer ID";
		public string CustomerName { get; set; } = "Customer Name";

		public ListPage<Customer> listPage = new ListPage<Customer>();
		protected Customer selected;

		// Creating a constructor so our listpage gets all the info it needs ONCE. Remove listPage.Add from Draw!!!
		public SalesOrderDetailsMenu()
		{
			//This is all a placeholder untill we get the database running
			//listPage.Add(new Customer(1, DateTime.Now));
			//listPage.Add(new SalesOrder(2, DateTime.Now));
		}

		protected override void Draw()
		{
			Clear(this); //Keeping it Clean

			//We add a Column with (<A title taken from above> , <"The Variablename we gave them in their own class">)
			listPage.AddColumn(SalesOrderNumber, "OrderNumber");
			listPage.AddColumn(Date, "Created");
			listPage.AddColumn(CustomerID, "Customer");
			listPage.AddColumn(CustomerName, "Customer");

			listPage.Draw();
		}
	}
}
