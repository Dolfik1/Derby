using Derby.Helper;
using SampSharp.GameMode.Events;
using SampSharp.GameMode.SAMP.Commands;
using SampSharp.GameMode.World;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Derby.World
{
    public class Player : GtaPlayer
    {
        private int VotedMapID;

        private bool isInDD;

        private Vehicle DDVehicle;

        private bool Voted;

        private bool Muted;

        private SpectateState _spectateState;
        
        private SpectatingMode _spectatingMode;

        private Player _spectatingPlayerId = null;


        public Player(int id)
            : base(id)
        {
        }

        public override void OnRequestClass(RequestClassEventArgs e)
        {

            base.OnRequestClass(e);
        }

        public override void OnConnected(EventArgs e)
        {
            GameText("~r~Destruction Derby ~w~by [RSR]DolphiN", 2000, 5);

            Color = PlayerHelper.GetRandomColor();

            base.OnConnected(e);
        }

        public override void OnSpawned(SpawnEventArgs e)
        {
            
            base.OnSpawned(e);
        }

        public override void OnDeath(DeathEventArgs e)
        {
          
            base.OnDeath(e);
        }

        public override void OnUpdate(PlayerUpdateEventArgs e)
        {
         
            base.OnUpdate(e);
        }

        public override void OnText(TextEventArgs e)
        {
            e.SendToPlayers = false;
            base.OnText(e);
            Player.SendClientMessageToAll("{0}({1}): {2}", Name, Id, e.Text);
        }
        
        [Command("hi")]
        public void hi()
        {
            SendClientMessageToAll(SampSharp.GameMode.SAMP.Color.Red, "Player {0} say hi!", this.Name);
        }

        private void SetPlayerSpectate()
        {
            this._spectateState = SpectateState.Fixed;
            this._spectatingMode = SpectatingMode.Vehicle;

            _spectatingPlayerId = Player.All.FirstOrDefault(x => x.Id > Id);
        }

        private void NextPlayerSpectate()
        { 
        
        }

        private void PrevPlayerSpectate()
        { 
        
        }
    }
}
