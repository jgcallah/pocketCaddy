
namespace PocketCaddy.Model
{
    public class UserSettings
    {
        public PullOptions Pull { get; set; }
        public RolloutOptions Rollout  { get; set; }

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