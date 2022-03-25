﻿using ERPOpgave.Models;
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



		protected override void Draw()
		{
			Clear(this);
			//Make a Class to host our screen elements.
			//Make a List Of that classtype
			ListPage<Company> listPage = new ListPage<Company>();
			//Add all the things you want on that list, with a string to represent them on the menu screen.
			listPage.Add(new Company("CoolShop", "Danmarksgade", "20", "9000", "Aalborg", "Danmark", "DDK"));
			listPage.Add(new Company("BigBooty A/S", "Bitches Street","69","6969", "Gotham", "Vatican City", "Altar Boys"));
            listPage.Add(new Company("LongSchlong A/S", "Bitches Street", "70", "6969", "Gotham", "Vatican City 2000", "Dogecoin"));
            listPage.Add(new Company("Huge Tracks of land", "Bitches Street", "69", "6969", "Gotham", "Vatican City+ Premium Edition", "Altar Thems"));


			//We add a Column with (<A title taken from above> , <"The Variablename we gave them in their own class">)
			listPage.AddColumn("CompanyName", "CompanyName");
            listPage.AddColumn("Street", "Street");
			listPage.AddColumn("Housenumber", "HouseNumber");
			listPage.AddColumn("PostalNumber", "PostalNumber");
			listPage.AddColumn("City", "City");
			listPage.AddColumn("Country", "Country");
			listPage.AddColumn("Currency", "Currency");
			
			Console.WriteLine("Tryk på F1 for at oprette opsætte en Virksomhed");
			//Draw to see this printed out
			listPage.Draw();
		}

		public void CreateNewCompanyToList()
        {
			Clear();
			Console.WriteLine("Opsætning af nye virksomhed");
			Console.WriteLine("-----------------------------");
			Console.WriteLine("Indtast Venligst virksomhedens oplysninger");
			Console.WriteLine("Navn: "); var navneInput = Console.ReadLine();
			if(navneInput != null)
            {
				
            }

        }
	}

}
