namespace PocketCaddy.Model
{
    public class PullOptions
    {
        public double DriverAdjustment;
        public double WoodAdjustment;
        public double LongIronAdjustment;
        public double ShortIronAdjustment;
        public double WedgeAdjustment;
        public double RoughIronAdjustment;
        public double SandWedgeAdjustment;
        public double HeadWindMultiplier;
        public double TailWindMultiplier;
        public double ZeroWedgeRange;

        public void SetDefaultValues()
        {
            DriverAdjustment = 0d;
            WoodAdjustment = 0d;
            LongIronAdjustment = 0d;
            ShortIronAdjustment = 0d;
            WedgeAdjustment = 0d;
            RoughIronAdjustment = 0d;
            SandWedgeAdjustment = 0d;
            HeadWindMultiplier = 0.001;
            TailWindMultiplier = 0.001;
            ZeroWedgeRange = 16d;
        }
    }
}