var input = File.ReadAllLines("input.txt").Skip(1).Chunk(6);
var pickedNumbers = File.ReadAllLines("input.txt").First().Split(',').Select(int.Parse);
var boards = PopulateBoards(input);

void Part1()
{
    foreach(var number in pickedNumbers)
    {
        foreach(var board in boards)
        {
            if(board.CheckValue(number))
            {
                var unmarkedSum = board.Cells.Where(x => !x.Checked).Sum(x => x.Value);
                Console.WriteLine(unmarkedSum * number);
                return;
            }
        }
    }
}

void Part2()
{
    foreach (var number in pickedNumbers)
    {
        foreach (var board in boards.Where(x => !x.HasWon))
        {
            if (board.CheckValue(number))
            {
                var unmarkedSum = board.Cells.Where(x => !x.Checked).Sum(x => x.Value);
                Console.WriteLine(unmarkedSum * number);
                board.HasWon = true;
            }
        }
    }
}

Part1();
Part2();

static List<Board> PopulateBoards(IEnumerable<string[]> input)
{
    var boards = new List<Board>();

    foreach (var boardArr in input)
    {
        var cells = new List<Cell>();
        for (int i = 1; i < boardArr.Length; i++)
        {
            cells.AddRange(boardArr[i].Split(' ', StringSplitOptions.RemoveEmptyEntries).Select((x, c) => new Cell(i, c, int.Parse(x))));
        }

        boards.Add(new Board { Cells = cells });
    }

    return boards;
}

class Board
{
    public List<Cell> Cells { get; init; }
    public bool HasWon { get; set; } = false;
    public bool HasBingo(int lastValue)
    {
        var cell = Cells.FirstOrDefault(x => x.Value == lastValue);

        if(cell == null)
        {
            return false;
        }

        return Cells.Where(x => x.Col == cell.Col).All(x => x.Checked) || Cells.Where(x => x.Row == cell.Row).All(x => x.Checked);   
    }

    public bool CheckValue(int value)
    {
        Cells.FirstOrDefault(x => x.Value == value)?.Check();

        return HasBingo(value);
    }
}

class Cell
{
    public Cell(int row, int col, int value)
    {
        Value = value;
        Row = row;
        Col = col;
        Checked = false;
    }
    public int Value { get; }
    public int Row { get; }
    public int Col { get; }
    public bool Checked { get; private set; }
    public void Check()
    {
        Checked = true;
    }
}
