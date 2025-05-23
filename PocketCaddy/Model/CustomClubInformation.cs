
namespace PocketCaddy.Model
{
    public class CustomClubInformation
    {
        public ClubData Driver { get; set; }
        public ClubData Wood { get; set; }
        public ClubData LongIron { get; set; }
        public ClubData ShortIron { get; set; }
        public ClubData Wedge { get; set; }
        public ClubData RoughIron { get; set; }
        public ClubData SandWedge { get; set; }

        public CustomClubInformation()
        {
            SetDefaultValues();
        }

        private void SetDefaultValues()
        {
            Driver = ClubData.Pulse_7();
            Driver.Name = "Custom";
            Driver.ID = "Custom";

            Wood = ClubData.Vortex_7();
            Wood.Name = "Custom";
            Wood.ID = "Custom";

            LongIron = ClubData.Swoop_7();
            LongIron.Name = "Custom";
            LongIron.ID = "Custom";

            ShortIron = ClubData.Magnolia_7();
            ShortIron.Name = "Custom";
            ShortIron.ID = "Custom";

            Wedge = ClubData.Torque_8();
            Wedge.Name = "Custom";
            Wedge.ID = "Custom";

            RoughIron = ClubData.Forge_8();
            RoughIron.Name = "Custom";
            RoughIron.ID = "Custom";

            SandWedge = ClubData.Catalyst_8();
            SandWedge.Name = "Custom";
            SandWedge.ID = "Custom";
        }
    }
}