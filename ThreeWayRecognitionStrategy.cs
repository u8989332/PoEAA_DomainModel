using CodeParadise.Money;

namespace PoEAA_DomainModel
{
    class ThreeWayRecognitionStrategy : RecognitionStrategy
    {
        private readonly int _firstRecognitionOffset;
        private readonly int _secondRecognitionOffset;

        public ThreeWayRecognitionStrategy(int firstRecognitionOffset, int secondRecognitionOffset)
        {
            _firstRecognitionOffset = firstRecognitionOffset;
            _secondRecognitionOffset = secondRecognitionOffset;
        }

        public override void CalculateRevenueRecognitions(Contract contract)
        {
            Money[] allocation = contract.GetRevenue().Allocate(3);
            contract.AddRevenueRecognition(new RevenueRecognition(allocation[0], contract.GetWhenSigned()));
            contract.AddRevenueRecognition(new RevenueRecognition(allocation[1], contract.GetWhenSigned().AddDays(_firstRecognitionOffset)));
            contract.AddRevenueRecognition(new RevenueRecognition(allocation[2], contract.GetWhenSigned().AddDays(_secondRecognitionOffset)));
        }
    }
}