using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facade
{
    class Program
    {
        static void Main(string[] args)
        {
            Order order = new Order();
            order.ExecutionOfOrder();
            Console.Read();
        }
    }
    //Facade
    public class Order
    {
        public void ExecutionOfOrder()
        {
            Console.WriteLine("Începutul îndeplinirii comenzii:");
            //Alegerea produselor
            Product product = new Product();
            product.GetProductDetails();
            //Calcularea pretului comenzii
            Price price = new Price();
            price.GetCost();
            //Achitarea
            Payment payment = new Payment();
            payment.MakePayment();
            //Livrarea
            Delivery delivery = new Delivery();
            delivery.DeliveryExecution();

            Console.WriteLine("Comanda a fost realizata!");
        }
    }
    public class Price
    {
        //metoda calcularii
        public void GetCost()
        {
            Console.WriteLine("Pretul a fost calculat");
        }
    }
    public class Payment
    {
        //metoda pentru achitare
        public void MakePayment()
        {
            Console.WriteLine("Plata finalizata");
        }
    }
    public class Product
    {
        //pentru informatii despre produs
        public void GetProductDetails()
        {
            Console.WriteLine("Obținerea informației despre produsele selectate");
        }
    }
    public class Delivery
    {
        //Metoda realizării livrarii
        public void DeliveryExecution()
        {
            Console.WriteLine("Livrarea realizată");
        }
    }
}
