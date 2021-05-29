using CodeParadise.Money;
using System;

namespace PoEAA_DomainModel
{
    class RevenueRecognition
    {
        private readonly Money _amount;
        private readonly DateTime _date;

        public RevenueRecognition(Money amount, DateTime date)
        {
            _amount = amount;
            _date = date;
        }

        public Money GetAmount()
        {
            return _amount;
        }

        public bool IsRecognizableBy(DateTime asOf)
        {
            return asOf.CompareTo(_date) >= 0;
        }
    }
}
