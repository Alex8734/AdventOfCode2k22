//part1
var file = File.ReadAllLines("data.csv");
int count = 0;
foreach (var line in file)
{
    var pairs = line.Split(',');
    var pair1 = new Rooms(pairs[0]);
    var pair2 = new Rooms(pairs[1]);

    if ((pair1.Start >= pair2.Start && pair1.End <= pair2.End)
        || (pair1.Start <= pair2.Start && pair1.End >= pair2.End))
    {
        count++;
    }
}

Console.WriteLine(count);

//part2
count = 0;
foreach (var line in file)
{
    var pairs = line.Split(',');
    var pair1 = new Rooms(pairs[0]);
    var pair2 = new Rooms(pairs[1]);

    if (pair1.IsOverlapping(pair2))
    {
        count++;
    }
}

Console.WriteLine(count);

class Rooms
{ 
    public int Start { get; }
    public int End { get; }

    public Rooms(string startEnd)
    {
        var data = startEnd.Split("-");
        Start = int.Parse(data[0]);
        End = int.Parse(data[1]);
    }

    public bool IsOverlapping(Rooms rooms2)
    {
        return !(rooms2.Start > End ||
                 rooms2.End < Start);
    }
}