namespace PocketCaddy.Model
{
    public class RolloutOptions
    {
        public double HeadWindLong { get; set; }
        public double TailWindLong  { get; set; }
        public double HeadWindShort  { get; set; }
        public double TailWindShort  { get; set; }
        public bool IncludeSideOffset { get; set; }

        public double DriverSideOffsetFactor { get; set; }
        public double WoodSideOffsetFactor { get; set; }
        public double LongIronSideOffsetFactor { get; set; }
        public double ShortIronSideOffsetFactor { get; set; }
        public double WedgeSideOffsetFactor { get; set; }
        public double RoughIronSideOffsetFactor { get; set; }
        public double SandWedgeSideOffsetFactor { get; set; }

        public RolloutOptions()
        {
            SetDefaultValues();
        }
        
        public void SetDefaultValues()
        {
            IncludeSideOffset = false;

            // Driver, Wood, Long Iron, Rough Iron, Sand Wedge
            HeadWindLong = 0.07;
            TailWindLong = 0.05;

            // Short Iron, Wedge
            HeadWindShort = 0.058333;
            TailWindShort = 0.07;

            // Side offset factors for default values
            DriverSideOffsetFactor = 1.5d;
            WoodSideOffsetFactor = 1.5d;
            LongIronSideOffsetFactor = 1.5d;
            ShortIronSideOffsetFactor = 1.5d;
            WedgeSideOffsetFactor = 1.5d;
            RoughIronSideOffsetFactor = 1.5d;
            SandWedgeSideOffsetFactor = 1.5d;
        }

        public double GetHeadWind(int clubType)
        {
            if (clubType == 3 || clubType == 4)
                return HeadWindShort;
            return HeadWindLong;
        }

        public double GetTailWind(int clubType)
        {
            if (clubType == 3 || clubType == 4)
                return TailWindShort;
            return TailWindLong;
        }

        public double GetSideOffsetFactor(int clubType)
        {
            var rtn = clubType switch
            {
                0 => DriverSideOffsetFactor,
                1 => WoodSideOffsetFactor,
                2 => LongIronSideOffsetFactor,
                3 => ShortIronSideOffsetFactor,
                4 => WedgeSideOffsetFactor,
                5 => RoughIronSideOffsetFactor,
                6 => SandWedgeSideOffsetFactor,
                7 => throw new ArgumentException(),
            };

            return rtn;
        }
    }
}