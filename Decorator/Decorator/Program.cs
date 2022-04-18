using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator
{
    class Program
    {
        static void Main(string[] args)
        {
            Pizza pizza1 = new ItalianPizza();
            pizza1 = new TomatoPizza(pizza1); // Pizza italiana cu tomato
            Console.WriteLine("Denumirea: {0}", pizza1.Name);
            Console.WriteLine("Pretul: {0}", pizza1.GetCost());

            Pizza pizza2 = new ItalianPizza();
            pizza2 = new CheesePizza(pizza2);// Pizza italiana cu cascaval
            Console.WriteLine("Denumirea: {0}", pizza2.Name);
            Console.WriteLine("Pretul: {0}", pizza2.GetCost());

            Pizza pizza3 = new BulgerianPizza();
            pizza3 = new TomatoPizza(pizza3);
            pizza3 = new CheesePizza(pizza3);// Pizza bulgareasca cu tomato si cascaval
            Console.WriteLine("Denumirea: {0}", pizza3.Name);
            Console.WriteLine("Pretul: {0}", pizza3.GetCost());

            Console.ReadLine();
        }
    }

    abstract class Pizza
    {
        public Pizza(string n)
        {
            this.Name = n;
        }
        public string Name { get; protected set; }
        public abstract int GetCost();
    }

    class ItalianPizza : Pizza
    {
        public ItalianPizza() : base("Pizza italiana")
        { }
        public override int GetCost()
        {
            return 85;
        }
    }
    class BulgerianPizza : Pizza
    {
        public BulgerianPizza()
            : base("Pizza bulgareasca")
        { }
        public override int GetCost()
        {
            return 80;
        }
    }

    abstract class PizzaDecorator : Pizza
    {
        protected Pizza pizza;
        public PizzaDecorator(string n, Pizza pizza) : base(n)
        {
            this.pizza = pizza;
        }
    }

    class TomatoPizza : PizzaDecorator
    {
        public TomatoPizza(Pizza p)
            : base(p.Name + ", cu tomato", p)
        { }

        public override int GetCost()
        {
            return pizza.GetCost() + 30;
        }
    }

    class CheesePizza : PizzaDecorator
    {
        public CheesePizza(Pizza p)
            : base(p.Name + ", cu cascaval", p)
        { }

        public override int GetCost()
        {
            return pizza.GetCost() + 15;
        }
    }
}
