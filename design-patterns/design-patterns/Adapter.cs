using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace design_patterns.Adapter
{
    class Adapter
    {
        public static void Main(string[] args)
        {
            // Client is aware of only interface ITarget which has Request method 
            // but wants to access SpecificRequest method in some other class
            // via ITarget ONLY remember via ITarget ONLY

            //Client code
            ITarget target = new ClientAdapter(new Adaptee());
            Client c = new Client(target);
            c.Execute();
        }
    }

    public class Client
    {
        private ITarget target;
        public Client(ITarget target)
        {
            this.target = target;
        }

        public void Execute()
        {
            target.Request();
        }
    }



    public interface ITarget
    {
        void Request();
    }

    public class ClientAdapter : ITarget
    {
        private IAdaptee adaptee;

        public ClientAdapter(IAdaptee adaptee)
        {
            this.adaptee = adaptee;
        }
        public void Request()
        {
            adaptee.SpecificRequest();
        }
    }

    public interface IAdaptee
    {
        void SpecificRequest();
    }

    public class Adaptee : IAdaptee
    {
        public void SpecificRequest()
        {
            Console.WriteLine("SpecificRequest from Adaptee");
        }
    }



}
