using Car_Rental.Common.Classes;
using Car_Rental.Common.Interfaces;
using Car_Rental.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Car_Rental.Business.Classes;

public class BookingProcessor
{
    private readonly IData _db;

    public BookingProcessor(IData db) => _db = db;

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

}
