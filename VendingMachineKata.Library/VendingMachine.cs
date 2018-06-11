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

        public string GetDisplay()
        {
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
    }
}
