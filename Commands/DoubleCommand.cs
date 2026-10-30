namespace EKVIPCommandCalculator
{
    class DoubleCommand : ICommand
    {
        public int Perform(int value)
        {
            return value * 2;
        }

        public int Undo(int value)
        {
            return value / 2;
        }
    }
}