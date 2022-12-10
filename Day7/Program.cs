using Day7;
using Directory = Day7.Directory;
using Type = Day7.Type;

var file = System.IO.File.ReadAllLines("data.csv");
var env = new Day7.FileSystem();
string lastCommand = "";
foreach (var line in file)
{
    var data = line.Split(" ");

    switch (data[0])
    {
        case "$":
            switch (data[1])
            {
                case "cd":
                    lastCommand = "cd";
                    if (data[2] != "/")
                        env.CD(data[2]);
                    break;
                case "ls":
                    lastCommand = "ls";
                    break;
            }

            break;
        case "dir":
            if (lastCommand == "ls" && !env.CurrentDirectory.HasDirOrFile(data[1]))
            {
                env.CurrentDirectory.Add(new Day7.Directory(env.CurrentDirectory, data[1], new List<Day7.Directory>()));
            }
            break;
        default:
            if (lastCommand == "ls" && !env.CurrentDirectory.HasDirOrFile(data[1]))
            {
                env.CurrentDirectory.Add(new Day7.File(env.CurrentDirectory, data[1], int.Parse(data[0])));
            }
            break;
    }
}

Console.WriteLine(CountDirsWithLess(100000,env.Root));
Console.WriteLine(FindSmallestDirToDelete(env.Root));
int CountDirsWithLess(int maxSize, Day7.Directory dir)
{
    int sum = 0;
    if (dir.Size < maxSize && dir.Type == Type.Directory)
    {
        sum += dir.Size;
    }

    if (dir.Type == Type.Directory)
    {
        foreach (var child in dir.Childes)
        {
            sum += CountDirsWithLess(maxSize, child);
        }
    }
    return sum;
}



int FindSmallestDirToDelete(Day7.Directory dir)
{
    int smallestDir = env.Root.Size;
    int spaceToFree = 30_000_000 - (70_000_000 - env.Root.Size);

    if (dir.Size > spaceToFree && dir.Size < smallestDir && dir.Type == Type.Directory)
    {
        smallestDir = dir.Size;
    }

    if (dir.Type == Type.Directory)
    {
        foreach (var child in dir.Childes)
        {
            var temp = FindSmallestDirToDelete(child);
            if ( temp > spaceToFree && temp< smallestDir)
            {
                smallestDir = temp;
            }
        }
    }
    return smallestDir;
}

