using Car_Rental.Common.Enums;
using Car_Rental.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_Rental.Common.Classes;

public class Car : IVehicle
{
    public int Id { get; private set; }
    public string RegNO { get; private set; } = string.Empty;

    public string Make { get; private set; } = string.Empty;

    public int Odometer { get; private set; }

    public double KmCost { get; private set; }

    public int DayCost { get; private set; }

    public VehicleTypes Type { get; private set; }

    public VehicleStatuses Status { get; private set; }

    public Car(int id, string regNo, string make, int odometer, double kmCost, int dayCost, VehicleTypes type, VehicleStatuses status)
        => (Id, RegNO, Make, Odometer, KmCost, DayCost, Type, Status) = (id, regNo, make, odometer, kmCost, dayCost, type, status);

}
