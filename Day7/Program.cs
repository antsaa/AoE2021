var input = File.ReadAllText("input.txt").Split(',').Select(int.Parse).ToList();

void Part1()
{
    var median = Median(input.ToArray());

    Console.WriteLine(input.Select(x => Math.Abs(x - median)).Sum());
}

double Median(int[] sourceArray)
{
    int[] sortedArray = (int[])sourceArray.Clone();
    Array.Sort(sortedArray);

    int size = sortedArray.Length;
    int mid = size / 2;
    if (size % 2 != 0)
        return sortedArray[mid];

    var value1 = sortedArray[mid];
    var value2 = sortedArray[mid - 1];
    return (sortedArray[mid] + value2) * 0.5;
}

Part1();