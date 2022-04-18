using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
namespace Composite
{
    class Program
    {
        static void Main()
        {
            //Componenta comenzii
            Component order = new Composite("      Order:");
            //Componentele comenzii
            Component toys = new Leaf("Toys");
            Component drink = new Composite("Drink:");
            Component food = new Composite("Food:");
            //Componentele bauturilor
            Component cocacola = new Leaf("-CocaCola");
            Component pepsi = new Leaf("-Pepsi");
            Component sprite = new Leaf("-Sprite");
            //Componentele mancarii
            Component pizza = new Leaf("-Pizza");
            Component salad = new Leaf("-Salad");
            Component happymeal = new Leaf("-HappyMeal");
            order.Add(toys);
            order.Add(drink);
            order.Add(food);
            drink.Add(cocacola);
            drink.Add(pepsi);
            drink.Add(sprite);
            food.Add(pizza);
            food.Add(salad);
            food.Add(happymeal);
            order.Operation();
            Console.ReadKey();
        }
    }
    abstract class Component
    {
        protected string name;
        public Component(string name)
        {
            this.name = name;
        }
        public abstract void Operation();
        public abstract void Add(Component component);
        public abstract void Remove(Component component);
        public abstract Component GetChild(int index);
    }
    class Leaf : Component
    {
        public Leaf(string name)
        : base(name)
        {
        }
        public override void Operation()
        {
            Console.WriteLine(name);
        }
        public override void Add(Component component)
        {
            throw new InvalidOperationException();
        }
        public override void Remove(Component component)
        {
            throw new InvalidOperationException();
        }
        public override Component GetChild(int index)
        {
            throw new InvalidOperationException();
        }
    }
    class Composite : Component
    {
        ArrayList nodes = new ArrayList();
        public Composite(string name)
        : base(name)
        {
        }
        public override void Operation()
        {
            Console.WriteLine(name);
            foreach (Component component in nodes)
                component.Operation();
        }
        public override void Add(Component component)
        {
            nodes.Add(component);
        }
        public override void Remove(Component component)
        {
            nodes.Remove(component);
        }
        public override Component GetChild(int index)
        {
            return nodes[index] as Component;
        }
    }
}
