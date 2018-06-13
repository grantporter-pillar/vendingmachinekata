using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachineKata.Library
{
    public class VendingMachine
    {
        public decimal AmountInserted { get; private set; }

        public List<CoinTube> CoinTubes { get; set; }

        public DispenserChannel[] DispenserChannels { get; set; }

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

            AddCoinToAvailableCoinTube(coinType);

            AmountInserted += coinType.Value;

            return true;
        }

        public void AddCoinToAvailableCoinTube(CoinSpecification coinType)
        {
            for (var i = 0; i < CoinTubes.Count(); i++)
            {
                var coinTube = CoinTubes[i];

                if (coinTube.Spec == coinType && coinTube.CountInTube < coinTube.Capacity)
                {
                    // Direct inserted coin to the available coin tube
                    coinTube.CountInTube++;
                    return;
                }
            }

            // Direct inserted coin to cash box
        }

        public CoinSpecification IdentifyCoin(double massGrams, double diameterMillimeters)
        {
            foreach (var coinSpec in CoinTubes.Select(i => i.Spec).Distinct())
            {
                if (coinSpec.MassGrams == massGrams && coinSpec.DiameterMillimeters == diameterMillimeters)
                {
                    return coinSpec;
                }
            }

            return null;
        }

        public int GetCoinInventory(CoinSpecification coinType)
        {
            return CoinTubes.Where(i => i.Spec == coinType)
                .Sum(i => i.CountInTube);
        }

        public void DispenseCoins(decimal amount)
        {
            foreach (var coinTube in CoinTubes
                .Where(i => i.CountInTube > 0 && i.Spec.Value <= amount)
                .OrderByDescending(i => i.Spec.Value)
                .ThenByDescending(i => i.CountInTube))
            {
                while (coinTube.CountInTube > 0 && amount / coinTube.Spec.Value > 0)
                {
                    amount -= coinTube.Spec.Value;
                    AmountInserted -= coinTube.Spec.Value;
                    coinTube.CountInTube--;
                }
            }
        }

        public bool CanDispenseCoins(decimal amount)
        {
            foreach (var coinTube in CoinTubes
                .Where(i => i.CountInTube > 0 && i.Spec.Value <= amount)
                .OrderByDescending(i => i.Spec.Value)
                .ThenByDescending(i => i.CountInTube))
            {
                var virtualCountInTube = coinTube.CountInTube;

                while (virtualCountInTube > 0 && amount / coinTube.Spec.Value > 0)
                {
                    amount -= coinTube.Spec.Value;
                    virtualCountInTube--;
                }
            }

            return amount == 0m;
        }

        public decimal GetProductPrice(int productNumber)
        {
            return DispenserChannels[productNumber].Price;
        }

        public int GetInventory(int productNumber)
        {
            return DispenserChannels[productNumber].Inventory;
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
                AmountInserted -= productPrice;
                // Product is dispensed
                DispenserChannels[productNumber].Inventory--;
                DispenseCoins(AmountInserted);
            
                TemporaryDisplay = @"THANK YOU";
                return true;
            }

            TemporaryDisplay = $@"PRICE {productPrice:C}";
            return false;
        }
    }
}
