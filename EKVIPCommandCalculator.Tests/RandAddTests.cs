namespace EKVIPCommandCalculator.Tests
{
    public class RandAddTests
    {
        [Fact]
        public void RandAddChangeValue()
        {
            ICommand command = new RandAddCommand();
            Assert.NotEqual(10, command.Perform(10));
        }
        [Fact]
        public void RandAddUndo()
        {
            ICommand command = new RandAddCommand();
            int value = command.Perform(10);
            Assert.Equal(10, command.Undo(value));
        }

        [Fact]
        public void RandAddUndoAlwaysExact()
        {
            for (int i = 0; i<100; i++)
            {
                ICommand command = new RandAddCommand();

                int value =  command.Perform(10);
                Assert.Equal(10,command.Undo(value));
            }
        }

        [Fact]
        public void RandAddAlwaysInRange()
        {
            for (int i = 0; i<100; i++)
            {
                ICommand command = new RandAddCommand();

                // subtract the start value to get only the number which randadd command added
                int added =  command.Perform(10) - 10;
                Assert.InRange(added, -4, 4); // added number should be between -4 and 4
                Assert.NotEqual(0,added);     // added number should never be 0, because the result remains same
            }
        }

        [Fact]
        public void RandAddStartingWithNegativeIncludingUndo()
        {
            ICommand command = new RandAddCommand();
            int value = command.Perform(-20);
            Assert.InRange(value, -24, -16);
            Assert.Equal(-20, command.Undo(value));
        }

        // each randadd command remembers its own number, so undo should go back one step at a time
        [Fact]
        public void MultipleRandAddWithUndo()
        {
            Stack<ICommand> recordedCommands = new Stack<ICommand>();
            ICommand undo = new UndoCommand(recordedCommands);

            ICommand first = new RandAddCommand();
            int value1 = first.Perform(10);
            recordedCommands.Push(first);

            ICommand second = new RandAddCommand();
            int value2 = second.Perform(value1);
            recordedCommands.Push(second);

            Assert.Equal(value1, undo.Perform(value2));
            Assert.Equal(10, undo.Perform(value1));
        }
        
    }
}