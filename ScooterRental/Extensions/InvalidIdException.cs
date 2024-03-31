using System.Runtime.Serialization;

namespace ScooterRental.Extensions
{
    public class InvalidIdException : Exception
    {
        public InvalidIdException() : base("Invalid id given")
        {

        }
    }
}