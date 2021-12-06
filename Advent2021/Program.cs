const string inputFileName = @"App_Data\input.txt";

var inputFile = File.OpenText(inputFileName);

var line = inputFile.ReadLine();
var increases = 0;
long currentValue = long.MaxValue;
try
{
    while (line != null)
    {
        var lastValue = currentValue;
        currentValue = long.Parse(line);
        if (currentValue > lastValue)
        {
            increases++;
        }
        //Console.WriteLine(line);
        line = inputFile.ReadLine();
    }
}
catch (Exception ex)
{
    Console.WriteLine(ex.ToString());
}
Console.WriteLine(increases);