using Car_Rental.Common.Classes;
using Car_Rental.Common.Enums;
using Car_Rental.Common.Interfaces;
using Car_Rental.Data.Classes;
using Car_Rental.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Car_Rental.Business.Classes;

public class BookingProcessor
{
    private readonly IData _db;

    public BookingProcessor(IData db) => _db = db;
    public string[] VehicleTypeNames => _db.VehicleTypeNames;
    public string[] VehicleStatusNames => _db.VehicleStatusNames;
    public IEnumerable<IPerson> GetCustomers()
    {
        foreach (IPerson p in _db.Get<IPerson>(null))
        {
            yield return p;
        }
    }
    /*
    public IPerson? GetPerson(int ssn) 
    {
        int test = _db.Get<IPerson>(p => p.SocialSecurityNumber == ssn);
 
    }
    */
    public IEnumerable<IVehicle> GetVehicles()
    {
        foreach (IVehicle v in _db.Get<IVehicle>(null))
        {
            yield return v;
        }
    }
    public IEnumerable<IBooking> GetBookings()
    {
        foreach (IBooking b in _db.Get<IBooking>(null))
        {
            yield return b;
        }
    }
    /*
    public IBooking GetBooking(int vehicleId) 
    {
        foreach (IBooking b in _db.Get<IBooking>(b => b.Id == vehicleId))
        {
            return b;
        }
        throw new NotImplementedException();
    }
    */
    public void AddVehicle(string regNo, string make, int odometer, double kmCost, int dayCost, VehicleTypes type)
    {
        if (type == VehicleTypes.Motorcyle)
        {
        _db.Add<IVehicle>(new Motorcycle(_db.NextVehicleId, regNo, make, odometer, kmCost, dayCost, VehicleStatuses.Available));
        }
        _db.Add<IVehicle>(new Car(_db.NextVehicleId, regNo, make, odometer, kmCost, dayCost, type, VehicleStatuses.Available));
    }
    public void AddCustomer(int socialSecurityNumber, string firstName, string lastName) 
    {
        _db.Add<IPerson>(new Customer(_db.NextPersonId, firstName, lastName, socialSecurityNumber));
    }
    //public async Task<IBooking> RentVehicle(int vehicleId, int customerId) 
    public VehicleTypes GetVehicleType(string name) => _db.GetVehicleType(name);



    #region Code for G Assignment
    /*
    public IEnumerable<Customer> GetCustomers() 
    {
        foreach (Customer c in _db.GetPersons())
            yield return c;
    }
    public IEnumerable<IVehicle> GetVehicles()
    {
        foreach (IVehicle v in _db.GetVehicles())
            yield return v;
    }
    
    public IEnumerable<IBooking> GetBookings()
    {
        foreach (IBooking b in _db.GetBookings())
            yield return b;
    }
    */
    #endregion

}
