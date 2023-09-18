using Car_Rental.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_Rental.Common.Classes;

public class Customer : IPerson
{
    public string FirstName { get; private set; } = string.Empty;
    public string LastName { get; private set; } = string.Empty;
    public int SocialSecurityNumber { get; private set; }

    public Customer(string firstName, string lastName, int socialSecurityNumber)
        => (FirstName, LastName, SocialSecurityNumber) = (firstName, lastName, socialSecurityNumber);

    /*
    public void AddPerson(string firstName, string lastName, int socialSecurityNumber)
        => (FirstName, LastName, SocialSecurityNumber) = (firstName, lastName, socialSecurityNumber);
    */

    /*
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public int SocialSecurtyNumber { get; private set; }

    public Customer(string firstName, string lastName, int socialSecurityNumber) 
        => (FirstName, LastName, SocialSecurtyNumber) = (firstName, lastName, socialSecurityNumber);
    */
}
