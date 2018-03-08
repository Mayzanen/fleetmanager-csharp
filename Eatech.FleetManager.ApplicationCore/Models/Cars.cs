using System;
using System.Collections.Generic;

namespace Eatech.FleetManager.Web.Models
{
    public partial class Cars
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
