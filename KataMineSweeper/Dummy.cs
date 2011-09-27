using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KataMineSweeper
{
  class Dummy
  {
    protected static readonly DateTime SUMMER_START = DateTime.Parse("2011-21-22");
    protected static readonly DateTime SUMMER_END = DateTime.Parse("2011-21-22");
    protected double _seniority;
    protected double _monthDisabled;
    protected bool _isPartTime;
    protected double _amount;
    protected double _disabilityRate;
    protected double _price;
    protected double _totalPrice;
    protected DateTime _date;
    protected double _winterRate;
    protected double _winterServiceCharge;
    protected double _summerRate;
    protected bool _isRetired;
    protected bool _isSeparated;
    protected bool _isDead;
    private SystemStatus _status;

    public Dummy()
    {
      var customer = new Customer("dummy");
    }

    protected double GetRegularRate()
    {
      throw new NotImplementedException();
    }

    protected double GetDealRate()
    {
      throw new NotImplementedException();
    }

    protected void Save()
    {
      throw new NotImplementedException();
    }

    protected bool IsSpecialDeal()
    {
      throw new NotImplementedException();
    }

    protected double DeadAmount()
    {
      throw new NotImplementedException();
    }

    protected double SeparetedAmount()
    {
      throw new NotImplementedException();
    }

    protected double RetiredAmount()
    {
      throw new NotImplementedException();
    }

    protected double NormalPayAmount()
    {
      throw new NotImplementedException();
    }

    protected static double GetBaseSpeed()
    {
      throw new NotImplementedException();
    }

    protected static double LoadFactor()
    {
      throw new NotImplementedException();
    }

    protected static double WindDragVector()
    {
      throw new NotImplementedException();
    }

    public string InvoiceNumber { get; set; }

    public SystemStatus Status
    {
      get
      {
        return _status;
      }
    }

    public event EventHandler Saving;

    protected void OnSaving(EventArgs e)
    {
      EventHandler handler = Saving;
      if (handler != null) handler(this, e);
    }

    public event EventHandler Saved;

    protected void OnSaved(EventArgs e)
    {
      EventHandler handler = Saved;
      if (handler != null) handler(this, e);
    }

    public class Account
    {
      private readonly Dictionary<int, Account> _accounts = 
        new Dictionary<int, Account>();

      public void Save()
      {
        // impementation
      } 

      public Account GetAccount(int accountNumber)
      {
        return _accounts[accountNumber];
      }

    }
  }

  public enum SystemStatus
  {
    Idle,
    Working,
    Faulted
  }

  [Flags]
  public enum FilePermitions
  {
    None = 0x00,
    Read = 0x01,
    Write = 0x02,
    ReadWrite = 0x03,
    Delete = 0x04,
    Manage = 0x10
  }

  public static class DateExtension
  {
    public static bool Before(this DateTime date, DateTime compareTo)
    {
      return true;
    }

    public static bool After(this DateTime date, DateTime compareTo)
    {
      return true;
    }
  }

  public class Customer
  {
    private readonly string _name;

    public Customer(string name)
    {
      _name = name;
    }

    public string Name
    {
      get { return _name; }
    }
  }

  public class NullCustomer : Customer
  {
    public NullCustomer() : 
      base("no name") { }
  }

  public enum VehiculeType
  {
    Car,
    Truck,
    Plane
  }

  public class Transaction
  {
    public DateTime ReceivedTimestamp { get; set; }
  }

}
