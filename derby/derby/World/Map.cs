using SampSharp.GameMode.Pools;
using SampSharp.GameMode.World;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace derby.World
{
    public class Map : IdentifiedPool<Map>, IIdentifiable
    {
        public List<GtaVehicle> TargetVehicle { get; set; }
    }
}
