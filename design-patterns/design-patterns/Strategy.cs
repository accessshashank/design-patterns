using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace design_patterns.Strategy
{
    class Strategy
    {
        public static void Main(string[] args)
        {
            // Strategy pattern focuses on using comosition rather than inheritance for code reuse
            // we decouple algorithm from clients that uses it. Algorithms can be interchanged in client without changing client.
            // Client does not change but behavior is changed

            Client clientWithBehaviorA = new Client(new BehaviorA());
            clientWithBehaviorA.Execute();

            Client clientWithBehaviorB = new Client(new BehaviorB());
            clientWithBehaviorB.Execute();

            // There are lot of types of duck,, CityDuck, MountainDuck, RubberDuck, etc..
            // See how cleverly we have avoided subclassing of Duck
            // This is strategy pattern
            // we decoupled behaviors from client using it.

            // Here we avoided subclass CityDuck,,, we just used variable name to define its behavior
            var cityDuck = new Duck(new LowQuackBehavior(), new RikshawSpeedBehavior(), new AndheraDisplayBehavior());
            cityDuck.Quack();
            cityDuck.Fly();
            cityDuck.Display();

            // notice we are interchanging algorithms / behaviors in clients
            var mountainDuck = new Duck(new HighQuackBehavior(), new JetSpeedBehavior(), new TarakBharakDisplayBehavior());
            mountainDuck.Quack();
            mountainDuck.Fly();
            mountainDuck.Display();

        }

    }

    public class Duck
    {
        private IQuackBehavior qb;
        private IFlyBehavior fb;
        private IDisplayBehavior db;

        public Duck(IQuackBehavior qb, IFlyBehavior fb, IDisplayBehavior db)
        {
            this.qb = qb;
            this.fb = fb;
            this.db = db;
        }

        public void Quack()
        {
            qb.Quack();
        }

        public void Fly()
        {
            fb.Fly();
        }

        public void Display()
        {
            db.Display();
        }
    }

    public interface IQuackBehavior
    {
        void Quack();
    }
    public interface IFlyBehavior
    {
        void Fly();
    }
    public interface IDisplayBehavior
    {
        void Display();
    }

    public class HighQuackBehavior : IQuackBehavior
    {
        public void Quack()
        {
            Console.WriteLine("BOOM BOOM");
        }
    }

    public class LowQuackBehavior : IQuackBehavior
    {
        public void Quack()
        {
            Console.WriteLine("FUSS FUSS");
        }
    }

    public class JetSpeedBehavior : IFlyBehavior
    {
        public void Fly()
        {
            Console.WriteLine("Zoom...");
        }
    }

    public class RikshawSpeedBehavior : IFlyBehavior
    {
        public void Fly()
        {
            Console.WriteLine("Tur tur.....");
        }
    }

    public class TarakBharakDisplayBehavior : IDisplayBehavior
    {
        public void Display()
        {
            Console.WriteLine("Tarak Bharak");
        }
    }


    public class AndheraDisplayBehavior : IDisplayBehavior
    {
        public void Display()
        {
            Console.WriteLine("Andhera ");
        }
    }

    public class Client
    {
        private IBehavior behavior;
        public Client(IBehavior behavior)
        {
            this.behavior = behavior;
        }

        public void Execute()
        {
            behavior.Run();
        }
    }

    public interface IBehavior
    {
        void Run();
    }

    public class BehaviorA : IBehavior
    {
        public void Run()
        {
            Console.WriteLine("BehaviorA");
        }
    }

    public class BehaviorB : IBehavior
    {
        public void Run()
        {
            Console.WriteLine("BehaviorB");
        }
    }


}
