using Car_Rental.Common.Classes;
using Car_Rental.Common.Enums;
using Car_Rental.Common.Interfaces;
using Car_Rental.Data.Classes;
using Car_Rental.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;


namespace Car_Rental.Business.Classes;

public class BookingProcessor
{
    private readonly IData _db;
    public int kmReturned;
    public int ssn;
    public int customerId;
    public int odometer;
    public int dayCost;
    public double kmCost;
    public string firstName = String.Empty;
    public string lastName = String.Empty;
    public string regNo = String.Empty;
    public string make = String.Empty;
    public bool InProgress = false;
    public bool ShowCustomerAlert = false;
    public bool ShowVehicleAlert = false;
    public bool ShowRentAlert = false;
    public VehicleTypes type;

    public BookingProcessor(IData db) => _db = db;
    public string[] VehicleTypeNames => _db.VehicleTypeNames;
    public string[] VehicleStatusNames => _db.VehicleStatusNames;
    public string ProcessingInProgress => InProgress ? "Opacity: 50%; Pointer-Events: none" : "Opacity: default; pointer-event: default";
    public string DisplayProcessing => InProgress ? "Display: Block" : "Display: None";
    public string ShowCustomerAlertMessage => ShowCustomerAlert ? "Display: Block" : "Display: None";
    public string ShowVehicleAlertMessage => ShowVehicleAlert ? "Display: Block" : "Display: None";
    public string ShowRentAlertMessage => ShowRentAlert ? "Display: Block" : "Display: None";

    public IEnumerable<IPerson> GetCustomers()
    {
        foreach (IPerson p in _db.Get<IPerson>(null))
        {
            yield return p;
        }
    }    
    public IPerson? GetPerson(int ssn) 
    {
        var person = _db.Single<IPerson>(p => p.SocialSecurityNumber == ssn);
        return person;
    }    
    public IEnumerable<IVehicle> GetVehicles()
    {
        foreach (IVehicle v in _db.Get<IVehicle>(null))
        {
            yield return v;
        }
    }
    public IVehicle? GetVehicle(int vehicleId) 
    {
        var vehicle = _db.Single<IVehicle>(v => v.Id == vehicleId);
        return vehicle;
    }
    public IVehicle? GetVehicle(string regNo) 
    {
        var vehicle = _db.Single<IVehicle>(v => v.RegNO == regNo);
        return vehicle;
    }
    public IEnumerable<IBooking> GetBookings()
    {
        foreach (IBooking b in _db.Get<IBooking>(null))
        {
            yield return b;
        }
    }    
    public IBooking GetBooking(int vehicleId) 
    {
        var booking = _db.Single<IBooking>(b => b.Id == vehicleId);

        if (booking is not null)
            return booking;

        throw new InvalidOperationException("Something went wrong");
    }
    
    public void AddVehicle(string regNo, string make, int odometer, double kmCost, int dayCost, VehicleTypes type)
    {
        if (regNo == String.Empty || make == String.Empty || odometer < 0 || kmCost == 0 || dayCost < 0)
        {
            ShowVehicleAlert = true;
        }
        else
        {
            if (type == VehicleTypes.Motorcyle)
            {
                _db.Add<IVehicle>(new Motorcycle(_db.NextVehicleId, regNo, make, odometer, kmCost, dayCost, type, VehicleStatuses.Available));
                ShowVehicleAlert = false;
            }
            else
            {
                _db.Add<IVehicle>(new Car(_db.NextVehicleId, regNo, make, odometer, kmCost, dayCost, type, VehicleStatuses.Available));
                ShowVehicleAlert = false;
            }
        }
    }
    public void AddCustomer(int socialSecurityNumber, string firstName, string lastName) 
    {
        if (socialSecurityNumber == 0 || firstName == String.Empty || lastName == String.Empty)
        {
            ShowCustomerAlert = true;
        }
        else
        {
            _db.Add<IPerson>(new Customer(_db.NextPersonId, firstName, lastName, socialSecurityNumber));
            ShowCustomerAlert = false;
        }
    }
    public async Task RentVehicle(int vehicleId, int customerId) 
    {
        if (vehicleId < 1 || customerId < 1)
        {
            ShowRentAlert = true;
        }
        else
        {
            InProgress = true;
            await Task.Delay(5000);
            IPerson? customer = _db.Single<IPerson>(c => c.Id == customerId);
            IVehicle? vehicle = _db.Single<IVehicle>(v => v.Id == vehicleId);
            if (vehicle is not null && customer is not null)
            {
                vehicle.Status = VehicleStatuses.Booked;
                _db.Add<IBooking>(new Booking(_db.NextBookingId, vehicle, customer, vehicle.Odometer, vehicle.Odometer, DateTime.Now, DateTime.Now, true));
                InProgress = false; 
            }
            ShowRentAlert = false;
        }
    }    
    public async Task ReturnVehicle(int vehicleId, int distance) 
    {
        InProgress = true;
        await Task.Delay(5000);
        IVehicle? vehicle = _db.Single<IVehicle>(v => v.Id == vehicleId);
        IBooking? booking = _db.Single<IBooking>(b => b.Vehicle == vehicle && b.TotalCost < 1);
        if(vehicle is not null && booking is not null) 
        {
            vehicle.Status = VehicleStatuses.Available;
            vehicle.Odometer = vehicle.Odometer + distance;
            booking.KmReturned = vehicle.Odometer;
            booking.Status = false;
            InProgress = false;
        }
        kmReturned = 0;

    }

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
