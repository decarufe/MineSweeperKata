using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KataMineSweeper
{
  class Program
  {
    static void Main(string[] args)
    {
      var mineField = new MineField(10, 10);
      mineField.AddMine(Position.From(1, 1));
      mineField.AddMine(Position.From(3, 6));
      mineField.AddMine(Position.From(5, 5));
      mineField.AddMine(Position.From(5, 5));
      mineField.AddMine(Position.From(5, 6));
      mineField.AddMine(Position.From(6, 1));
      mineField.AddMine(Position.From(3, 3));

      Console.WriteLine();
      mineField.RenderMain();
      while (true)
      {
        string readLine = Console.ReadLine();
        string[] coords = readLine.Split(',');
        if (coords.Length != 2) break;
        int col;
        int row;
        Int32.TryParse(coords[0], out col);
        Int32.TryParse(coords[1], out row);
        if (col == 0 || row == 0) break;
        Console.Clear();
        mineField.Guess(Position.From(col, row));
      }
    }
  }
}
