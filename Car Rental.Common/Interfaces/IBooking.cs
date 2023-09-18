using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_Rental.Common.Interfaces;

public interface IBooking
{
    string RegNo { get; }
    string Customer { get; }
    string KmRented { get; }
    string KmReturned { get; }
    string DateRented { get; }
    string DateReturned { get; }
    string TotalCost { get; }
    string Status { get; }


}
