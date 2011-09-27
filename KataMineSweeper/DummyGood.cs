using System;
using System.Collections.Generic;
using System.Linq;

// ReSharper disable ClassNeverInstantiated.Local
// ReSharper disable ConvertToConstant.Local
// ReSharper disable IntroduceOptionalParameters.Global
// ReSharper disable RedundantOverload.Global

namespace KataMineSweeper
{
  internal class DummyGood : Dummy
  {
    private const int PAD_BYTE = 0x00;

    private double DisabilityAmount()
    {
      if (IsNotEligibleForDisability()) return 0;

      return _amount*_disabilityRate;
    }

    private bool IsNotEligibleForDisability()
    {
      return _seniority < 2 &&
             _monthDisabled > 12 &&
             _isPartTime;
    }

    public void UpdateTotalPrice()
    {
      if (IsSpecialDeal())
        _totalPrice = _price*GetDealRate();
      else
        _totalPrice = _price*GetRegularRate();
      Save();
    }

    public double CalcCharge(DateTime date, double quantity)
    {
      double charge;

      if (IsNotSummer(date))
        charge = quantity*_winterRate + _winterServiceCharge;
      else
        charge = quantity*_summerRate;

      return charge;
    }

    private static bool IsNotSummer(DateTime date)
    {
      return date.Before(SUMMER_START) || date.After(SUMMER_END);
    }

    public void Display(Customer customer)
    {
      Console.WriteLine(customer.Name);
    }

    private double GetPayAmount()
    {
      if (_isDead) return DeadAmount();
      if (_isSeparated) return SeparetedAmount();
      if (_isRetired) return RetiredAmount();
      return NormalPayAmount();
    }

    private void Process(string state)
    {
      if (CanProcess(state))
      {
        // ...
      }
    }

    private static bool CanProcess(string state)
    {
      return IsStateAvailable(state) && state != "IDLE";
    }

    private static bool IsStateAvailable(string state)
    {
      return !String.IsNullOrEmpty(state);
    }

    private abstract class Vehicule
    {
      protected abstract double GetSpeed();
    }

    private class Car : Vehicule
    {
      protected override double GetSpeed()
      {
        return GetBaseSpeed();
      }
    }

    private class Truck : Vehicule
    {
      protected override double GetSpeed()
      {
        return GetBaseSpeed()*LoadFactor();
      }
    }

    private class Plane : Vehicule
    {
      protected override double GetSpeed()
      {
        return GetBaseSpeed() - WindDragVector();
      }
    }

    private class Loan
    {
      private readonly CapitalStrategy _strategy;

      public Loan(CapitalStrategy strategy)
      {
        _strategy = strategy;
      }

      private double Capital()
      {
        return _strategy.Capital(this);
      }
    }

    private abstract class CapitalStrategy
    {
      public abstract double Capital(Loan loan);
    }

    private class CapitalStrategy1 : CapitalStrategy
    {
      public override double Capital(Loan loan)
      {
        var result = 0.0;
        // Implementation of strategy 1
        return result;
      }
    }

    private class CapitalStrategy2 : CapitalStrategy
    {
      public override double Capital(Loan loan)
      {
        var result = 0.0;
        // Implementation of strategy 2
        return result;
      }
    }

    private class CapitalStrategy3 : CapitalStrategy
    {
      public override double Capital(Loan loan)
      {
        var result = 0.0;
        // Implementation of strategy 3
        return result;
      }
    }

    private class CommandSample
    {
      private interface ICommand
      {
        void Execute();
      }

      private readonly Dictionary<string, ICommand> _commands =
        new Dictionary<string, ICommand>();

      private void BuildCommands()
      {
        _commands.Add("Save", new SaveCommand());
        _commands.Add("Delete", new DeleteCommand());
      }

      private ICommand GetCommand(string actionName)
      {
        return _commands[actionName];
      }

      private void ExcecuteAction(string actionName)
      {
        var command = GetCommand(actionName);
        command.Execute();
      }

      private class SaveCommand : ICommand
      {
        public void Execute()
        {
          throw new NotImplementedException();
        }
      }

      private class DeleteCommand : ICommand
      {
        public void Execute()
        {
          throw new NotImplementedException();
        }
      }
    }

    private class ObjectParamter
    {
      private readonly List<Transaction> _transactions =
        new List<Transaction>();

      public IEnumerable<Transaction> GetTransactions(
        Range<DateTime> range)
      {
        var result =
          from t in _transactions
          where range.Contains(t.ReceivedTimestamp)
          select t;
        return result;
      }
    }

    private class Range<T> where T : IComparable<T>
    {
      private readonly T _start;
      private readonly T _end;

      public Range(T start, T end)
      {
        _start = start;
        _end = end;
      }

      public bool Contains(T target)
      {
        return target.CompareTo(_start) >= 0
               && target.CompareTo(_end) < 0;
      }
    }

    public void Write(byte[] buffer,
                      int offset,
                      int length,
                      byte pad = PAD_BYTE)
    {
      // implementation
    }

    public void Write(byte[] buffer,
                      int offset,
                      int length)
    {
      Write(buffer, offset, length, PAD_BYTE);
    }

    public void Write(byte[] buffer,
                      int offset)
    {
      Write(buffer, offset, buffer.Length, PAD_BYTE);
    }

    public void Write(byte[] buffer)
    {
      Write(buffer, 0, buffer.Length, PAD_BYTE);
    }
  }
}