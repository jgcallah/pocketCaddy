
namespace PocketCaddy.Model
{
    public class UserBag
    {
        public ClubData Driver;
        public ClubData Wood;
        public ClubData LongIron;
        public ClubData ShortIron;
        public ClubData Wedge;
        public ClubData RoughIron;
        public ClubData SandWedge;

        public UserBag()
        {
            SetDefaultValues();
        }

        public void SetDefaultValues()
        {
            Driver = ClubData.Pulse_6();
            Wood = ClubData.Vortex_7();
            LongIron = ClubData.Eclipse_10();
            ShortIron = ClubData.Magnolia_7();
            Wedge = ClubData.Torque_8();
            SandWedge = ClubData.Catalyst_8();
            RoughIron = ClubData.Forge_8();
        }

        public List<ClubData> GetClubs()
        {
            var rtn = new List<ClubData>()
            {
                Driver,
                Wood,
                LongIron,
                ShortIron,
                Wedge,
                SandWedge,
                RoughIron
            };

            return rtn;
        }
    }
}