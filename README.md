# EKVIP Command Calculator

Console application that keeps a value and changes it with commands (increment, decrement, double, randadd & undo).

Example with start value 1:

```
increment -> 2
increment -> 3
increment -> 4
double    -> 8
undo      -> 4
undo      -> 3
```

## How to run

Need .NET SDK 10 or newer

```bash
cd EKVIPCommandCalculator
dotnet run --project EKVIPCommandCalculator -- 1
```

The number after `--` is the start value. If no number is given, it starts with 1.

## How it works

- Every command is its own class and implements `ICommand` (`Perform` and `Undo`).
- `CommandFactory` uses the factory pattern to return a command based on user input.
- Command names are defined in one place, in the `CommandNames` constants file.
- Performed commands are pushed on a stack. `undo` pops the last one and calls its `Undo`.
- `randadd` remembers the number it added, so undo can subtract exactly that number.

## Tests

Unit tests are written with xUnit in the `EKVIPCommandCalculator.Tests` project.

- `IncrementTests`, `DecrementTests`, `DoubleTests` - each command and its undo, also having with negative values
- `RandAddTests` - value always changes, added number is between -4 and 4 and never 0, undo always gives back the exact value, multiple randadd commands are undone one by one
- `UndoTests` - undo with empty history keeps the value, undo reverts the last command
- `CommandFactoryTests` - factory returns the right command, unknown command returns null
- `CommandWorkflowTests` - the example from the task (2, 3, 4, 8, 4, 3) and the same flow with randadd in between

## Project structure

```
EKVIPCommandCalculator/
├── EKVIPCommandCalculator.slnx
├── README.md
├── EKVIPCommandCalculator/                 console application
│   ├── Commands/                           one class per command as mentioned in the requirement
│   │   ├── Contracts/
│   │   │   └── ICommand.cs
│   │   ├── DecrementCommand.cs
│   │   ├── DoubleCommand.cs
│   │   ├── IncrementCommand.cs
│   │   ├── RandAddCommand.cs
│   │   └── UndoCommand.cs
│   ├── CommandFactory.cs
│   ├── CommandNames.cs
│   ├── Program.cs
│   └── EKVIPCommandCalculator.csproj
└── EKVIPCommandCalculator.Tests/           unit tests (xUnit)
    ├── CommandFactoryTests.cs
    ├── CommandWorkflowTests.cs
    ├── DecrementTests.cs
    ├── DoubleTests.cs
    ├── IncrementTests.cs
    ├── RandAddTests.cs
    ├── UndoTests.cs
    └── EKVIPCommandCalculator.Tests.csproj
```

## Assumptions

- The start value is a whole number. If none is given, 1 is used.
- `randadd` adds a random number between -4 and 4. It never adds 0, because that wouldn't change the result, so 0 is replaced with 1.
- `undo` with no command left shows a "nothing to undo" message and keeps the current value.
- `undo` itself can't be undone and there is no redo command.
- If the command does not exist, "Command not found" is printed.
- Negative values are allowed, e.g. start at 1, `decrement` twice gives -1, and `double` gives -2. But `increment` will increase positive value 