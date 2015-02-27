using Derby.World;
using SampSharp.GameMode.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Derby.Controllers
{
    public class PlayerController : GtaPlayerController
    {
        public override void RegisterTypes()
        {
            Player.Register<Player>();
        }
    }
}
