using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace design_patterns.Command
{
    public class Command
    {
        public static void Main(string[] args)
        {
            // Command pattern can be used to undo redo functionality
            // Can also be used in CQRS
            ICommand lightOnCommand = new LightOnCommand(new Receiver());
            var cmdManager = new CommandManager();
            cmdManager.Invoke(lightOnCommand);
            cmdManager.Undo();
        }
    }

    public interface ICommand
    {
        bool CanExecute();
        void Execute();
        void UnExecute();
    }

    public class CommandManager // This is Invoker Class
    {
        private Stack<ICommand> stack = new Stack<ICommand>(); // stack is used for undo functionality

        public void Invoke(ICommand command)
        {
            if(command.CanExecute())
            {
                stack.Push(command);
                command.Execute();
            }
        }

        public void Undo()
        {
            while(stack.Count > 0)
            {
                var command = stack.Pop();
                command.UnExecute();
            }
        }
    }

    public class LightOnCommand : ICommand
    {
        private Receiver receiver;

        public LightOnCommand(Receiver receiver)
        {
            this.receiver = receiver;
        }
        public bool CanExecute()
        {
            return true;
        }

        public void Execute()
        {
            this.receiver.ActionExecute();
        }

        public void UnExecute()
        {
            this.receiver.ActionUnExecute();
        }
    }

    public class Receiver
    { 
        public void ActionExecute()
        {
            Console.WriteLine("Receiver executed action");
        }
        public void ActionUnExecute()
        {
            Console.WriteLine("Receiver unexecuted action");
        }
    }



}
