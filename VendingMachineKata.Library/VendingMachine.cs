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

        public Dictionary<CoinSpecification, int> CoinTubes { get; set; }

        public decimal[] Prices { get; set; }

        public int[] Inventory { get; set; }

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

        public bool AcceptCoin(double massGrams, double diameterMillimeters)
        {
            var coinType = IdentifyCoin(massGrams, diameterMillimeters);

            if (coinType == null)
            {
                return false; // Coin is rejected to coin return
            }

            CoinTubes[coinType]++; // Add coin to the appropriate coin tube

            AmountInserted += coinType.Value;

            return true;
        }

        public CoinSpecification IdentifyCoin(double massGrams, double diameterMillimeters)
        {
            foreach (var coinSpec in CoinTubes.Select(i => i.Key).Distinct())
            {
                if (coinSpec.MassGrams == massGrams && coinSpec.DiameterMillimeters == diameterMillimeters)
                {
                    return coinSpec;
                }
            }

            return null;
        }

        public void ReturnInsertedCoins()
        {
            AmountInserted = 0m;
        }

        public decimal GetProductPrice(int productNumber)
        {
            if (Prices != null && Prices.Count() > productNumber)
            {
                return Prices[productNumber];
            }

            return 0m;
        }

        public int GetInventory(int productNumber)
        {
            if (Inventory != null && Inventory.Count() > productNumber)
            {
                return Inventory[productNumber];
            }

            return 0;
        }

        public bool PurchaseProduct(int productNumber)
        {
            var productInventory = GetInventory(productNumber);

            if (productInventory < 1)
            {
                TemporaryDisplay = @"SOLD OUT";
                return false;
            }

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
