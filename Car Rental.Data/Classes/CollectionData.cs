using Car_Rental.Common.Classes;
using Car_Rental.Common.Enums;
using Car_Rental.Common.Interfaces;
using Car_Rental.Data.Interfaces;
using System.Linq.Expressions;
using System.Reflection;

namespace Car_Rental.Data.Classes;

public class CollectionData : IData
{
    readonly List<IPerson> _persons = new List<IPerson>();
    readonly List<IVehicle> _vehicles = new List<IVehicle>();
    readonly List<IBooking> _bookings = new List<IBooking>();

    public CollectionData() => SeedData();

    public int NextPersonId => _persons.Count.Equals(0) ? 1 : _persons.Max(b => b.Id) + 1;
    public int NextVehicleId => _vehicles.Count.Equals(0) ? 1 : _vehicles.Max(b => b.Id) + 1;
    public int NextBookingId => _bookings.Count.Equals(0) ? 1 : _bookings.Max(b => b.Id) + 1;

    public List<T> Get<T>(Expression<Func<T, bool>>? expression)
    {
        var collections = GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
            .FirstOrDefault(f => f.FieldType == typeof(List<T>) && f.IsInitOnly)
            ?? throw new InvalidOperationException("Unsupported type");

        List<T>? result = new();

        result = collections.GetValue(this) as List<T>;

        if (result is not null)
        {
            if (expression is not null)
            {
                return result.Where(expression.Compile()).ToList();
            }
            return result;
        }
        throw new InvalidOperationException("Something went wrong");
    }

    public T? Single<T>(Expression<Func<T, bool>>? expression)
    {

        var collections = GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
            .FirstOrDefault(f => f.FieldType == typeof(List<T>) && f.IsInitOnly)
            ?? throw new InvalidOperationException("Unsupported type");

        List<T>? result = new();

        result = collections.GetValue(this) as List<T>;

        if (expression is null) return default;

        if (result is not null)
            return result.Single(expression.Compile());

        throw new InvalidOperationException("Something went wrong.");
    }

    public void Add<T>(T item)
    {
        FieldInfo[] fields = GetType().GetFields(BindingFlags.Instance | BindingFlags.NonPublic);
        foreach (var field in fields)
        {
            if (field.FieldType == typeof(List<T>))
            {
                var i = field.GetValue(this);
                List<T>? result = i as List<T>;
                result?.Add(item);
            }
        }
    }

    public void RentVehicle(int vehicleId, int customerId)
    {
        IPerson? customer = Single<IPerson>(c => c.Id == customerId);
        IVehicle? vehicle = Single<IVehicle>(v => v.Id == vehicleId);

        if (vehicle is not null && customer is not null)
        {
            vehicle.Status = VehicleStatuses.Booked;
            Add<IBooking>(new Booking(NextBookingId, vehicle, customer, vehicle.Odometer, vehicle.Odometer, DateTime.Now, DateTime.Now, true));
        }
    }

    public void ReturnVehicle(int vehicleId, double distance)
    {
        IVehicle? vehicle = Single<IVehicle>(v => v.Id == vehicleId);
        IBooking? booking = Single<IBooking>(b => b.Vehicle == vehicle && b.TotalCost < 1);
        if (vehicle is not null && booking is not null)
        {
            vehicle.Status = VehicleStatuses.Available;
            vehicle.Odometer = vehicle.Odometer + distance;
            booking.KmReturned = vehicle.Odometer;
            booking.Status = false;            
        }
    }
    public VehicleTypes GetVehicleType(string name)
    {
        if (Enum.TryParse(name, out VehicleTypes vehicleType))
        {
            return vehicleType;
        }
        else
        {
            throw new ArgumentException("Invalid vehicle type name");
        }
    }

    void SeedData()
    {
        //Customers
        _persons.Add(new Customer(NextPersonId, "Paul", "Atreides", 234978));
        _persons.Add(new Customer(NextPersonId, "Leit", "Kynes", 598234));

        //Vehicles
        _vehicles.Add(new Car(NextVehicleId, "GSB 630", "Mitsubishi", 11000, 1.3, 200, VehicleTypes.Suv, VehicleStatuses.Available));
        _vehicles.Add(new Car(NextVehicleId, "AXU 594", "Volvo", 35000, 1, 150, VehicleTypes.Combi, VehicleStatuses.Booked));
        _vehicles.Add(new Motorcycle(NextVehicleId, "SSB 352", "Pulsar", 3000, 2.1, 400, VehicleTypes.Motorcyle, VehicleStatuses.Available));

        //Bookings
        _bookings.Add(new Booking(NextBookingId, _vehicles[1], _persons[1], _vehicles[1].Odometer, 0, DateTime.Now, DateTime.Now, true));
        _bookings.Add(new Booking(NextBookingId, _vehicles[2], _persons[0], _vehicles[2].Odometer, _vehicles[2].Odometer + 300, DateTime.Now, DateTime.Now, false));
    }








}
