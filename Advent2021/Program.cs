Day1();
void Day1()
{
    const string inputFileName = @"App_Data\input1.txt";
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
    foreach (var currentValue in values)
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
    for (var i = 3; i < values.Count; i++)
    {
        //two of the 3 values in a rolling average will cancled each other out so ignore them
        //[-3] + [-2] + [-1]  < [-2] + [-1] + [0] = [-3] < [0]
        if (values[i - 3] < values[i])
        {
            rollingIncreases++;
        }
    }

    Console.WriteLine($"Rolling Increase: {rollingIncreases}");
}

Day2();
void Day2()
{
    const string inputFileName = @"App_Data\input2.txt";
    //read all lines, Yes I forgot where they hid this function in day 1.
    var values = File.ReadAllLines(inputFileName);
    var possition = new Possition(0, 0);
    foreach (var value in values)
    {
        var splitValue = value.Split(' ');
        var distance = int.Parse(splitValue[1]);
        switch (splitValue[0])
        {
            case "forward":
                possition.x += distance;
                break;
            case "down":
                possition.y += distance;
                break;
            case "up":
                possition.y -= distance;
                break;
            default: throw new ArgumentOutOfRangeException(nameof(splitValue));
        }
    }
    Console.WriteLine($"Postion: {possition} multiplied: {possition.x*possition.y}");
    //now part 2
    var possition2 = new Possition();
    foreach (var value in values)
    {
        var splitValue = value.Split(' ');
        var distance = int.Parse(splitValue[1]);
        switch (splitValue[0])
        {
            case "forward":
                possition2.x += distance;
                possition2.y += distance * possition2.aim;
                break;
            case "down":
                possition2.aim += distance;
                break;
            case "up":
                possition2.aim -= distance;
                break;
            default: throw new ArgumentOutOfRangeException(nameof(splitValue));
        }
    }
    Console.WriteLine($"Beter Postion: {possition2} multiplied: {possition2.x * possition2.y}");

}

public record struct Possition(int x = 0, int y = 0, int aim = 0);

