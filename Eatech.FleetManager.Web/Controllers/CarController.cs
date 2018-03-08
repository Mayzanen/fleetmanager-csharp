using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Eatech.FleetManager.ApplicationCore.Entities;
using Eatech.FleetManager.ApplicationCore.Interfaces;
using Eatech.FleetManager.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Eatech.FleetManager.Web.Controllers
{
    [Route("api/[controller]")]
    public class CarController : Controller
    {
        private readonly ICarService _carService;
        private readonly FleetManagerContext _context;

        public CarController(ICarService carService, FleetManagerContext context)
        {
            _carService = carService;
            _context = context;
        }

        /// <summary>
        ///     Example HTTP GET: api/car
        /// </summary>
        [HttpGet]
        public async Task<IEnumerable<CarDto>> Get()
        {
            return (await _context.Cars.ToListAsync()).Select(c => new CarDto
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

        /// <summary>
        ///     Example HTTP GET: api/car/570890e2-8007-4e5c-a8d6-c3f670d8a9be
        /// </summary>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var car = await _carService.Get(id);
            if (car == null)
            {
                return NotFound();
            }

            return Ok(new CarDto
            {
                Id = car.Id,
                Make = car.Make,
                Model = car.Model,
                Registration = car.Registration,
                Year = car.Year,
                InspectionDate = car.InspectionDate,
                EngineSize = car.EngineSize,
                EnginePower = car.EnginePower
            });
        }
    }
}