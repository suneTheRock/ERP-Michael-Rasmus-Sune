using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPOpgave.Products
{
    public class Product
    {

        public enum UnitType
        {
            Pieces,
            Hours,
            Meters
        }
        public Product(int itemNumber, string name, string description, decimal costprice, decimal salesprice, string location, decimal stock, UnitType unittype)
        {
            ItemNumber = itemNumber;
            Name = name;
            Description = description;
            Costprice = costprice;
            Salesprice = salesprice;
            Location = location;
            Stock = stock;
            Unittype = unittype;
            ProfitMarginPct = GetProfitMarginPct();
            ProfitMargin =GetProfitMargin();
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
            Unittype = unitType;

            if (location.Length > 4)
            {
                //Kaster en Exception tilbage hvis hyldenummer er over 4 numre.
                throw new Exception("Location must be less than 4 characters long.");
            }
        }
        private UnitType localUnitType;
        public int ProductId { get; set; }
        public decimal Costprice { get; set; }
        public string Description { get; set; }
        public int ItemNumber { get; set; }
        public string Location { get; set; }
        public string Name { get; set; }
        public decimal ProfitMargin { get; set; }
        public decimal ProfitMarginPct { get; set; }
        public decimal Salesprice { get; set; }
        public decimal Stock { get; set; }
        public UnitType Unittype { get; set; }

        public decimal GetProfitMargin()
        {
            //Profit Metode
            return Salesprice - Costprice;
        }

        public decimal GetProfitMarginPct()
        {
            //Profit I procent metode
            if (Costprice == 0 || Salesprice == 0) return 0;
            else
            {
                return ((Salesprice-Costprice)/Costprice * 100);
            }
        }
    }
}
