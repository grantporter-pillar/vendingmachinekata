using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachineKata.Library
{
    public class CoinTube
    {
        public CoinSpecification Spec { get; set; }
        public int CountInTube { get; set; }
        public int Capacity { get; set; }

        public CoinTube(CoinSpecification spec, int capacity, int countInTube = 0)
        {
            Spec = spec;
            Capacity = capacity;
            CountInTube = countInTube;
        }
    }
}
