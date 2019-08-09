using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    class Paypal : IPaymentService
    {
        private const double FeePercentage = 0.02;
        private const double MonthlyInterest = 0.01;


        public double Interest(double amount, int months)
        {
            return amount * MonthlyInterest * months;
        }
        public double PaymentFee(Double amount)
        {
            return amount * FeePercentage;
        }
    }
}
