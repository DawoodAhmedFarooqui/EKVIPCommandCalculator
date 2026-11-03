namespace EKVIPCommandCalculator.Tests
{
    public class UndoTests
    {
        [Fact]
        public void UndoWithoutHistoryCommands()
        {
            Stack<ICommand> recordedCommands = new Stack<ICommand>();
            ICommand undo = new UndoCommand(recordedCommands);

            Assert.Equal(3, undo.Perform(3));
        }
        [Fact]
        public void UndoWithIncrementCommand()
        {
            Stack<ICommand> recordedCommands = new Stack<ICommand>();
            ICommand undo = new UndoCommand(recordedCommands);

            // increment 1 to 2
            ICommand incrementCommand = new IncrementCommand();
            int result = incrementCommand.Perform(1);
            recordedCommands.Push(incrementCommand);
            Assert.Equal(2, result);

            // undo 2 to 1
            result = undo.Perform(result);
            Assert.Equal(1, result);

            // nothing left to undo
            Assert.Empty(recordedCommands);
        }
    }
}