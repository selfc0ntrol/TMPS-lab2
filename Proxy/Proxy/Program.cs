using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxy
{
    class Program
    {
        static void Main()
        {
            IPayment cash = new Cash();
            IPayment creditCard = new CreditCard(cash);
            creditCard.Pay();
            Console.ReadKey();
        }
    }
    interface IPayment
    {
        void Pay();
    }
    class Cash : IPayment
    {
        public void Pay()
        {
            Console.WriteLine("Plată finalizată");
        }
    }
    class CreditCard : IPayment
    {
        IPayment @cash;
        public CreditCard(IPayment @cash)
        {
            this.@cash = @cash;
        }
        public void Pay()
        {
            this.@cash.Pay();
        }
    }

}
