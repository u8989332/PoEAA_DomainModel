using CodeParadise.Money;
using System;

namespace PoEAA_DomainModel
{
    class Program
    {
        static void Main(string[] args)
        {
            Product word = Product.NewWordProcessor("CodeParadise Word");
            Product calc = Product.NewSpreadsheet("CodeParadise Calc");
            Product db = Product.NewDatabase("CodeParadise DB");

            Contract wordContract = new Contract(word, Money.Dollars(24000m), new DateTime(2020, 7, 25));
            Contract calcContract = new Contract(calc, Money.Dollars(1000m), new DateTime(2020, 3, 15));
            Contract dbContract = new Contract(db, Money.Dollars(9999m), new DateTime(2020, 1, 1));

            wordContract.CalculateRecognitions();
            calcContract.CalculateRecognitions();
            dbContract.CalculateRecognitions();


            var wordProcessorRevenue = wordContract.RecognizedRevenue(new DateTime(2020, 9, 30));
            Console.WriteLine($"word processor revenue before 2020-09-30 = {wordProcessorRevenue.Amount}");

            var spreadsheetRevenue = calcContract.RecognizedRevenue(new DateTime(2020, 6, 1));
            Console.WriteLine($"spreadsheet revenue before 2020-06-01 = {spreadsheetRevenue.Amount}");

            var databaseRevenue = dbContract.RecognizedRevenue(new DateTime(2020, 1, 25));
            Console.WriteLine($"database revenue before 2020-01-25 = {databaseRevenue.Amount}");
        }
    }
}
