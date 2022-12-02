var intput = File.ReadAllLines("input.csv");

var sum = new List<int>();

int currentSum = 0;
foreach (var line in intput)
{
    if (string.IsNullOrEmpty(line))
    {
        sum.Add(currentSum);
        currentSum = 0;
    }
    else
    {
        currentSum += int.Parse(line);
    }
}
sum.Sort();
Console.WriteLine(sum[^1]+ sum[^2]+sum[^3]);