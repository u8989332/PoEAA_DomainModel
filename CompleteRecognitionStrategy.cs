namespace PoEAA_DomainModel
{
    class CompleteRecognitionStrategy : RecognitionStrategy
    {
        public override void CalculateRevenueRecognitions(Contract contract)
        {
            contract.AddRevenueRecognition(new RevenueRecognition(contract.GetRevenue(), contract.GetWhenSigned()));
        }
    }
}