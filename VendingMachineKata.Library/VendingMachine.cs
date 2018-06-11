using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachineKata.Library
{
    public class VendingMachine
    {
        public decimal AmountInserted { get; set; }

        public List<CoinSpecification> AcceptedCoins { get; set; }

        public decimal[] Products { get; set; }

        public string TemporaryDisplay { get; set; }
        
        public string GetDisplay()
        {
            if (!string.IsNullOrEmpty(TemporaryDisplay))
            {
                var display = TemporaryDisplay;
                TemporaryDisplay = string.Empty;
                return display;
            }

            if (AmountInserted > 0m)
            {
                return AmountInserted.ToString();
            }

            return @"INSERT COIN";
        }

        public void AcceptCoin(double massGrams, double diameterMillimeters)
        {
            AmountInserted += GetCoinValue(massGrams, diameterMillimeters);
        }

        public decimal GetCoinValue(double massGrams, double diameterMillimeters)
        {
            foreach (var coinSpec in AcceptedCoins)
            {
                if (coinSpec.MassGrams == massGrams && coinSpec.DiameterMillimeters == diameterMillimeters)
                {
                    return coinSpec.Value;
                }
            }

            return 0m;
        }

        public void ReturnInsertedCoins()
        {
            AmountInserted = 0m;
        }

        public decimal GetProductPrice(int productNumber)
        {
            if (Products != null && Products.Count() > productNumber)
            {
                return Products[productNumber];
            }

            return 0m;
        }

        public bool PurchaseProduct(int productNumber)
        {
            var productPrice = GetProductPrice(productNumber);

            if (productPrice <= 0m)
            {
                return false;
            }

            if (productPrice <= AmountInserted)
            {
                AmountInserted -= AmountInserted;
                TemporaryDisplay = @"THANK YOU";
                return true;
            }
            
            TemporaryDisplay = $@"PRICE {productPrice:C}";
            return false;
        }
    }
}
