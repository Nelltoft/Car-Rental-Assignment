using Car_Rental.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_Rental.Common.Classes;

public class Booking : IBooking
{
    public IVehicle Vehicle { get; private set; }

    public IPerson Customer { get; private set; }

    public int KmRented { get; private set; }

    public int KmReturned { get; private set; }

    public DateTime DateRented { get; private set; }

    public DateTime DateReturned { get; private set; }

    public double TotalCost { get; private set; }

    public IVehicle Status { get; private set; }

    public Booking(IVehicle vehicle, IPerson customer, int kmRented, int kmReturned, DateTime dateRented, DateTime dateReturned, IVehicle status)
        => (Vehicle, Customer, KmRented, KmReturned, DateRented, DateReturned, Status)
        = (vehicle, customer, kmRented, kmReturned, dateRented, dateReturned, status);

    double IBooking.GetTotalCost()
    {
        TotalCost = 0;
        double kmDifference = KmReturned - KmRented;
        double daysRented = (DateReturned.Date - DateRented.Date).Days + 1;
        TotalCost = (kmDifference * Vehicle.KmCost) + (daysRented * Vehicle.DayCost);
        return TotalCost;

    }
}
