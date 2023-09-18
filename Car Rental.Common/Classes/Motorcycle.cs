using Car_Rental.Common.Enums;
using Car_Rental.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_Rental.Common.Classes;

public class Motorcycle : IVehicle
{
    public string RegNO { get; private set; } = string.Empty;

    public string Make { get; private set; } = string.Empty;

    public int Odometer { get; private set; }

    public double KmCost { get; private set; }

    public int DayCost { get; private set; }

    public VehicleTypes Type => VehicleTypes.Motorcyle;

    public VehicleStatuses Status { get; private set; }

    public Motorcycle(string regNo, string make, int odometer, double kmCost, int dayCost, VehicleStatuses status)
        => (RegNO, Make, Odometer, KmCost, DayCost, Status) = (regNo, make, odometer, kmCost, dayCost, status);
}
