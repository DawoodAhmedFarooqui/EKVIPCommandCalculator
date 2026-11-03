namespace EKVIPCommandCalculator.Tests
{
    public class DoubleTests
    {
        [Fact]
        public void Double()
        {
            ICommand command = new DoubleCommand();
            Assert.Equal(4, command.Perform(2));
            Assert.Equal(8, command.Perform(4));
        }

        [Fact]
        public void DoubleWithUndo()
        {
            ICommand command = new DoubleCommand();
            Assert.Equal(8, command.Perform(4));
            Assert.Equal(4, command.Undo(8));
        }

        [Fact]
        public void DoubleNegative()
        {
            ICommand command = new DoubleCommand();
            Assert.Equal(-4, command.Perform(-2));
            Assert.Equal(-8, command.Perform(-4));
        }

        [Fact]
        public void DoubleNegativeWithUndo()
        {
            ICommand command = new DoubleCommand();
            Assert.Equal(-4, command.Perform(-2));
            Assert.Equal(-2, command.Undo(-4));
        }
    }
}