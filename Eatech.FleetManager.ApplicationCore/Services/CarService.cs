using Eatech.FleetManager.ApplicationCore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eatech.FleetManager.ApplicationCore.Services
{
    public class CarService
    {
        private readonly FleetManagerContext _context;

        public CarService(FleetManagerContext context)
        {
            _context = context;
        }

        public async Task<Cars> Get(int id)
        {
            var car = await _context.Cars.FirstOrDefaultAsync(x => x.Id == id);
            return car;
        }

        public async Task<IEnumerable<Cars>> GetAll()
        {
            return (await _context.Cars.ToListAsync()).Select(c => new Cars
            {
                Id = c.Id,
                Make = c.Make,
                Model = c.Model,
                Registration = c.Registration,
                Year = c.Year,
                InspectionDate = c.InspectionDate,
                EngineSize = c.EngineSize,
                EnginePower = c.EnginePower
            });
        }

        public async Task<bool> Delete(int id)
        {
            var car = await _context.Cars.FirstOrDefaultAsync(x => x.Id == id);
            if (car == null)
            {
                return false;
            }
            _context.Cars.Remove(car);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Cars> Update(int id, Cars updatedCar)
        {
            var car = await _context.Cars.FirstOrDefaultAsync(x => x.Id == id);

            if (car == null)
            {
                return car;
            }

            //Update
            car.Make = updatedCar.Make;
            car.Model = updatedCar.Model;
            car.Registration = updatedCar.Registration;
            car.Year = updatedCar.Year;
            car.InspectionDate = updatedCar.InspectionDate;
            car.EngineSize = updatedCar.EngineSize;
            car.EnginePower = updatedCar.EnginePower;

            _context.Cars.Update(car);
            await _context.SaveChangesAsync();
            return car;
        }

        public async Task<Cars> Create(Cars newCar)
        {
            _context.Cars.Add(newCar);
            _context.SaveChanges();

            // Return added car 
            var car = await _context.Cars.FirstOrDefaultAsync(x => x.Registration == newCar.Registration);
            return car;
        }

        public async Task<IEnumerable<Cars>> GetFilteredCars(Filters filters)
        {
            int minYear = 0;
            int maxYear = 9999;

            if (filters.MinYear != null)
            {
                minYear = filters.MinYear.Value;
            }

            if (filters.MaxYear != null)
            {
                maxYear = filters.MaxYear.Value;
            }

            return (await _context.Cars.Where( x => 
                x.Year >= minYear && 
                x.Year <= maxYear &&
                (x.Make == filters.Make || string.IsNullOrEmpty(filters.Make)) &&
                (x.Model == filters.Model || string.IsNullOrEmpty(filters.Model))
                ).ToListAsync()).Select(c => new Cars
            {
                Id = c.Id,
                Make = c.Make,
                Model = c.Model,
                Registration = c.Registration,
                Year = c.Year,
                InspectionDate = c.InspectionDate,
                EngineSize = c.EngineSize,
                EnginePower = c.EnginePower
            });
        }
    }
}
