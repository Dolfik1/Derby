using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace derby.Models
{
    public enum PickupType
    { 
        nitro,
        repair,
        vehiclechange
    }

    public class Racepickup
    {
        public Vector3 position { get; set; }

        public PickupType type { get; set; }

        public int respawn { get; set; }
    }
}
