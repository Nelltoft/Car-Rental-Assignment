using Car_Rental.Common.Classes;
using Car_Rental.Common.Enums;
using Car_Rental.Common.Interfaces;
using Car_Rental.Data.Interfaces;


namespace Car_Rental.Business.Classes;

public class BookingProcessor
{
    private readonly IData _db;

    public int InputKmReturned;
    public int InputId;

    public bool InProgress = false;
    public bool ShowCustomerAlert = false;
    public bool ShowVehicleAlert = false;
    public bool ShowRentAlert = false;

    public Car Vehicle = new();
    public Customer Customer = new();

    public VehicleTypes Type;

    public BookingProcessor(IData db) => _db = db;
    public string[] VehicleTypeNames => _db.VehicleTypeNames;
    public string[] VehicleStatusNames => _db.VehicleStatusNames;
    public string ProcessingInProgress => InProgress ? "Opacity: 50%; Pointer-Events: none" : "Opacity: default; pointer-event: default";
    public string DisplayProcessing => InProgress ? "Display: Block" : "Display: None";
    public string ShowCustomerAlertMessage => ShowCustomerAlert ? "Display: Block" : "Display: None";
    public string ShowVehicleAlertMessage => ShowVehicleAlert ? "Display: Block" : "Display: None";
    public string ShowRentAlertMessage => ShowRentAlert ? "Display: Block" : "Display: None";

    public IEnumerable<IPerson> GetCustomers() => _db.Get<IPerson>(null);
    public IPerson? GetPerson(int ssn)
    {
        var person = _db.Single<IPerson>(p => p.SocialSecurityNumber == ssn);
        return person;
    }
    public IEnumerable<IVehicle> GetVehicles() => _db.Get<IVehicle>(null);
    public IVehicle? GetVehicle(int vehicleId)
    {
        var vehicle = _db.Single<IVehicle>(v => v.Id == vehicleId);
        return vehicle;
    }
    public IVehicle? GetVehicle(string regNo)
    {
        var vehicle = _db.Single<IVehicle>(v => v.RegNO == regNo);
        return vehicle;
    }
    public IEnumerable<IBooking> GetBookings() => _db.Get<IBooking>(null);
    public IBooking GetBooking(int vehicleId)
    {
        var booking = _db.Single<IBooking>(b => b.Id == vehicleId);

        if (booking is not null)
            return booking;

        throw new InvalidOperationException("Something went wrong");
    }
    public void AddVehicle(string regNo, string make, double odometer, double kmCost, int dayCost, VehicleTypes type)
    {
        if (regNo == String.Empty || make == String.Empty || odometer < 0 || kmCost == 0 || dayCost < 0)
        {
            ShowVehicleAlert = true;
        }
        else
        {
            if (type == VehicleTypes.Motorcyle)
            {
                _db.Add<IVehicle>(new Motorcycle(_db.NextVehicleId, regNo, make, odometer, kmCost, dayCost, type, VehicleStatuses.Available));
                ShowVehicleAlert = false;
            }
            else
            {
                _db.Add<IVehicle>(new Car(_db.NextVehicleId, regNo, make, odometer, kmCost, dayCost, type, VehicleStatuses.Available));
                ShowVehicleAlert = false;
            }
        }
    }
    public void AddCustomer(int socialSecurityNumber, string firstName, string lastName)
    {
        if (socialSecurityNumber == 0 || firstName == String.Empty || lastName == String.Empty)
        {
            ShowCustomerAlert = true;
        }
        else
        {
            _db.Add<IPerson>(new Customer(_db.NextPersonId, firstName, lastName, socialSecurityNumber));
            ShowCustomerAlert = false;
        }
    }
    public async Task RentVehicle(int vehicleId, int customerId)
    {
        if (vehicleId < 1 || customerId < 1)
        {
            ShowRentAlert = true;
        }
        else
        {
            InProgress = true;
            await Task.Delay(5000);
            _db.RentVehicle(vehicleId, customerId);
            InProgress = false;
            ShowRentAlert = false;
        }
    }
    public async Task ReturnVehicle(int vehicleId, int distance)
    {
        InProgress = true;
        await Task.Delay(5000);
        _db.ReturnVehicle(vehicleId, distance);
        InProgress = false;
        InputKmReturned = 0;

    }
}
