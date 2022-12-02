//part1
int points = 0;

var file = File.ReadAllLines("input.csv");

foreach (var line in file)
{
    var data = line.Split(" ");

    var p1 = data[0] switch
    {
        "A" => rps.Rock,
        "B" => rps.Paper,
        "C" => rps.Sissors
    };
    rps p2 = rps.Rock; 
    switch (data[1])
    {
        case "X":
            p2 = rps.Rock;
            points += 1;
            break;
        case "Y":
            p2 = rps.Paper;
            points += 2;
            break;
        case "Z":
            p2 = rps.Sissors;
            points += 3;
            break;
    }

    if (p1.Equals(p2))
    {
        points += 3;
    }

    else if ((p1 == rps.Rock && p2 == rps.Paper)
        ||(p1 == rps.Paper && p2 == rps.Sissors)
        ||(p1 == rps.Sissors && p2 == rps.Rock))
    {
        points += 6;
    }
}

//part2
points = 0;


foreach (var line in file)
{
    var data = line.Split(" ");

    var p1 = data[0] switch
    {
        "A" => rps.Rock,
        "B" => rps.Paper,
        "C" => rps.Sissors
    };
    rps p2 = giveAther(p1, data[1]);
    switch (p2)
    {
        case rps.Rock:
            points += 1;
            break;
        case rps.Paper:
            points += 2;
            break;
        case rps.Sissors:
            points += 3;
            break;
    }

    if (p1.Equals(p2))
    {
        points += 3;
    }

    else if ((p1 == rps.Rock && p2 == rps.Paper)
             || (p1 == rps.Paper && p2 == rps.Sissors)
             || (p1 == rps.Sissors && p2 == rps.Rock))
    {
        points += 6;
    }
}

rps giveAther(rps a, string sit)
{
    if (sit == "Z")
    {
        return a switch
        {
            rps.Rock => rps.Paper,
            rps.Paper => rps.Sissors,
            rps.Sissors => rps.Rock
        };
    }

    if (sit == "X")
    {
        return a switch
        {
            rps.Rock => rps.Sissors,
            rps.Paper => rps.Rock,
            rps.Sissors => rps.Paper
        };
    }

    return a;
}
Console.WriteLine(points);

enum rps
{
    Rock,
    Paper,
    Sissors
}