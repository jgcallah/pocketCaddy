
namespace PocketCaddy.Model
{
    public enum ZeroAdjustmentOptions
    {
        WedgeOnly,
        AllClubs
    }

    public class PullOptions
    {
        public double DriverAdjustment { get; set; }
        public double WoodAdjustment  { get; set; }
        public double LongIronAdjustment  { get; set; }
        public double ShortIronAdjustment  { get; set; }
        public double WedgeAdjustment  { get; set; }
        public double RoughIronAdjustment  { get; set; }
        public double SandWedgeAdjustment  { get; set; }
        public double HeadWindMultiplier  { get; set; }
        public double TailWindMultiplier  { get; set; }
        public double ZeroAdjustmentRange  { get; set; }
        public ZeroAdjustmentOptions ZeroAdjustment  { get; set; }

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