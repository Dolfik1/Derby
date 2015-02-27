using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Derby.Models
{
    public class Vector3
    {
        public float x { get; set; }

        public float y { get; set; }

        public float z { get; set; }

        public Vector3()
        {
            this.x = 0;
            this.y = 0;
            this.z = 0;
        }

        public Vector3(float x, float y)
        {
            this.x = x;
            this.y = y;
            this.z = 0;
        }

        public Vector3(float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }
    }
}
