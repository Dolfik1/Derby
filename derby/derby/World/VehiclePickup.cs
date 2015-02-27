using derby.Models;
using SampSharp.GameMode.Events;
using SampSharp.GameMode.World;
using SampSharp.Streamer.World;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace derby.World
{
    class VehiclePickup
    {
        private DynamicPickup _pickup;
        private DynamicArea _area;
        private Timer _timer;
        private int _respawn;

        public VehiclePickup(int model, Vector position)
        {
            _pickup = new DynamicPickup(model, 23, position, -1, -1, null, 100.0f);
            _area = DynamicArea. CreateSphere(position, 1, -1, -1, null);

            _area.Enter += (sender, args) => _area_Enter;
        }

        public event EventHandler<PlayerEventArgs> PickedUp;

        protected void OnPickedUp(PlayerEventArgs e)
        {
            if (PickedUp != null)
                PickedUp(e);
        }

        private void _area_Enter(object sender, PlayerEventArgs e)
        {
            if (_pickup != null)
            {
                OnPickedUp(e);
                //todo: _pickup.Dispose(); set _pickup to null; set Timer _timer which respawns the _pickup.
            }
        }
    }
}
