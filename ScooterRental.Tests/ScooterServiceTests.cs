using FluentAssertions;
using ScooterRental.Extensions;

namespace ScooterRental.Tests
{
    [TestClass]
    public class ScooterServiceTests
    {
        private ScooterService _scooterService;
        private List<Scooter> _scooterList;
        private readonly string TEST_ID= "1";

        [TestInitialize]
        public void Setup()
        {
            _scooterList = new List<Scooter>();
            _scooterService = new ScooterService(_scooterList);
        }

        [TestMethod]
        public void AddScooter_Valid_Data_ScooterAdded()
        {
            _scooterService.AddScooter(TEST_ID, 0.1m);
            _scooterList.Count().Should().Be(1);
        }

        [TestMethod]
        public void AddScooter_Invalid_Price_InvalidPriceException_Expected()
        {
            Action action = () => _scooterService.AddScooter(TEST_ID, 0.0m);
            action.Should().Throw<InvalidPriceException>();
        }

        [TestMethod]
        public void AddScooter_Invalid_Id_InvalidIdException_Expected()
        {
            Action action = () => _scooterService.AddScooter("", 0.1m);
            action.Should().Throw<InvalidIdException>();
        }

        [TestMethod]
        public void AddScooter_AddDuplicateScooter_DuplicateScooterException_Expected()
        {
            _scooterList.Add(new Scooter(TEST_ID, 0.5m));
            Action action = () => _scooterService.AddScooter(TEST_ID, 0.1m);
            action.Should().Throw<DuplicateScooterException>();
        }

        [TestMethod]
        public void GetScooterById_Existing_ScooterNotFoundException_Expected()
        {
            var expectedScooter = new Scooter(TEST_ID, 1.2m);
            _scooterList.Add(expectedScooter);
            var actualScooter = _scooterService.GetScooterById(TEST_ID);
            actualScooter.Id.Should().Be(expectedScooter.Id);
            actualScooter.PricePerMinute.Should().Be(expectedScooter.PricePerMinute);
        }

        [TestMethod]
        public void GetScooterById_NotExisting_ScooterNotFoundException_Expected()
        {
            Action action = () => _scooterService.GetScooterById(TEST_ID);
            action.Should().Throw<ScooterNotFoundException>();
        }

        [TestMethod]
        public void GetScooters_Empty_EmptyScootersException_Expected()
        {
            Action action = () => _scooterService.GetScooters();
            action.Should().Throw<EmptyScootersException>();
        }

        [TestMethod]
        public void RemoveScooter_Existing_RemovedScooter_Expected()
        {
            _scooterList.Add(new Scooter(TEST_ID, 0.6m));
            _scooterService.RemoveScooter(TEST_ID);
            _scooterList.Count().Should().Be(0);
        }

        [TestMethod]
        public void RemoveScooter_NotExisting_ScooterNotFoundException_Expected()
        {
            Action action = () => _scooterService.RemoveScooter("999");
            action.Should().Throw<ScooterNotFoundException>();
        }

        
    }
}
