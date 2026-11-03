namespace EKVIPCommandCalculator.Tests
{
    public class CommandWorkflowTests
    {
        [Fact]
        public void TaskExampleFlow()
        {
            Stack<ICommand> recordedCommands = new Stack<ICommand>();
            CommandFactory factory = new CommandFactory(recordedCommands);
            string[] commands = { "increment", "increment", "increment", "double", "undo", "undo" };
            int[] expected = { 2, 3, 4, 8, 4, 3 };

            int value = 1;
            for (int i = 0; i < commands.Length; i++)
            {
                ICommand cmd = factory.ReturnCommand(commands[i]);
                value = cmd.Perform(value);

                if (commands[i] != CommandNames.Undo)
                    recordedCommands.Push(cmd);

                Assert.Equal(expected[i], value);
            }
        }

        // increment > randadd > double > undo > undo
        // increment (2) > randadd (suppose +3 = 5) > double (10) > undo (5) > undo (2)        
        [Fact]
        public void TaskExampleWithRandAdd()
        {
            Stack<ICommand> recordedCommands = new Stack<ICommand>();
            CommandFactory factory = new CommandFactory(recordedCommands);
            ICommand undo = factory.ReturnCommand(CommandNames.Undo);

            int value = 1;

            ICommand cmd = factory.ReturnCommand(CommandNames.Increment);
            value = cmd.Perform(value);
            recordedCommands.Push(cmd);
            Assert.Equal(2, value); // 2

            cmd = factory.ReturnCommand(CommandNames.RandAdd);
            value = cmd.Perform(value);
            recordedCommands.Push(cmd);
            int afterRandAdd = value; // save it, and check later - suppose +3 = 5

            cmd = factory.ReturnCommand(CommandNames.Double);
            value = cmd.Perform(value);
            recordedCommands.Push(cmd);
            Assert.Equal(afterRandAdd * 2, value); //10

            value = undo.Perform(value);
            Assert.Equal(afterRandAdd, value); // 5

            value = undo.Perform(value);
            Assert.Equal(2, value); // 2
        }
    }
}