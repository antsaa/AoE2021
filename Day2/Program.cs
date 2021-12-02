var input = File.ReadAllLines("input.txt").Select(ParseInstruction).ToArray();

void Part1()
{
    Position pos = new(0, 0, 0);

    foreach(var instruction in input)
    {
        pos = instruction switch
        {
            Instruction i when i.Direction == "forward" => pos with { Horizontal = pos.Horizontal + i.Units },
            Instruction i when i.Direction == "down" => pos with { Depth = pos.Depth + i.Units },
            Instruction i when i.Direction == "up" => pos with { Depth = pos.Depth - i.Units }
        };
    }

    Console.WriteLine(pos.Horizontal * pos.Depth);
}

void Part2()
{
    Position pos = new(0, 0, 0);

    foreach (var instruction in input)
    {
        pos = instruction switch
        {
            Instruction i when i.Direction == "forward" => pos with { Horizontal = pos.Horizontal + i.Units, Depth = pos.Depth + (pos.Aim * i.Units) },
            Instruction i when i.Direction == "down" => pos with { Aim = pos.Aim + i.Units },
            Instruction i when i.Direction == "up" => pos with { Aim = pos.Aim - i.Units }
        };
    }

    Console.WriteLine(pos.Horizontal * pos.Depth);
}

Part1();
Part2();


static Instruction ParseInstruction(string str) => new Instruction(str.Split(' ')[0], int.Parse(str.Split(' ')[1]));

record Instruction(string Direction, int Units);

record Position(int Horizontal, int Depth, int Aim);
