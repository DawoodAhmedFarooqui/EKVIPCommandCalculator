namespace EKVIPCommandCalculator.Tests
{
    public class DecrementTests
    {
        [Fact]
        public void Decrement()
        {
            ICommand command = new DecrementCommand();
            Assert.Equal(0, command.Perform(1));
        }

        [Fact]
        public void DecrementWithLessThanZero()
        {
            ICommand command = new DecrementCommand();
            Assert.Equal(0, command.Perform(1));
            Assert.Equal(-1, command.Perform(0));
        }

        [Fact]
        public void DecrementWithLessThanZeroWithUndo()
        {
            ICommand command = new DecrementCommand();
            Assert.Equal(0, command.Perform(1));
            Assert.Equal(-1, command.Perform(0));
            Assert.Equal(0, command.Undo(-1));
        }
    }
}