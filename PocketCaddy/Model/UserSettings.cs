
namespace PocketCaddy.Model
{
    public class UserSettings
    {
        public PullOptions Pull;
        public RolloutOptions Rollout;

        public UserSettings()
        {
            SetDefaultValues();
        }

        public void SetDefaultValues()
        {
            Pull = new();
            Rollout = new();
        }
    }
}