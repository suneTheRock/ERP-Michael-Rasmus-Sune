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
		public override string Title { get; set; } = "LNE Security A/S";
		public string CustomerNumber { get; set; } = "Kundenummer";
		public string Name { get; set; } = "Navn";
		public string Phonenumber { get; set; } = "TelefonNummer";
		public string Email { get; set; } = "E-Mail";

		public string LastOrderDate { get; set; } = "Dato for sidste køb";

		protected override void Draw()
		{
			Clear(this);
			//Make a Class to host our screen elements.
			//Make a List Of that classtype
			Console.WriteLine("Indtast venligst F1 for at oprette en kunde til listen");
			Console.WriteLine("Indtast venligst F2 for at foretage redigering af kunde fra listen");
			
			//Add all the things you want on that list, with a string to represent them on the menu screen.
			listPage.Add(new Customer(1,"Mailadress1@dot.com", "Tom", "Jerrison", 29292929));
			listPage.Add(new Customer(2, "Mailadress2@dot.com", "Ben", "Jerrison", 292992929));
			listPage.Add(new Customer(3, "Mailadress3@dot.com", "Jerry", "Tommison", 88888888));
			//We add a Column with (<A title taken from above> , <"The Variablename we gave them in their own class">)
			listPage.AddColumn(CustomerNumber, "CustomerID");
			listPage.AddColumn(Name, "FullName");
			listPage.AddColumn(Phonenumber, "Phone");
			listPage.AddColumn(Email, "Email");
			listPage.AddColumn(LastOrderDate.ToString(), "LastOrder");

			//Draw to see this printed out
			listPage.Draw();
		}

		public void EditCustomer()
        {
			
        }
	}
}
