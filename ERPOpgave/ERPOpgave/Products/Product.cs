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

        public Product(int productId, int costprice, int description, int itemNumber, string location, int name, int profitMargin, int profitMarginPct, int salesprice, decimal stock, int unit, UnitType unitType)
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
                throw new Exception("Location must be less than 4 characters long.");
            }
        }
        private UnitType localUnitType;
        public int ProductId { get => default; set { } }
        public int Costprice { get => default; set { } }
        public int Description { get => default; set { } }
        public int ItemNumber { get => default; set { } }
        public string Location { get => default; set { } }
        public int Name { get => default; set { } }
        public int ProfitMargin { get => default; set { } }
        public int ProfitMarginPct { get => default; set { } }
        public int Salesprice { get => default; set { } }
        public decimal Stock { get => default; set { } }
        public int Unit { get => default; set { } }

        public int GetProfitMargin()
        {
            return Salesprice - Costprice;
        }

        public decimal GetProfitMarginPct()
        {

            return ((Costprice - Salesprice) / Costprice * 100);
        }
    }
}
