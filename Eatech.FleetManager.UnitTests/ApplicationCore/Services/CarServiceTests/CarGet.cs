using System;
using System.Linq;
using Eatech.FleetManager.ApplicationCore.Interfaces;
using Eatech.FleetManager.ApplicationCore.Services;
using Xunit;

namespace Eatech.FleetManager.UnitTests.ApplicationCore.Services.CarServiceTests
{
    public class CarGet
    {
        [Fact]
        public async void AllCars()
        {
            ICarService carService = new CarService();

            var cars = (await carService.GetAll()).ToList();

            Assert.NotNull(cars);
            Assert.NotEmpty(cars);
            Assert.Equal(2, cars.Count);
        }

        [Fact]
        public async void ExistingCardWithId()
        {
            ICarService carService = new CarService();
            var carId = 12;

            var car = await carService.Get(carId);

            Assert.NotNull(car);
            Assert.Equal(carId, car.Id);
        }

        [Fact]
        public async void NonExistingCardWithId()
        {
            ICarService carService = new CarService();
            var carId = 11;

            var car = await carService.Get(carId);

            Assert.Null(car);
        }
    }
}