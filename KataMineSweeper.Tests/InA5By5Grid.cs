using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KataMineSweeper.Tests
{
  [TestClass]
  public class InA5By5Grid
  {
    private MineField _mineField;
    private const char NOTHING = ' ';

    [TestInitialize]
    public void TestInit()
    {
      _mineField = new MineField(5, 5);
    }

    [TestMethod]
    public void OneMineOnTopLeft()
    {
      // Arrange 
      _mineField.AddMine(Position.From(1, 1));
  
      // Assert
      Assert.AreEqual('1', _mineField.Guess(Position.From(2, 1)));
      Assert.AreEqual('1', _mineField.Guess(Position.From(1, 2)));
      Assert.AreEqual('1', _mineField.Guess(Position.From(2, 2)));
      Assert.AreEqual(NOTHING, _mineField.Guess(Position.From(4, 3)));
      Assert.AreEqual('*', _mineField.Guess(Position.From(1, 1)));
    }

    [TestMethod]
    public void OneMineOnTopLeftAndOneCenter()
    {
      // Arrange 
      _mineField.AddMine(Position.From(1, 1));
      _mineField.AddMine(Position.From(3, 3));

      // Assert
      Assert.AreEqual('1', _mineField.Guess(Position.From(2, 1)));
      Assert.AreEqual('1', _mineField.Guess(Position.From(1, 2)));
      Assert.AreEqual('2', _mineField.Guess(Position.From(2, 2)));
      Assert.AreEqual('*', _mineField.Guess(Position.From(3, 3)));
    }

    [TestMethod]
    public void OneMineOnTopLeftAndOneCenterAndOneMiddleLeft()
    {
      // Arrange 
      _mineField.AddMine(Position.From(1, 1));
      _mineField.AddMine(Position.From(3, 3));
      _mineField.AddMine(Position.From(1, 3));

      // Assert
      Assert.AreEqual('1', _mineField.Guess(Position.From(2, 1)));
      Assert.AreEqual('2', _mineField.Guess(Position.From(1, 2)));
      Assert.AreEqual('3', _mineField.Guess(Position.From(2, 2)));
      Assert.AreEqual('*', _mineField.Guess(Position.From(3, 3)));
    }

    [TestMethod]
    public void TreeMines()
    {
      // Arrange 
      _mineField.AddMine(Position.From(1, 1));
      _mineField.AddMine(Position.From(3, 4));
      _mineField.AddMine(Position.From(3, 3));

      // Assert
      Assert.AreEqual('1', _mineField.Guess(Position.From(2, 1)));
      Assert.AreEqual('1', _mineField.Guess(Position.From(1, 2)));
      Assert.AreEqual('2', _mineField.Guess(Position.From(2, 3)));
      Assert.AreEqual(NOTHING, _mineField.Guess(Position.From(3, 1)));
    }

    [TestMethod]
    public void Diagonal()
    {
      // Arrange 
      _mineField.AddMine(Position.From(3, 2));
      _mineField.AddMine(Position.From(1, 4));
      
      // Assert
      Assert.AreEqual(NOTHING, _mineField.Guess(Position.From(3, 5)));
    }
  }
}
