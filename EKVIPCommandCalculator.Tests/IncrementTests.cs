namespace EKVIPCommandCalculator.Tests
{
    public class IncrementTests
    {
        [Fact]
        public void Increment()
        {
            ICommand command = new IncrementCommand();
            Assert.Equal(2, command.Perform(1));
            Assert.Equal(3, command.Perform(2));
        }

        [Fact]
        public void IncrementWithUndo()
        {
            ICommand command = new IncrementCommand();
            Assert.Equal(2, command.Perform(1));
            Assert.Equal(3, command.Perform(2));
            Assert.Equal(2, command.Undo(3));
        }
    }
}