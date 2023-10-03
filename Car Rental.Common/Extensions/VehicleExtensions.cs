namespace Car_Rental.Common.Extensions;

public static class VehicleExtensions
{
    public static double Duration(this DateTime startDate, DateTime endDate)
    {
        double daysRented = (endDate - startDate).Days + 1;
        return daysRented;
    }
}
