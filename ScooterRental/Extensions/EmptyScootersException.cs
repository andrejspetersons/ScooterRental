namespace ScooterRental.Extensions
{
    public class EmptyScootersException:Exception
    {
        public EmptyScootersException():base("No scooters were added")
        {
            
        }
    }
}