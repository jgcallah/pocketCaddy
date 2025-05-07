
namespace PocketCaddy.Model
{
    public enum ZeroAdjustmentOptions
    {
        WedgeOnly,
        AllClubs
    }

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
        public double ZeroAdjustmentRange;
        public ZeroAdjustmentOptions ZeroAdjustment;

        public PullOptions()
        {
            SetDefaultValues();
        }
        
        public void SetDefaultValues()
        {
            DriverAdjustment = 0d;
            WoodAdjustment = 0d;
            LongIronAdjustment = 0d;
            ShortIronAdjustment = 0d;
            WedgeAdjustment = 0d;
            RoughIronAdjustment = 0d;
            SandWedgeAdjustment = 0d;
            HeadWindMultiplier = 0.0095;
            TailWindMultiplier = 0.0095;
            ZeroAdjustmentRange = 16d;
            ZeroAdjustment = ZeroAdjustmentOptions.WedgeOnly;
        }

        internal double GetAdjustment(int clubType)
        {
            var rtn = clubType switch
            {
                0 => DriverAdjustment,
                1 => WoodAdjustment,
                2 => LongIronAdjustment,
                3 => ShortIronAdjustment,
                4 => WedgeAdjustment,
                5 => RoughIronAdjustment,
                6 => SandWedgeAdjustment,
                _ => 0d
            };

            return rtn;
        }
    }
}