using System;
using System.Collections.Generic;
using System.Text;

namespace Eatech.FleetManager.ApplicationCore.Models
{
    public class Filters
    {
        public int? MinYear { get; set; }
        public int? MaxYear { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
    }
}
