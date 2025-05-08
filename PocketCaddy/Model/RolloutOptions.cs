namespace PocketCaddy.Model
{
    public class RolloutOptions
    {
        public double HeadWindLong { get; set; }
        public double TailWindLong  { get; set; }
        public double HeadWindShort  { get; set; }
        public double TailWindShort  { get; set; }

        public RolloutOptions()
        {
            SetDefaultValues();
        }
        
        public void SetDefaultValues()
        {
            // Driver, Wood, Long Iron, Rough Iron, Sand Wedge
            HeadWindLong = 0.07;
            TailWindLong = 0.05;

            // Short Iron, Wedge
            HeadWindShort = 0.058333;
            TailWindShort = 0.07;
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
    }
}