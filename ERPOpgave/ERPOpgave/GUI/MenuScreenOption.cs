using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPOpgave.GUI
{
    internal class MenuScreenOption
    {
		//To make a Menu we just need the string text we want to be the option:
		public string Text { get; set; } = "";

		public MenuScreenOption(string text)
		{
			Text = text;
		}
	}
}
