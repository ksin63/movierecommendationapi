using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieRecomendationApp.Model
{
    public class MovieSelection
    {
        public DateTime timestamp { get; set; }
        public string value { get; set; }
        public int quality { get; set; }
    }

    public class Inputs
    {
        public MovieSelection movieSelection { get; set; }
    }

    public class Input
    {
        public DateTime timestamp { get; set; }
        public Inputs inputs { get; set; }
    }

}
