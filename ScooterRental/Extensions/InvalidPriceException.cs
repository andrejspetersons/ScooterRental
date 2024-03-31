namespace ScooterRental.Extensions
{
    public class InvalidPriceException : Exception
    {
        public InvalidPriceException() : base("Invalid price given")
        {

        }
    }
}