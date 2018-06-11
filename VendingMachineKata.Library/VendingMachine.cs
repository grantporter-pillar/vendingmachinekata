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
            AmountInserted += 1.00m;
        }

        public decimal GetCoinValue(double massGrams, double diameterMillimeters)
        {
            if (massGrams == 5.000 && diameterMillimeters == 21.21) // USA Nickel
            {
                return 0.05m;
            }

            if (massGrams == 2.268 && diameterMillimeters == 17.91) // USA Dime
            {
                return 0.10m;
            }

            if (massGrams == 5.670 && diameterMillimeters == 24.26) // USA Quarter
            {
                return 0.25m;
            }

            return 0m;
        }

        public void ReturnInsertedCoins()
        {
            AmountInserted = 0m;
        }
    }
}
