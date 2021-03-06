﻿using System;
using System.Collections.Generic;
using System.Linq;

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

            if (ExactChangeOnly())
            {
                return @"EXACT CHANGE ONLY";
            }

            return @"INSERT COIN";
        }

        public bool AcceptCoin(double massGrams, double diameterMillimeters)
        {
            var coinType = IdentifyCoin(massGrams, diameterMillimeters);

            if (coinType == null)
            {
                OnCoinDispensed(null); // Unknown coin rejected
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
                while (amount > 0m && coinTube.CountInTube > 0
                    && amount >= coinTube.Spec.Value)
                {
                    amount -= coinTube.Spec.Value;
                    AmountInserted -= coinTube.Spec.Value;
                    coinTube.CountInTube--;
                    OnCoinDispensed(new CoinDispensedEventArgs(coinTube.Spec));
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

                while (amount > 0m && virtualCountInTube > 0
                    && amount >= coinTube.Spec.Value)
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
                DispenserChannels[productNumber].Inventory--;
                DispenseCoins(AmountInserted);

                TemporaryDisplay = @"THANK YOU";
                return true;
            }

            TemporaryDisplay = $@"PRICE {productPrice:C}";
            return false;
        }

        private bool ExactChangeOnly()
        {
            var availableProductPrices = DispenserChannels
                .Where(i => i.Inventory > 0)
                .Select(i => i.Price)
                .Distinct();

            var acceptedCoinValues = CoinTubes
                .Select(i => i.Spec.Value)
                .Distinct()
                .OrderBy(i => i);

            var smallestAcceptedCoinValue = acceptedCoinValues.Min();
            var largestAcceptedCoinValue = acceptedCoinValues.Max();

            // There is a product that is being sold for a multiple of a 
            // smaller denomination than the smallest accepted denomination
            if (availableProductPrices.Any(i => i % smallestAcceptedCoinValue > 0))
            {
                return true;
            }

            foreach (var price in availableProductPrices)
            {
                foreach (var coinValue in acceptedCoinValues)
                {
                    if (price % coinValue > 0 && !CanDispenseCoins(price % coinValue))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        protected virtual void OnCoinDispensed(CoinDispensedEventArgs e)
        {
            CoinDispensed?.Invoke(this, e);
        }
        public event EventHandler CoinDispensed;
    }

    public class CoinDispensedEventArgs : EventArgs
    {
        public CoinSpecification CoinSpec { get; }

        public CoinDispensedEventArgs(CoinSpecification coinSpec)
        {
            this.CoinSpec = coinSpec;
        }
    }
}
