namespace PocketCaddy.Model
{
    public class UserData
    {
        public UserSettings Settings; 
        public UserBag Bag;
        public ShotInfomation ShotInfo;
        public CustomClubInformation CustomClubs;

        public UserData()
        {
            Settings = new();
            Bag = new();
            ShotInfo = new();
            CustomClubs = new();
        }
    }
}