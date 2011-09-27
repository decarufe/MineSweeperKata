namespace KataMineSweeper
{
  public struct Position
  {
    private Position(int colFromLeft, int rowFromTop) : this()
    {
      ColFromLeft = colFromLeft;
      RowFromTop = rowFromTop;
    }

    public int ColFromLeft { get; set; }
    public int RowFromTop { get; set; }
    
    public Position Up()
    {
      return new Position(ColFromLeft, RowFromTop - 1);
    }

    public Position Down()
    {
      return new Position(ColFromLeft, RowFromTop + 1);
    }

    public Position Left()
    {
      return new Position(ColFromLeft - 1, RowFromTop);
    }

    public Position Right()
    {
      return new Position(ColFromLeft + 1, RowFromTop);
    }

    public static Position From(int col, int row)
    {
      return new Position(col, row);
    }

    public override string ToString()
    {
      return string.Format("Col: {0}, Row: {1}", ColFromLeft, RowFromTop);
    }
  }
}