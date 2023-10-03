using Car_Rental.Common.Classes;
using Car_Rental.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_Rental.Common.Extensions;

public static class VehicleExtensions
{    
    public static double Duration(this DateTime startDate, DateTime endDate)
    {
        double daysRented = (endDate - startDate).Days + 1;
        return daysRented;
    }
}
