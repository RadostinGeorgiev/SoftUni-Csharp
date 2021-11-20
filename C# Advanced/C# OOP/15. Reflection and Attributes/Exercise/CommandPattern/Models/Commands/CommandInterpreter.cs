using System;
using System.Linq;
using System.Reflection;
using CommandPattern.Core.Contracts;

namespace CommandPattern.Models.Commands
{
    public class CommandInterpreter : ICommandInterpreter
    {
        private const string PostfixName = "Command";
        public string Read(string args)
        {
            string[] input = args.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string commandName = input[0] + PostfixName;
            string[] commandArgs = input.Skip(1).ToArray();

            Assembly assembly = Assembly.GetCallingAssembly();

            Type classType = assembly.GetTypes().FirstOrDefault(t => t.Name.ToLower() == commandName.ToLower());

            if (classType == null)
            {
                throw new ArgumentException("Invalid command type!");
            }

            ICommand commandInstance = (ICommand)Activator.CreateInstance(classType);
            string result = commandInstance.Execute(commandArgs);

            return result;
        }
    }
}