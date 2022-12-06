var input = File.ReadAllLines(@"data.csv");

int stacksLine = Array.FindIndex(input, line => line.StartsWith(" 1"));
int stacksNumber = input[stacksLine].Trim().Last() - '0';

var cratesStartingStack = input.Take(stacksLine).ToArray().Reverse();
var instructions = Array.FindAll(input, line => line.StartsWith("move"));

List<Stack<string>> cratesToRearrange = new List<Stack<string>>();

for (int i = 0; i < stacksNumber; i++)
{
    cratesToRearrange.Add(new Stack<string>());
}

foreach (var line in cratesStartingStack)
{
    int lineCounter = 0;
    for (int j = 1; j <= line.Length; j += 4)
    {
        var crate = line.ElementAt(j).ToString();
        if (!string.IsNullOrWhiteSpace(crate))
        {
            cratesToRearrange.ElementAt(lineCounter).Push(crate);
        }
        lineCounter++;
    }
}
foreach (var line in instructions)
{
    var moves = line.Trim().Split(' ');
    int cratesToMove = int.Parse(moves.ElementAt(1));
    int previousStack = int.Parse(moves.ElementAt(3)) - 1;
    int nextStack = int.Parse(moves.ElementAt(5)) - 1;

    while (cratesToMove > 0)
    {
        var crate = cratesToRearrange.ElementAt(previousStack).Pop();
        cratesToRearrange.ElementAt(nextStack).Push(crate);
        cratesToMove--;
    }
}

foreach (var stack in cratesToRearrange)
{
    Console.Write($"{stack.Peek()}");
}

stacksLine = Array.FindIndex(input, line => line.StartsWith(" 1"));
stacksNumber = input[stacksLine].Trim().Last() - '0';

cratesStartingStack = input.Take(stacksLine).ToArray().Reverse();
instructions = Array.FindAll(input, line => line.StartsWith("move"));

cratesToRearrange = new List<Stack<string>>();

for (int i = 0; i < stacksNumber; i++)
{
    cratesToRearrange.Add(new Stack<string>());
}

foreach (var line in cratesStartingStack)
{
    int lineCounter = 0;
    for (int j = 1; j <= line.Length; j += 4)
    {
        var crate = line.ElementAt(j).ToString();
        if (!string.IsNullOrWhiteSpace(crate))
        {
            cratesToRearrange.ElementAt(lineCounter).Push(crate);
        }
        lineCounter++;
    }
}
foreach (var line in instructions)
{
    var moves = line.Trim().Split(' ');
    int cratesToMove = int.Parse(moves.ElementAt(1));
    int previousStack = int.Parse(moves.ElementAt(3)) - 1;
    int nextStack = int.Parse(moves.ElementAt(5)) - 1;
    var miniStack = new Stack<string>();

    while (cratesToMove > 0)
    {
        var crate = cratesToRearrange.ElementAt(previousStack).Pop();
        miniStack.Push(crate);
        cratesToMove--;
    }

    while (miniStack.Count() > 0)
    {
        var crate = miniStack.Pop();
        cratesToRearrange.ElementAt(nextStack).Push(crate);
    }
}

Console.WriteLine();
foreach (var stack in cratesToRearrange)
{
    Console.Write($"{stack.Peek()}");
}
