using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapter
{
    class Program
    {
        static void Main(string[] args)
        {
            // Sofer
            Driver driver = new Driver();
            // masina
            Auto auto = new Auto();
            // indreptare spre livrare
            driver.Delivery(auto);
            // Am ajuns, trebuie sa folosim picioarele 
            Human human = new Human();
            // Folosim adapter
            ITransport humanTransport = new HumanToTransportAdapter(human);
            // Continuam sa mergem pe jos
            driver.Delivery(humanTransport);

            Console.Read();
        }
    }
    interface ITransport
    {
        void Drive();
    }
    // Clasa masinii
    class Auto : ITransport
    {
        public void Drive()
        {
            Console.WriteLine("Lucratorul merge cu masina");
        }
    }
    class Driver
    {
        public void Delivery(ITransport transport)
        {
            transport.Drive();
        }
    }
    class Human
    {
        public void Move()
        {
            Console.WriteLine("Lucratorul merge pe jos");
        }
    }
    // Adapter de la Human la ITransport
    class HumanToTransportAdapter : ITransport
    {
        Human human;
        public HumanToTransportAdapter(Human c)
        {
            human = c;
        }

        public void Drive()
        {
            human.Move();
        }
    }
}
