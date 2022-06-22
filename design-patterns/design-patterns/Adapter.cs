using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace design_patterns
{
    class Client
    {
        public static void Main(string[] args)
        {
            // Client is aware of only interface ITarget which has Request method 
            // but wants to access SpecificRequest method in some other class
            // via ITarget ONLY remember via ITarget ONLY

            //Client code
            ITarget target = new Adapter(new Adaptee());
            target.Request();
        }
    }

    public interface ITarget
    {
        void Request();
    }

    public class Adapter : ITarget
    {
        private IAdaptee adaptee;

        public Adapter(IAdaptee adaptee)
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
