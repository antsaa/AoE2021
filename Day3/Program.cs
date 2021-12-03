using System.Text;

var input = File.ReadAllLines("input.txt").ToList();

void Part1()
{
    var gammaStrBuilder = new StringBuilder();

    for (var j = 0; j < input[0].Length; j++)
    {
        var dominantBit = GetDominantBit(input, j);

        gammaStrBuilder.Append(dominantBit);
    }

    var gammaStr = gammaStrBuilder.ToString();

    int gamma = Convert.ToInt32(gammaStr, 2);
    int epsilon = Convert.ToInt32(new string(gammaStr.Select(x => x == '0' ? '1' : '0').ToArray()), 2);

    Console.WriteLine(gamma * epsilon);
}

void Part2()
{
    var oxygen = input;
    var co2 = File.ReadAllLines("input.txt").ToList();

    FilterRows(oxygen, '1');
    FilterRows(co2, '0');


    var oxygenRating = Convert.ToInt32(oxygen.Single(), 2);
    var co2Rating = Convert.ToInt32(co2.Single(), 2);

    Console.WriteLine(oxygenRating * co2Rating);
}

void FilterRows(List<string> input, char winningBit = '1', int columnIndex = 0)
{
    while (input.Count > 1)
    {
        var keptBits = GetDominantBit(input, columnIndex, winningBit);

        input.RemoveAll(x => x[columnIndex] != keptBits);
        FilterRows(input, winningBit, columnIndex + 1);
    };
}

static char GetDominantBit(List<string> input, int columnIndex, char winningBit = '1')
{
    var ordered = input.Select(x => x.ToCharArray()[columnIndex]).GroupBy(x => x, (key, val) => new { Char = key, Count = val.Count()}).OrderByDescending(x => x.Count).ToList();

    if(ordered.First().Count == ordered.Last().Count)
    {
        return winningBit;
    }

    return winningBit == '1' ? ordered.Select(g => g.Char).First() : ordered.Select(g => g.Char).Last();

}

Part1();
Part2();