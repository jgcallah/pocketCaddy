namespace PocketCaddy.Model
{
    public class UserData
    {
        public string Version;
        public UserSettings Settings { get; set; }
        public UserBag Bag { get; set; }
        public ShotInfomation ShotInfo { get; set; }
        public CustomClubInformation CustomClubs { get; set; }

        public UserData()
        {
            Settings = new();
            Bag = new();
            ShotInfo = new();
            CustomClubs = new();
        }
    }
}