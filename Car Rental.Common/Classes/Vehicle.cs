using Car_Rental.Common.Enums;
using Car_Rental.Common.Interfaces;

namespace Car_Rental.Common.Classes;

public abstract class Vehicle : IVehicle
{
    public int Id { get; set; }
    public string RegNO { get; set; } = string.Empty;

    public string Make { get; set; } = string.Empty;

    public double Odometer { get; set; }

    public double KmCost { get; set; }

    public int DayCost { get; set; }

    public VehicleTypes Type { get; set; }

    public VehicleStatuses Status { get; set; }

    public Vehicle(int id, string regNo, string make, double odometer, double kmCost, int dayCost, VehicleTypes type, VehicleStatuses status)
        => (Id, RegNO, Make, Odometer, KmCost, DayCost, Type, Status) = (id, regNo, make, odometer, kmCost, dayCost, type, status);
}
