namespace EKVIPCommandCalculator
{
    class CommandFactory
    {
        Stack<ICommand> recordCmds;
        public CommandFactory(Stack<ICommand> _recordCmds)
        {
            recordCmds = _recordCmds; 
        }
        public ICommand ReturnCommand(string commandObjName)
        {
            switch (commandObjName)
            {
                case CommandNames.Increment: 
                return new IncrementCommand();
                case CommandNames.Decrement:
                return new DecrementCommand();
                case CommandNames.Double: 
                return new DoubleCommand();
                case CommandNames.RandAdd: 
                return new RandAddCommand();
                case CommandNames.Undo: 
                return new UndoCommand(recordCmds);
                default: return null;
            }
        }
    }
}