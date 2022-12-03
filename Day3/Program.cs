//part1
var file = File.ReadAllLines("data.csv");

int sum = 0;
foreach (var line in file)
{
    var data = new []{line.Substring(0,line.Length/2), line.Substring((int)(line.Length / 2f+0.5))};
    foreach (var ch in data[0])
    {
        if (data[1].Contains(ch))
        {
            sum += ch.ToString().ToLower() == ch.ToString() 
                ? (int) ch - 'a'+1
                : (int)ch - 'A' + 27;
            break;
        }
    }
    

}

Console.WriteLine(sum);

//part2
sum = 0;
for (int i = 0; i < file.Length; i += 3)
{
    var data = new []{file[i], file[i + 1], file[i + 2]};
    foreach (var ch in data[0])
    {
        if (data[1].Contains(ch) && data[2].Contains(ch))
        {
            sum += ch.ToString().ToLower() == ch.ToString()
                ? (int)ch - 'a' + 1
                : (int)ch - 'A' + 27;
            break;
        }
    }


}
    Console.WriteLine(sum);