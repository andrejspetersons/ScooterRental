using System.Runtime.Serialization;

namespace ScooterRental.Extensions
{
    public class ScooterNotFoundException : Exception
    {
        public ScooterNotFoundException():base("Scooter not found")
        {

        }
    }
}