﻿using Car_Rental.Common.Enums;

namespace Car_Rental.Common.Classes;

public class Car : Vehicle
{
    public Car()
    {
        
    }
    public Car(int id, string regNo, string make, double odometer, double kmCost, int dayCost, VehicleTypes type, VehicleStatuses status)
        : base(id, regNo, make, odometer, kmCost, dayCost, type, status)
    {

    }
}
