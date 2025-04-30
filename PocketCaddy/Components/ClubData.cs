public class ClubData
{
    public string Name = string.Empty;
    public double MagicNumber;
    public int Type;
    public double MaxRange;
    public double ShotView;

    public static ClubData Eclipse(int level)
    {
        var rtn = new ClubData()
        {
            Name = $"Eclipse, {level}",
            MagicNumber = 0.925,
            Type = 2,
            MaxRange = 185,
            ShotView = 0.83
        };
        return rtn;
    }

    public static ClubData Mammoth(int level)
    {
        var rtn = new ClubData()
        {
            Name = $"Mammoth, {level}",
            MagicNumber = 0.9569,
            Type = 0,
            MaxRange = 261.8,
            ShotView = 1
        };
        return rtn;
    }
    public override string ToString()
    {
        return Name;
    }

    public static ClubData Vortex(int level)
    {
        var rtn = new ClubData()
        {
            Name = $"Vortex, {level}",
            MagicNumber = 0.9434,
            Type = 1,
            MaxRange = 222.2,
            ShotView = 0.88
        };
        return rtn;
    }
    
    public static ClubData Thunder(int level)
    {
        var rtn = new ClubData()
        {
            Name = $"Thunder, {level}",
            MagicNumber = 1.9011,
            Type = 3,
            MaxRange = 144.1,
            ShotView = 0.85
        };
        return rtn;
    }
    
    public static ClubData Torque(int level)
    {
        var rtn = new ClubData()
        {
            Name = $"Torque, {level}",
            MagicNumber = 2.2042,
            Type = 4,
            MaxRange = 99,
            ShotView = 0.94
        };
        return rtn;
    }
    public override bool Equals(object? obj)
    {
        if (obj is ClubData other)
            return Name == other.Name && Type == other.Type; // or whatever uniquely defines equality
        return false;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Name, Type);
    }

}