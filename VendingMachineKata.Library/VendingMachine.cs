﻿using System;
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
                return "0.00";
            }

            return @"INSERT COIN";
        }
    }
}
