namespace Car_Rental.Common.Interfaces;

public interface IBooking
{
    int Id { get; }
    IVehicle? Vehicle { get; }
    IPerson? Customer { get; }
    double KmRented { get; }
    double KmReturned { get; set; }
    DateTime DateRented { get; }
    DateTime DateReturned { get; }
    double TotalCost { get; }
    bool Status { get; set; }

    double GetTotalCost();
}
