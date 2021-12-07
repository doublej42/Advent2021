//TODO : Add Comments
const string inputFileName = @"App_Data\input.txt";

var inputFile = File.OpenText(inputFileName);
string? line;
var values = new List<long>();
while ((line = inputFile.ReadLine()) != null)
{
    try
    {
        values.Add(long.Parse(line));
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.ToString());
    }
}

var increases = 0;
long lastValue = long.MaxValue;
foreach(var currentValue in values)
{
    if (currentValue > lastValue)
    {
        increases++;
    }
    lastValue = currentValue;
}

Console.WriteLine($"Single Increase: {increases}");

//Day 1 B
var rollingIncreases = 0;
//create a rolling average of groups of 3
for(var i = 3; i < values.Count; i++)
{
    //two of the 3 values in a rolling average will cancled each other out so ignore them
    //[-3] + [-2] + [-1]  < [-2] + [-1] + [0] = [-3] < [0]
    if (values[i-3] < values[i])
    {
        rollingIncreases++;
    }
}

Console.WriteLine($"Rolling Increase: {rollingIncreases}");