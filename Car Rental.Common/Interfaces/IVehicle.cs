using Car_Rental.Common.Enums;

namespace Car_Rental.Common.Interfaces;

public interface IVehicle
{
    int Id { get; }
    string RegNO { get; }
    string Make { get; }
    double Odometer { get; set; }
    double KmCost { get; }
    int DayCost { get; }
    VehicleTypes Type { get; }
    VehicleStatuses Status { get; set; }
}
