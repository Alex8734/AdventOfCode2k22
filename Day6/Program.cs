var file = File.ReadAllLines("data.csv");


int routineCnt = 4;

for (var i = 0; i < file[0].Length; i++)
{
    var c = file[0][i];
    if (!HasDuplicates(file[0].Substring(i,4)))
    {
        Console.WriteLine(routineCnt);
        break;
    }

    routineCnt++;
}

routineCnt = 14;
for (var i = 0; i < file[0].Length; i++)
{
    var c = file[0][i];
    if (!HasDuplicates(file[0].Substring(i, 14)))
    {
        Console.WriteLine(routineCnt);
        break;
    }

    routineCnt++;
}


bool HasDuplicates(string s)
{
    var check = string.Empty;
    foreach (var c in s)
    {
        if (check.Contains(c))
        {
            return true;
        }
        check += c;
    }
    return false;
}