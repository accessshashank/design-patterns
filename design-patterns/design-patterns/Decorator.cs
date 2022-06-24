using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace design_patterns.Decorator
{
    public class Decorator
    {
        public static void Main(string[] args)
        {
            /*
             * Pizza is a component which has 3 concrete components LargePizza, MediumPizza and SmallPizza
             * We want to decorate Pizza with toppings namely Cheese and Ham
             * PizzaDecorator class extends Pizza and also contains Pizza
             * ConcreteDecorators or toppings of Pizza (Cheese, Ham) extends PizzaDecorator
             * Note Pizza must be abstract class, When i declared interface there were some issues. Will see later what was the issue
             */
            Pizza largePizza = new LargePizza();
            largePizza = new Cheese(largePizza);
            largePizza = new Ham(largePizza);

            Console.WriteLine(largePizza.GetDescription());
            Console.WriteLine(largePizza.CalculateCost());
        }

    }

    public abstract class Pizza
    {
        public string Description { get;  set; }
        public abstract string GetDescription();
        public abstract int CalculateCost();
    }

    public class LargePizza : Pizza
    {
        public LargePizza()
        {
            Description = "Large Pizza";
        }

        public override int CalculateCost()
        {
            return 10;
        }

        public override string GetDescription()
        {
            return Description;
        }
    }

    public class MediumPizza : Pizza
    {
        public MediumPizza()
        {
            Description = "Medium Pizza";
        }

        public override int CalculateCost()
        {
            return 8;
        }

        public override string GetDescription()
        {
            return Description;
        }
    }

    public class SmallPizza : Pizza
    {
        public SmallPizza()
        {
            Description = "Small Pizza";
        }

        public override int CalculateCost()
        {
            return 8;
        }

        public override string GetDescription()
        {
            return Description;
        }
    }

    public class PizzaDecorator : Pizza
    {
        protected Pizza pizza;
        public PizzaDecorator(Pizza pizza)
        {
            this.pizza = pizza;
        }

        public override int CalculateCost()
        {
            return this.pizza.CalculateCost();
        }

        public override string GetDescription()
        {
            return this.pizza.GetDescription();
        }
    }

    public class Cheese : PizzaDecorator
    { 
        public Cheese(Pizza pizza) : base(pizza)
        {

        }

        public override int CalculateCost()
        {
            return this.pizza.CalculateCost() + 5;
        }

        public override string GetDescription()
        {
            return this.pizza.GetDescription() +  " " +"Cheese";
        }
    }

    public class Ham : PizzaDecorator
    {
        public Ham(Pizza pizza) : base(pizza)
        {

        }

        public override int CalculateCost()
        {
            return this.pizza.CalculateCost() + 3;
        }

        public override string GetDescription()
        {
            return this.pizza.GetDescription() + " " + "Ham";
        }
    }

}
