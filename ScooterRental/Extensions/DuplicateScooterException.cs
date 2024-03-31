namespace ScooterRental.Extensions
{
    public class DuplicateScooterException : Exception
    {
        public DuplicateScooterException() : base("Duplicate scooter given")
        {

        }
    }
}