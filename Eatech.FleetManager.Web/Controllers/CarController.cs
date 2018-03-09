﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Eatech.FleetManager.ApplicationCore.Services;
using Eatech.FleetManager.Web.Models;
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

        [HttpPost("create")]
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
    }
}