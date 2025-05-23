
namespace PocketCaddy.Model
{
    public class UserBag
    {
        public ClubData Driver { get; set; }
        public ClubData Wood  { get; set; }
        public ClubData LongIron  { get; set; }
        public ClubData ShortIron  { get; set; }
        public ClubData Wedge  { get; set; }
        public ClubData RoughIron  { get; set; }
        public ClubData SandWedge  { get; set; }

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