using derby.World;
using SampSharp.GameMode.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace derby.Controllers
{
    class MapController : ITypeProvider, IController
    {
        public void RegisterTypes()
        {
            Map.Register<Map>();
        }
    }
}
