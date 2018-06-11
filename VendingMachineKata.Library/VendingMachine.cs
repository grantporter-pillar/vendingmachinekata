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

        public void AcceptCoin(double mass, double diameter)
        {
            AmountInserted += 1.00m;
        }

        public decimal GetCoinValue(double mass, double diameter)
        {
            return 0m;
        }

        public void ReturnInsertedCoins()
        {
            AmountInserted = 0m;
        }
    }
}
