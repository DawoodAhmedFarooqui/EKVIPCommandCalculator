namespace EKVIPCommandCalculator.Tests
{
    public class CommandFactoryTests
    {
        [Fact]
        public void UnknownCommandReturnsNull()
        {
            CommandFactory factory = new CommandFactory(new Stack<ICommand>());

            Assert.Null(factory.ReturnCommand("asd"));
        }

        [Fact]
        public void ReturnsIncrementCommand()
        {
            CommandFactory factory = new CommandFactory(new Stack<ICommand>());

            Assert.IsType<IncrementCommand>(factory.ReturnCommand(CommandNames.Increment));
        }

        [Fact]
        public void ReturnsCorrectCommands()
        {
            CommandFactory factory = new CommandFactory(new Stack<ICommand>());

            Assert.IsType<DecrementCommand>(factory.ReturnCommand(CommandNames.Decrement));
            Assert.IsType<DoubleCommand>(factory.ReturnCommand(CommandNames.Double));
            Assert.IsType<RandAddCommand>(factory.ReturnCommand(CommandNames.RandAdd));
            Assert.IsType<UndoCommand>(factory.ReturnCommand(CommandNames.Undo));
        }
    }
}