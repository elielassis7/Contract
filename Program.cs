using System;
using System.Globalization;
using Entities;
using Services;

namespace Contracts
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter contract data:");
            Console.Write("Contract Number: ");
            int number = int.Parse(Console.ReadLine());
            Console.Write("Date (dd/MM/yyyy): ");
            DateTime date = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", CultureInfo.CurrentCulture);
            Console.Write("Contract Value: ");
            double totalValue = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            Console.Write("Enter number of installments: ");
            int months = int.Parse(Console.ReadLine());

            Contract contract = new Contract(number, date, totalValue);
            PaymentOnline payonline = new PaymentOnline(new Paypal());
            payonline.ProcessContract(contract, months);

            Console.WriteLine("Installments: ");
            foreach (Installment Line in contract.Installments)
            {
                Console.WriteLine(Line);
            }

           
            //https://github.com/acenelio/interfaces4-csharp - para revisar o programa

        }
    }
}
