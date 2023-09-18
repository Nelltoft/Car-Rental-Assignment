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

    public CollectionData() => SeedData();

    void SeedData() 
    {
        _persons.Add(new Customer("Paul", "Atreides", 234978));
        _persons.Add(new Customer("Leit", "Kynes", 598234));
    }

    public IEnumerable<IPerson> GetPersons() => _persons;

    public IEnumerable<IPerson> GetVehicles(VehicleStatuses status = VehicleStatuses.Available)
    {
        throw new NotImplementedException();
    }
    public IEnumerable<IPerson> GetBookings()
    {
        throw new NotImplementedException();
    }
}
