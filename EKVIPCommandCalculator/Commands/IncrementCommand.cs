namespace EKVIPCommandCalculator
{
    class IncrementCommand : ICommand
    {
        public int Perform(int value)
        {
            return value + 1;
        }

        public int Undo(int value)
        {
            return value - 1;
        }
    }
}