using Car_Rental.Common.Interfaces;

namespace Car_Rental.Common.Classes;

public class Customer : IPerson
{
    public int Id { get; private set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public int SocialSecurityNumber { get; set; }

    public Customer()
    {
        
    }
    public Customer(int id, string firstName, string lastName, int socialSecurityNumber)
        => (Id, FirstName, LastName, SocialSecurityNumber) = (id, firstName, lastName, socialSecurityNumber);
}
