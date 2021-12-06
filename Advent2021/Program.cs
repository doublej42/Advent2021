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

Console.WriteLine(increases);