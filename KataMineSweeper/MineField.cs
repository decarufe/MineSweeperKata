using System;
using System.Collections.Generic;
using System.Linq;

namespace KataMineSweeper
{
  public class MineField
  {
    private const char UNKNOWN = '.';
    private const char EMPTY = ' ';
    private const char NOTHING = ' ';
    private const char BOMB = '*';
    private char[][] _visibleField;
    private char[][] _hiddenField;
    private readonly int _width;
    private readonly int _height;
    private int _guessCount;

    #region Building

    public MineField(int width, int height)
    {
      _width = width;
      _height = height;
      BuildMineField();
    }

    private void BuildMineField()
    {
      _visibleField = new char[Height][];
      _hiddenField = new char[Height][];
      for (int row = 0; row < Height; row++)
      {
        _visibleField[row] = new char[Width];
        _hiddenField[row] = new char[Width];
        for (int col = 0; col < Width; col++)
        {
          _visibleField[row][col] = UNKNOWN;
          _hiddenField[row][col] = EMPTY;
        }
      }
    }

    #endregion

    #region Public interface

    public int Height
    {
      get { return _height; }
    }

    public int Width
    {
      get { return _width; }
    }

    public void AddMine(Position position)
    {
      SetField(_hiddenField, position, BOMB);
    }

    public char Guess(Position position)
    {
      Console.WriteLine("Guessing: {0}, {1}", position.ColFromLeft, position.RowFromTop);
      var info = Reveal(position);
      RenderAll(info);
      return info;
    }

    #endregion

    #region Support Method

    #region Render

    private void RenderAll(char info)
    {
      if (info == BOMB) RenderBoom();
      else RenderMain();
    }

    public void RenderMain()
    {
      RenderHeader();
      RenderRows();
    }

    private void RenderHeader()
    {
      Console.WriteLine("Render Field: {0}", ++_guessCount);

      Console.Write("   ");

      for (int col = 1; col <= Width; col++)
        Console.Write("{0,2} ", col);

      Console.WriteLine();
    }

    private void RenderRows()
    {
      for (int row = 1; row <= Height; row++)
        RenderColumns(row);
    }

    private void RenderColumns(int row)
    {
      RenderColumnHeader(row);

      for (int col = 1; col <= Width; col++)
      {
        Console.Write("[{0}]", GetField(_visibleField,
          Position.From(col, row)));
      }
      Console.WriteLine();
    }

    private static void RenderColumnHeader(int row)
    {
      Console.Write("{0,2}:", row);
    }

    private void RenderBoom()
    {
      RevealAll();
      RenderMain();
      Console.WriteLine("-=[ BOOM ]=-");
    }

    #endregion

    #region Reveal

    private char Reveal(Position position)
    {
      var info = RevealPosition(position);
      if (info == NOTHING) RevealAdjacent(position);
      return info;
    }

    private void RevealAll()
    {
      for (int row = 1; row <= Height; row++)
      {
        for (int col = 1; col <= Width; col++)
          RevealPosition(Position.From(col, row));
      }
    }

    private char RevealPosition(Position position)
    {
      char info = CalcWarning(position);
      SetField(_visibleField, position, info);
      return info;
    }

    private void RevealAdjacent(Position position)
    {
      foreach (var pos in Get360Positions(position))
      {
        if (ShouldStopLooking(pos)) continue;
        if (RevealPosition(pos) == NOTHING) RevealAdjacent(pos);
      }
    }

    private bool ShouldStopLooking(Position position)
    {
      if (!CanGo(position)) return true;
      return IsVisible(position);
    }

    private static IEnumerable<Position> Get360Positions(Position position)
    {
      yield return position.Left();
      yield return position.Up().Left();
      yield return position.Up();
      yield return position.Up().Right();
      yield return position.Right();
      yield return position.Down().Right();
      yield return position.Down();
      yield return position.Down().Left();
    }

    private bool IsVisible(Position position)
    {
      return GetField(_visibleField, position) != UNKNOWN;
    }

    #endregion

    #region Field Manipulation

    private char CalcWarning(Position position)
    {
      if (IsMineAt(position)) return BOMB;
      var warning = Get360Positions(position).Sum(pos => TryLook(pos));
      return ConvertWarningToString(warning);
    }

    private static char ConvertWarningToString(int warning)
    {
      return warning == 0 ? NOTHING : warning.ToString()[0];
    }

    private int CalcWarningSide(Position position, int warning)
    {
      warning += TryLook(position);
      warning = CalcWarningUpAndDown(position, warning);
      return warning;
    }

    private int CalcWarningUpAndDown(Position position, int warning)
    {
      warning += TryLook(position.Up());
      warning += TryLook(position.Down());
      return warning;
    }

    private int TryLook(Position position)
    {
      if (CanGo(position)) return Look(position);
      return 0;
    }

    private int Look(Position position)
    {
      return IsMineAt(position) ? 1 : 0;
    }

    private bool IsMineAt(Position position)
    {
      return GetField(_hiddenField, position) == BOMB;
    }

    private void SetField(char[][] field, Position position, char value)
    {
      field[position.RowFromTop - 1][position.ColFromLeft - 1] = value;
    }

    private char GetField(char[][] field, Position position)
    {
      return field[position.RowFromTop - 1][position.ColFromLeft - 1];
    }

    public bool CanGo(Position position)
    {
      return position.ColFromLeft >= 1 &&
             position.ColFromLeft <= Width &&
             position.RowFromTop >= 1 &&
             position.RowFromTop <= Height;
    }

    #endregion

    #endregion
  }
}