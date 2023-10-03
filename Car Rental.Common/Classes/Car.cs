using Car_Rental.Common.Enums;
using Car_Rental.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_Rental.Common.Classes;

public class Car :  Vehicle
{
    public Car(int id, string regNo, string make, double odometer, double kmCost, int dayCost, VehicleTypes type, VehicleStatuses status)
        : base(id, regNo, make, odometer, kmCost, dayCost, type, status)
    {
        
    }
}
