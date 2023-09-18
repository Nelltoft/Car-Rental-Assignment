using Car_Rental.Common.Classes;
using Car_Rental.Common.Enums;
using Car_Rental.Common.Interfaces;
using Car_Rental.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_Rental.Data.Classes;

public class CollectionData : IData
{
    readonly List<IPerson> _persons = new List<IPerson>();
    readonly List<IVehicle> _vehicles = new List<IVehicle>();

    public CollectionData() => SeedData();

    void SeedData() 
    {
        //Customers
        _persons.Add(new Customer("Paul", "Atreides", 234978));
        _persons.Add(new Customer("Leit", "Kynes", 598234));

        //Vehicles
        _vehicles.Add(new Car("GSB 630", "Mitsubishi", 11000, 1.3, 200, VehicleTypes.Suv, VehicleStatuses.Available));
        _vehicles.Add(new Car("AXU 594", "Volvo", 35000, 1, 150, VehicleTypes.Combi, VehicleStatuses.Booked));
        _vehicles.Add(new Motorcycle("SSB 352", "Pulsar", 3000, 2.1, 400, VehicleStatuses.Available));
    }

    public IEnumerable<IPerson> GetPersons() => _persons;

    public IEnumerable<IVehicle> GetVehicles(VehicleStatuses status = VehicleStatuses.Available) => _vehicles;

    public IEnumerable<IPerson> GetBookings()
    {
        throw new NotImplementedException();
    }
}
