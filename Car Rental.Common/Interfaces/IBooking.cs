using Car_Rental.Common.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_Rental.Common.Interfaces;

public interface IBooking
{
    IVehicle Vehicle { get; }
    IPerson Customer { get; }
    int KmRented { get; }
    int KmReturned { get; }
    DateTime DateRented { get; }
    DateTime DateReturned { get; }
    double TotalCost { get; }
    IVehicle Status { get; }

    double GetTotalCost();
}
