using ScooterRental.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScooterRental
{
    public class ScooterService : IScooterService
    {
        private readonly IList<Scooter> _scooters;

        public ScooterService(List<Scooter> scooters)
        {
            _scooters = scooters;   
        }

        public void AddScooter(string id, decimal pricePerMinute)
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new InvalidIdException();
            }

            if (pricePerMinute <= 0)
            {
                throw new InvalidPriceException();
            }

            if (_scooters.Any(scooter => scooter.Id == id))
            {
                throw new DuplicateScooterException();
            }

            _scooters.Add(new Scooter(id, pricePerMinute));
        }

        public Scooter GetScooterById(string scooterId)
        {
            var scooter = _scooters.FirstOrDefault(scooter=>scooter.Id==scooterId);

            if (scooter == null)
            {
                throw new ScooterNotFoundException();
            }

            return scooter;
        }

        public IList<Scooter> GetScooters()
        {
            if (_scooters.Count() == 0)
            {
                throw new EmptyScootersException();
            }

            return _scooters;
        }

        public void RemoveScooter(string id)
        {
            var scooter=_scooters.FirstOrDefault(scooter => scooter.Id == id);

            if (scooter == null)
            {
                throw new ScooterNotFoundException();
            }

            _scooters.Remove(scooter);
        }
    }
}
