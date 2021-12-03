using System.Text;

var input = File.ReadAllLines("input.txt").Select(x => x.ToArray()).ToArray();

void Part1()
{
    var gammaStrBuilder = new StringBuilder();

    for (var j = 0; j < input[0].Length; j++)
    {
        var bits = new List<char>();
        for (int i = 0; i < input.Length; i++)
        {
            bits.Add(input[i][j]);
        }
        gammaStrBuilder.Append(bits.GroupBy(x => x).OrderByDescending(x => x.Count()).Select(g => g.Key).First());   
    }

    var gammaStr = gammaStrBuilder.ToString();

    int gamma = Convert.ToInt32(gammaStr, 2);
    int epsilon = Convert.ToInt32(new string(gammaStr.Select(x => x == '0' ? '1' : '0').ToArray()), 2);

    
    Console.WriteLine(gamma * epsilon);
}

void Part2()
{
    
}

Part1();
Part2();