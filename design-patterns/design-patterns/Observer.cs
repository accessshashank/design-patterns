using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace design_patterns.Observer
{
    class Observer
    {
        static void Main(string[] args)
        {
            ConcreteObservble observable = new ConcreteObservble();
            IObserver observer = new ConcreteObserver(observable);
            observable.Add(observer);
            observable.Notify();
        }

        public interface IObservable
        {
            void Add(IObserver observer);
            void Remove(IObserver observer);
            void Notify();
        }

        public interface IObserver
        {
            void Update();
        }

        public class ConcreteObservble : IObservable
        {
            public List<IObserver> Observers = new List<IObserver>();
            public void Add(IObserver observer)
            {
                this.Observers.Add(observer);
            }

            public void Notify()
            {
                foreach (var observer in this.Observers)
                {
                    observer.Update();
                }
            }

            public void Remove(IObserver observer)
            {
                this.Observers.Remove(observer);
            }

            // This function has nothing to do with IObservble
            // It is used to pass some data to Observer so that they can act upon
            public int SomeDataWhichWillHelpObserverActOnNotification()
            {
                return 21;
            }
        }

        public class ConcreteObserver : IObserver
        {
            private ConcreteObservble concreteObservble;
            // We are injecting ConcreteObservble and not IObservable
            // Because we need to get state of Observable via SomeDataWhichWillHelpObserverActOnNotification()
            // IObservable does have have access to function SomeDataWhichWillHelpObserverActOnNotification()
            // If we want to avoid passing ConcreteObservble in ctor then data must be pased via Update as a parameter.
            public ConcreteObserver(ConcreteObservble concreteObservble)
            {
                this.concreteObservble = concreteObservble;
            }

            public void Update()
            {
                Console.WriteLine("Notification from Observable - " + this.concreteObservble.SomeDataWhichWillHelpObserverActOnNotification());
            }
        }

    }
}
