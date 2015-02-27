using Derby.Helper;
using Derby.Models;
using SampSharp.GameMode.Events;
using SampSharp.GameMode.World;
using SampSharp.Streamer.World;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Derby.World
{
    enum VehiclePickupType
    { 
        nitro,
        repair,
        vehicle
    }

    class VehiclePickup
    {
        private DynamicPickup _pickup;
        private DynamicArea _area;
        private Timer _timer;
        private int _respawn;

        private VehiclePickupType _type;
        private int _vehicleid = 400;

        public VehiclePickup(int model, Vector position, int respawn)
        {
            _pickup = new DynamicPickup(model, 23, position, -1, -1, null, 100.0f);
            _area = DynamicArea.CreateSphere(position, 1, -1, -1, null);
            _respawn = respawn;

            _area.Enter += _area_Enter;

            if (respawn > 0)
            {
                _timer = new Timer(_respawn);//check it, maybe respawn got in seconds
                _timer.AutoReset = false;
                _timer.Elapsed += _timer_Elapsed;
            }
        }
        public VehiclePickup(int model, Vector position, int respawn, VehiclePickupType type, int vehicleid)
        {
            _pickup = new DynamicPickup(model, 23, position, -1, -1, null, 100.0f);
            _area = DynamicArea.CreateSphere(position, 1, -1, -1, null);
            _respawn = respawn;
            _vehicleid = VehicleHelper.IsCorrectID(vehicleid) ? vehicleid : 400;
            _type = type;

            _area.Enter += _area_Enter;

            if (respawn > 0)
            {
                _timer = new Timer(_respawn);//check it, maybe respawn got in seconds
                _timer.AutoReset = false;
                _timer.Elapsed += _timer_Elapsed;
            }
        }
        public VehiclePickup(int model, Vector position, int respawn, VehiclePickupType type)
        {
            _pickup = new DynamicPickup(model, 23, position, -1, -1, null, 100.0f);
            _area = DynamicArea.CreateSphere(position, 1, -1, -1, null);
            _respawn = respawn;
            _type = type;

            _area.Enter += _area_Enter;

            if (respawn > 0)
            {
                _timer = new Timer(_respawn);//check it, maybe respawn got in seconds
                _timer.AutoReset = false;
                _timer.Elapsed += _timer_Elapsed;
            }
        }

        void _timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            this._pickup.ShowInWorld(-1);
        }

        public event EventHandler<PlayerEventArgs> PickedUp;

        protected void OnPickedUp(PlayerEventArgs e)
        {
            if (PickedUp != null)
                PickedUp(this, e);
        }

        private void _area_Enter(object sender, PlayerEventArgs e)
        {
            if (_pickup != null && _pickup.IsVisibleInWorld(-1))
            {
                OnPickedUp(e);
                if(_timer != null)
                {
                    (sender as VehiclePickup)._pickup.HideInWorld(-1);
                    _timer.Start();
                }
            }
        }
    }
}
