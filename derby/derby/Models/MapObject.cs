using SampSharp.GameMode.World;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Derby.Models
{
    public class MapObject
    {
        public Vector position { get; set; }

        public Vector rotation { get; set; }

        public int model { get; set; }
    }
}
