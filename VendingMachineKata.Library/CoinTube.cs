namespace VendingMachineKata.Library
{
    public class CoinTube
    {
        public CoinSpecification Spec { get; set; }
        public int CountInTube { get; set; }
        public int Capacity { get; set; }

        public CoinTube(CoinSpecification spec, int capacity)
        {
            Spec = spec;
            Capacity = capacity;
            CountInTube = 0;
        }
    }
}
