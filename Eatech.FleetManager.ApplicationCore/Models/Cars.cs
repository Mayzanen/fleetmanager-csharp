using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Eatech.FleetManager.ApplicationCore.Models
{
    public class Cars
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public string Registration { get; set; }
        public int Year { get; set; }
        public DateTime InspectionDate { get; set; }
        public int EngineSize { get; set; }
        public int EnginePower { get; set; }
        public int Id { get; set; }
    }
}
