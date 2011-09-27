using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace KataMineSweeper
{
  internal class DummyBad : Dummy
  {
    private double DisabilityAmount()
    {
      if (_seniority < 2) return 0;
      if (_monthDisabled > 12) return 0;
      if (_isPartTime) return 0;

      return _amount*_disabilityRate;
    }

    public void UpdateTotalPrice()
    {
      if (IsSpecialDeal())
      {
        _totalPrice = _price*GetDealRate();
        Save();
      }
      else
      {
        _totalPrice = _price*GetRegularRate();
        Save();
      }
    }

    public double CalcCharge(DateTime date, double quantity)
    {
      double charge;

      if (date.Before(SUMMER_START) || date.After(SUMMER_END))
        charge = quantity*_winterRate + _winterServiceCharge;
      else
        charge = quantity*_summerRate;

      return charge;
    }

    public void Display(Customer customer)
    {
      if (customer == null)
        Console.WriteLine("no name");
      else Console.WriteLine(customer.Name);
    }

    private double GetPayAmount()
    {
      double result;
      if (_isDead) result = DeadAmount();
      else
      {
        if (_isSeparated) result = SeparetedAmount();
        else
        {
          if (_isRetired) result = RetiredAmount();
          else result = NormalPayAmount();
        }
      }
      return result;
    }

    private void Process(string state)
    {
      if (!String.IsNullOrEmpty(state) && state != "IDLE")
      {
        // ...
      }
    }

    private double GetSpeed(VehiculeType vehiculeType)
    {
      switch (vehiculeType)
      {
        case VehiculeType.Car:
          return GetBaseSpeed();
        case VehiculeType.Truck:
          return GetBaseSpeed()*LoadFactor();
        case VehiculeType.Plane:
          return GetBaseSpeed() - WindDragVector();
        default:
          throw new NotImplementedException();
      }
    }

    // ReSharper disable ConvertToConstant.Local

    private class Loan
    {
      private double Capital()
      {
        var result = 0.0;
        // ...
        // many different implementations
        // ...
        return result;
      }
    }

    private class DispatcherSample
    {
      private void ExcecuteAction(string actionName)
      {
        if (actionName == "Save")
        {
          // Lots of code
        }
        else if (actionName == "Delete")
        {
          // Lots of code
        } // many other else is statements
      }
    }

    private class ObjectParamter
    {
      private readonly List<Transaction> _transactions =
        new List<Transaction>();

      public IEnumerable<Transaction> GetTransactions(
        DateTime start, DateTime end)
      {
        var result =
          from t in _transactions
          where t.ReceivedTimestamp >= start
                && t.ReceivedTimestamp < end
          select t;
        return result;
      }
    }

    public void Write(byte[] buffer,
                      int offset,
                      int length,
                      byte pad)
    {
      // implementation
    }
  }
}