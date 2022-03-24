using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TECHCOOL.UI;

namespace ERPOpgave.GUI
{
    internal class TitleScreen : Screen
    {
		// HOW TO MENU:
		public override string Title { get; set; } = "LNE Security A/S";
		public string Menu { get; set; } = "Titel";
		protected override void Draw()
		{
			Clear(this);
			//Make a Class to host our screen elements.
			//Make a List Of that classtype
			ListPage<MenuScreenOption> listPage = new ListPage<MenuScreenOption>();
			//Add all the things you want on that list, with a string to represent them on the menu screen.
			listPage.Add(new MenuScreenOption("Produkt"));
			listPage.Add(new MenuScreenOption("Virksomhed"));
			listPage.Add(new MenuScreenOption("Lager"));
            //We add a Column with (<A title taken from above> , <"The Variablename we gave them in their own class">)
            listPage.AddColumn(Menu, "Text");
			//Draw to see this printed out
            listPage.Draw();
		}
	}
}
