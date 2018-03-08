﻿using System;

namespace Eatech.FleetManager.ApplicationCore.Entities
{
    public class CarDto
    {
        public int Id { get; set; }

        public string Make { get; set; }

        public string Model { get; set; }

        public string Registration { get; set; }

        public int Year { get; set; }

        public DateTime InspectionDate { get; set; }

        public int EngineSize { get; set; }

        public int EnginePower { get; set; }
    }
}