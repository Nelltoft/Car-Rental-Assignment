using Car_Rental.Common.Interfaces;

namespace Car_Rental.Common.Classes;

public class Customer : IPerson
{
    public int Id { get; private set; }
    public string FirstName { get; private set; } = string.Empty;
    public string LastName { get; private set; } = string.Empty;
    public int SocialSecurityNumber { get; private set; }

    public Customer(int id, string firstName, string lastName, int socialSecurityNumber)
        => (Id, FirstName, LastName, SocialSecurityNumber) = (id, firstName, lastName, socialSecurityNumber);
}
