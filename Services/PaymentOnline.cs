using System;
using Entities;

namespace Services
{
    class PaymentOnline
    {
        public int Number { get; set; }
        public double Amount { get; set; }
        public DateTime Date { get; set; }
        private IPaymentService _pay;

        public PaymentOnline( IPaymentService pay)
        {
            _pay = pay;
        }

        public void ProcessContract(Contract contract, int month)
        {
            double basicQuota = contract.TotalValue / month;
            for (int i = 1; i <= month; i++)
            {
                DateTime date = contract.Date.AddMonths(i);
                double updateQuota = basicQuota + _pay.Interest(basicQuota, i);
                double fullQuota = updateQuota + _pay.PaymentFee(updateQuota);
                contract.AddInstallments(new Installment(date, fullQuota));
            }
        }
    }
}
