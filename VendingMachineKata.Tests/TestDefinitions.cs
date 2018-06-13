using VendingMachineKata.Library;

namespace VendingMachineKata.Tests
{
    public static class TestDefinitions
    {
        // In the real vending machine implementation, these are stored in a configuration.  
        // For the unit test, they are static variables
        public static readonly CoinSpecification UsaPenny = new CoinSpecification(2.500, 19.05, 0.01m);
        public static readonly CoinSpecification UsaNickel = new CoinSpecification(5.000, 21.21, 0.05m);
        public static readonly CoinSpecification UsaDime = new CoinSpecification(2.268, 17.91, 0.10m);
        public static readonly CoinSpecification UsaQuarter = new CoinSpecification(5.670, 24.26, 0.25m);
    }
}
