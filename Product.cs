namespace PoEAA_DomainModel
{
    class Product
    {
        private readonly string _name;
        private readonly RecognitionStrategy _recognitionStrategy;

        public Product(string name, RecognitionStrategy recognitionStrategy)
        {
            _name = name;
            _recognitionStrategy = recognitionStrategy;
        }

        public static Product NewWordProcessor(string name)
        {
            return new Product(name, new CompleteRecognitionStrategy());
        }

        public static Product NewSpreadsheet(string name)
        {
            return new Product(name, new ThreeWayRecognitionStrategy(60, 90));
        }

        public static Product NewDatabase(string name)
        {
            return new Product(name, new ThreeWayRecognitionStrategy(30, 60));
        }

        public void CalculateRevenueRecognitions(Contract contract)
        {
            _recognitionStrategy.CalculateRevenueRecognitions(contract);
        }
    }
}