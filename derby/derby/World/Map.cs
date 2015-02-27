using Derby.Models;
using SampSharp.GameMode.Pools;
using SampSharp.GameMode.World;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Derby.World
{
    public class Map
    {
        public List<Spawn> Spawns { get; set; }

        public List<VehiclePickup> Racepickups { get; set; }

        public List<MapObject> MapObjects { get; set; }

    }
}
