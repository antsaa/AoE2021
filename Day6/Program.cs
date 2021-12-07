var input = File.ReadAllText("input.txt").Split(',').Select(int.Parse).ToArray();

void Part1()
{
    for(int d = 0; d < 80; d++)
    {
        var inserts = new List<int>();

        for(int i = 0; i < input.Length; i++)
        {
            if(input[i] == 0)
            {
                input[i] = 6;
                inserts.Add(8);
            }
            else
            {
                input[i]--;
            }
        }

        input = input.Concat(inserts).ToArray();
    }

    Console.WriteLine(input.Length);
}


void Part2()
{
    var groups = new Dictionary<int, long>
    {
        { 0, 0 },
        { 1, 0 },
        { 2, 0 },
        { 3, 0 },
        { 4, 0 },
        { 5, 0 },
        { 6, 0 },
        { 7, 0 },
        { 8, 0 },
        { 9, 0 }
    };

    foreach(var fish in input)
    {
        groups[fish]++;
    }

    for(int d = 0; d < 256; d++)
    {
        for(int i = 0; i < groups.Count; i++)
        {
            groups[9] = groups[0];
            groups[0] = groups[1];
            groups[1] = groups[2];
            groups[2] = groups[3];
            groups[3] = groups[4];
            groups[4] = groups[5];
            groups[5] = groups[6];
            groups[6] = groups[7]; 
            groups[7] = groups[8];
            groups[8] = groups[9];
            groups[9] = 0;
        }

        groups[6] += groups[8];
    }

    Console.WriteLine(groups.Sum(x => x.Value));
}

//Part1();
Part2();
