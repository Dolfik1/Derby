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
        public int VotedMapID;

        public bool isInDD;

        public Vehicle DDVehicle;

        public bool Voted;

        public bool Muted;


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
            GameText("~r~SA-MP: ~w~Rivershell", 2000, 5);

            Color = 0x888888FF;
            SetWorldBounds(2500.0f, 1850.0f, 631.2963f, -454.9898f);

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
            string txt = String.Format("{0}({1}): {2}", Name, Id, e.Text);
            TextEventArgs args = new TextEventArgs(txt);
            args.SendToPlayers = e.SendToPlayers;
            base.OnText(args);//e);
        }
        
        [Command("hi")]
        public void hi()
        {
            SendClientMessageToAll(SampSharp.GameMode.SAMP.Color.Red, "Player {0} say hi!", this.Name);
        }
    }
}
