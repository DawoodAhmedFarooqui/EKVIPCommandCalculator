namespace EKVIPCommandCalculator
{
    class UndoCommand : ICommand
    {
        Stack<ICommand> recordCmds;
        public UndoCommand(Stack<ICommand> _recordCmds)
        {
            recordCmds = _recordCmds; 
        }
        public int Perform(int value)
        {
            if (recordCmds != null && recordCmds.Count <= 0)
            {
                Console.WriteLine("There is nothing to undo");
                return value; // stop here otherwise it will crash to the next line due to empty stack;
            }
            return recordCmds.Pop().Undo(value);
        }

        public int Undo(int value)
        {
            return value;
        }
    }
}