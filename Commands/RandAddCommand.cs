namespace EKVIPCommandCalculator
{

    class RandAddCommand : ICommand
    {
        static Random random = new Random();
        int addAndUndo;
        public int Perform(int value)
        {
            addAndUndo = random.Next(-4, 5);
            
            if(addAndUndo == 0)
            {
                // explicitly set the value to 1 when random function returns 0, 
                // because the result remains same when performing randadd command
                addAndUndo = 1; 
            }
            return value + addAndUndo;
        }

        public int Undo(int value)
        {
            return value - addAndUndo;
        }
    }
}