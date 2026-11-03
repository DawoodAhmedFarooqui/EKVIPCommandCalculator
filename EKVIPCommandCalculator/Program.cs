namespace EKVIPCommandCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            int result = 1;
            if (args.Length > 0 && !int.TryParse(args[0], out result))
            {
                Console.WriteLine("Input should be the whole number");
                return;
            }
            
            Stack<ICommand> recordedCommands = new Stack<ICommand>();
            CommandFactory commandFactory = new CommandFactory(recordedCommands);

            while (true)
            {
                Console.Write(String.Format("Please write a command e.g ({0}, {1}, {2}, {3} & {4})", 
                                            CommandNames.Increment,
                                            CommandNames.Decrement,
                                            CommandNames.Double,
                                            CommandNames.RandAdd,
                                            CommandNames.Undo));
                string userInput = Console.ReadLine();
                ICommand command = commandFactory.ReturnCommand(userInput.Trim().ToLower());
                if (userInput == null || command == null)
                {
                    Console.WriteLine("Command not found");
                    continue;
                }

                result = command.Perform(result);

                if (userInput != CommandNames.Undo)
                {
                    recordedCommands.Push(command);
                }

                Console.WriteLine(result);
            }
        }
    }
}
