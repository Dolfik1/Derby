using derby.Controllers;
using SampSharp.GameMode;
using SampSharp.GameMode.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace derby
{
    public class GameMode : BaseMode
    {

        protected override void OnInitialized(EventArgs e)
        {
            SetGameModeText("Destruction Derby");
            ShowPlayerMarkers(0);
            ShowNameTags(true);
            SetWorldTime(17);
            SetWeather(11);
            UsePlayerPedAnimations();
            EnableVehicleFriendlyFire();
            SetNameTagDrawDistance(110.0f);
            DisableInteriorEnterExits();

            Console.WriteLine("----------------------------------");
            Console.WriteLine("Destruction Derby by [RSR]DolphiN 2015");
            Console.WriteLine("----------------------------------");

            base.OnInitialized(e);
        }

        protected override void LoadControllers(ControllerCollection controllers)
        {
            base.LoadControllers(controllers);

            controllers.Remove<GtaPlayerController>();
            controllers.Add(new PlayerController());

            controllers.Remove<GtaVehicleController>();
            controllers.Add(new VehicleController());
        }
    }
}
