var input = File.ReadAllLines("input.txt").Select(int.Parse).ToArray();

void Part1()
{
    var increased = 0;

    for (int i = 1; i < input.Length; i++)
    {
        if (input[i] > input[i - 1])
        {
            increased++;
        }
    }

    Console.WriteLine(increased);
}

void Part2()
{
    var increased = 0;
    var chunkCount = 3;
    var sums = Enumerable.Range(0, input.Length - chunkCount + 1).Select(i => input.Skip(i).Take(chunkCount)).Select(l => l.Sum()).ToArray();

    for (int i = 1; i < sums.Length; i++)
    {
        if (sums[i] > sums[i - 1])
        {
            increased++;
        }
    }

    Console.WriteLine(increased);
}

Part1();
Part2();
