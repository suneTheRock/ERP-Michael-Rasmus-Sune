using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPOpgave.Products
{
    internal class Product
    {

        public enum UnitType
        {
            Pieces,
            Hours,
            Meters
        }

        public Product(int productId, int costprice, string description, int itemNumber, string location, string name, int profitMargin, int profitMarginPct, int salesprice, decimal stock, int unit, UnitType unitType)
        {
            ProductId = productId;
            Costprice = costprice;
            Description = description;
            ItemNumber = itemNumber;
            Location = location;
            Name = name;
            ProfitMargin = profitMargin;
            ProfitMarginPct = profitMarginPct;
            Salesprice = salesprice;
            Stock = stock;
            Unit = unit;
            localUnitType = unitType;
            if (location.Length > 4)
            {
                //Kaster en Exception tilbage hvis hyldenummer er over 4 numre.
                throw new Exception("Location must be less than 4 characters long.");
            }
        }
        private UnitType localUnitType;
        public int ProductId { get => default; set { } }
        public int Costprice { get => default; set { } }
        public string Description { get => default; set { } }
        public int ItemNumber { get => default; set { } }
        public string Location { get => default; set { } }
        public string Name { get => default; set { } }
        public int ProfitMargin { get => default; set { } }
        public int ProfitMarginPct { get => default; set { } }
        public int Salesprice { get => default; set { } }
        public decimal Stock { get => default; set { } }
        public int Unit { get => default; set { } }

        public int GetProfitMargin()
        {
            //Profit Metode
            return Salesprice - Costprice;
        }

        public decimal GetProfitMarginPct()
        {
            //Profit I procent metode
            return ((Costprice - Salesprice) / Costprice * 100);
        }
    }
}
