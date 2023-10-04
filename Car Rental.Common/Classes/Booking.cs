using Car_Rental.Common.Extensions;
using Car_Rental.Common.Interfaces;

namespace Car_Rental.Common.Classes;

public class Booking : IBooking
{
    public int Id { get; private set; }
    public IVehicle? Vehicle { get; private set; }

    public IPerson? Customer { get; private set; }

    public double KmRented { get; private set; }

    public double KmReturned { get; set; }

    public DateTime DateRented { get; private set; }

    public DateTime DateReturned { get; private set; }

    public double TotalCost { get; private set; }

    public bool Status { get; set; }
    public Booking()
    {
        
    }
    public Booking(int id, IVehicle vehicle, IPerson customer, double kmRented, double kmReturned, DateTime dateRented, DateTime dateReturned, bool status)
        => (Id, Vehicle, Customer, KmRented, KmReturned, DateRented, DateReturned, Status)
        = (id, vehicle, customer, kmRented, kmReturned, dateRented, dateReturned, status);

    double IBooking.GetTotalCost()
    {
        TotalCost = 0;
        double kmDifference = KmReturned - KmRented;
        TotalCost = (kmDifference * (Vehicle is null ? 0 : Vehicle.KmCost)) + (VehicleExtensions.Duration(DateRented, DateReturned) * (Vehicle is null ? 0 : Vehicle.DayCost));
        return TotalCost;
    }
}
