namespace PocketCaddy.Model
{
    public class RolloutOptions
    {
        public double HeadWindLong;
        public double TailWindLong;
        public double HeadWindShort;
        public double TailWindShort;

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