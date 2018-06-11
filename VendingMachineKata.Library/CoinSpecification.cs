namespace VendingMachineKata.Library
{
    public class CoinSpecification
    {
        public double MassGrams { get; set; }
        public double DiameterMillimeters { get; set; }
        public decimal Value { get; set; }

        public CoinSpecification(double massGrams, double diameterMillimeters, decimal value)
        {
            MassGrams = massGrams;
            DiameterMillimeters = diameterMillimeters;
            Value = value;
        }
    }
}
