using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Eatech.FleetManager.ApplicationCore.Services;
using Eatech.FleetManager.ApplicationCore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Eatech.FleetManager.Web.Controllers
{
    [Route("api/[controller]")]
    public class CarController : Controller
    {
        private readonly CarService _service;

        public CarController(CarService service)
        {
            _service = service;
        }

        /// <summary>
        ///     Example HTTP GET: api/car
        /// </summary>
        [HttpGet]
        public async Task<IEnumerable<Cars>> Get()
        {
            return (await _service.GetAll());
        }

        /// <summary>
        ///     Example HTTP GET: api/car/13
        /// </summary>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var car = await _service.Get(id);
            if (car == null)
            {
                return NotFound();
            }

            return Ok(car);
        }

        /// <summary>
        ///     Example HTTP DELETE: api/car/13
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (await _service.Delete(id)){
                return Ok();
            }
            else{
                return NotFound();
            }
        }

        /// <summary>
        ///     Example HTTP PUT: api/car/13 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="newValues"></param>
        /// <returns> Updated car </returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Cars newValues)
        {
            if (newValues.Id != id || newValues == null)
            {
                return BadRequest();
            }

            var car = await _service.Update(id, newValues);

            if (car == null)
            {
                return NotFound();
            }

            return Ok(car);
        }

        /// <summary>
        ///     Example HTTP POST: api/car
        /// </summary>
        /// <param name="newCar"></param>
        /// <returns> New car </returns>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Cars newCar)
        {
            if (newCar == null)
            {
                return BadRequest();
            }

            var car = await _service.Create(newCar);

            if (car == null)
            {
                return BadRequest();
            }

            return Ok(car);
        }

        /// <summary>
        ///     Example HTTP POST: api/car/filteredCars
        /// </summary>
        /// <param name="filters"></param>
        /// <returns> Filtered cars </returns>
        [HttpPost("filteredCars")]
        public async Task<IEnumerable<Cars>> GetFilteredCars([FromBody] Filters filters)
        {
            if (filters == null)
            {
                return (await _service.GetAll());
            }
            return (await _service.GetFilteredCars(filters));
        }
    }
}