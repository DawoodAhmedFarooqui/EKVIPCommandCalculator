namespace EKVIPCommandCalculator
{
    interface ICommand
    {
        int Perform(int value);
        int Undo(int value);
    }
}