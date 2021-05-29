using CodeParadise.Money;
using System;
using System.Collections.Generic;

namespace PoEAA_DomainModel
{
    class Contract
    {
        private readonly List<RevenueRecognition> _revenueRecognitions = new List<RevenueRecognition>();

        private readonly Product _product;
        private readonly Money _revenue;
        private readonly DateTime _whenSigned;
        private readonly int _id;
        private static int _commonId = 1;
        private static readonly object IdLock = new object();

        public Contract(Product product, Money revenue, DateTime whenSigned)
        {
            _product = product;
            _revenue = revenue;
            _whenSigned = whenSigned;
            _id = GenerateNewId();
        }

        private static int GenerateNewId()
        {
            // todo db generate auto increment id
            lock (IdLock)
            {
                return _commonId++;
            }
        }

        public Money RecognizedRevenue(DateTime asOf)
        {
            Money result = Money.Dollars(0m);
            _revenueRecognitions.ForEach(x =>
                {
                    if (x.IsRecognizableBy(asOf))
                    {
                        result += x.GetAmount();
                    }
                });

            return result;
        }

        public Money GetRevenue()
        {
            return _revenue;
        }

        public DateTime GetWhenSigned()
        {
            return _whenSigned;
        }

        public void AddRevenueRecognition(RevenueRecognition revenueRecognition)
        {
            // todo
            // db insert

            // after db insertion, add it to list
            _revenueRecognitions.Add(revenueRecognition);
        }

        public void CalculateRecognitions()
        {
            _product.CalculateRevenueRecognitions(this);
        }
    }
}
