var file = File.ReadAllLines("data.csv");

var table  = new List<List<char>>();

int endOfTable = GetEndOfTable();
//read table from file
for (int i = 1; i < file[endOfTable].Length; i += 4)
{
    table.Add(new List<char>());
    for (int j = endOfTable - 1; j >= 0; j--)
    {
        if (file[j][i] != 32)
            table[i / 4].Add(file[j][i]);
    }
}

//move
for (int i = endOfTable + 2; i < file.Length; i++)
{
    var dataLine = file[i].Split(" ");
    MakeMoveP1(int.Parse(dataLine[3]), int.Parse(dataLine[5]), int.Parse(dataLine[1]));
}
PrintResi();
Console.WriteLine();

//part 2

#region part2


table = new List<List<char>>();

endOfTable = GetEndOfTable();
//read table from file
for (int i = 1; i < file[endOfTable].Length; i += 4)
{
    table.Add(new List<char>());
    for (int j = endOfTable - 1; j >= 0; j--)
    {
        if (file[j][i] != 32)
            table[i / 4].Add(file[j][i]);
    }
}
//move
for (int i = endOfTable + 2; i < file.Length; i++)
{
    var dataLine = file[i].Split(" ");
    MakeMoveP2(int.Parse(dataLine[3]), int.Parse(dataLine[5]), int.Parse(dataLine[1]));
}
PrintResi();

#endregion

void MakeMoveP2(int from, int to, int items)
{
    from--;
    to--;
    for (int i = 0; i > 0; i--)
    {
        int row = table[from].Count - i;
        table[to].Add(table[from][row]);
        table[from].Remove(table[from][row]);
    }
}
void MakeMoveP1(int from, int to, int items)
{
    from--;
    to--;
    for (int i = 0; i <items; i++)
    {
        int row = table[from].Count-1;
        table[to].Add(table[from][row]);
        table[from].Remove(table[from][row]);
    }
}

int GetEndOfTable()
{
    for (var i = 0; i < file.Length; i++)
    {
        var line = file[i];
        if (line.Contains("1"))
        {
            return i;
        }
    }

    return file.Length;
}

void PrintResi()
{
    for (int i = 0; i < table.Count; i++)
    {
        Console.Write(table[i][table[i].Count-1]);
        
    }
}