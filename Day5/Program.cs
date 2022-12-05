var file = File.ReadAllLines("data.csv");

var table  = new List<List<char>>();

int endOfTable = GetEndOfTable();

for (int i = 1; i < file[endOfTable].Length; i += 4)
{
    table.Add(new List<char>());
    for (int j = endOfTable - 1; j >= 0; j--)
    {
        if (file[j][i] != 32)
            table[i / 4].Add(file[j][i]);
    }
}

Console.WriteLine();
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

