public class ClubData
{
    public string Name = string.Empty;
    public double MagicNumber;
    public double Accuracy;
    public int Type;
    public double MaxRange;
    public double ShotView;

    public static ClubData Blast_7()
    {
        var rtn = new ClubData()
        {
            Name = $"Blast, 7*",
            MagicNumber = 0.4926,
            Type = 0,
            Accuracy = 41,
            MaxRange = 240 * 1.1,
            ShotView = 0.93
        };
        return rtn;
    }
    
    public static ClubData Mammoth_7()
    {
        var rtn = new ClubData()
        {
            Name = $"Mammoth, 7*",
            MagicNumber = 0.8368,
            Type = 0,
            Accuracy = 75,
            MaxRange = 235 * 1.1,
            ShotView = 0.96
        };
        return rtn;
    }
    
    public static ClubData Mammoth_8()
    {
        var rtn = new ClubData()
        {
            Name = $"Mammoth, 8",
            MagicNumber = 0.9569,
            Type = 0,
            Accuracy = 80,
            MaxRange = 238 * 1.1,
            ShotView = 1
        };
        return rtn;
    }
    
    public static ClubData Mammoth_9()
    {
        var rtn = new ClubData()
        {
            Name = $"Mammoth, 9*",
            MagicNumber = 0.9901,
            Type = 0,
            Accuracy = 80,
            MaxRange = 240 * 1.1,
            ShotView = 1
        };
        return rtn;
    }
    
    public static ClubData Everest_6()
    {
        var rtn = new ClubData()
        {
            Name = $"Everest, 6",
            MagicNumber = 0.8065,
            Type = 0,
            Accuracy = 70,
            MaxRange = 245 * 1.1,
            ShotView = 0.85
        };
        return rtn;
    }
    
    public static ClubData Everest_7()
    {
        var rtn = new ClubData()
        {
            Name = $"Everest, 7*",
            MagicNumber = 0.8696,
            Type = 0,
            Accuracy = 75,
            MaxRange = 245 * 1.1,
            ShotView = 0.90
        };
        return rtn;
    }
    
    public static ClubData Everest_8()
    {
        var rtn = new ClubData()
        {
            Name = $"Everest, 8*",
            MagicNumber = 0.9009,
            Type = 0,
            Accuracy = 75,
            MaxRange = 247 * 1.1,
            ShotView = 0.98
        };
        return rtn;
    }
    
    public static ClubData Pulse_6()
    {
        var rtn = new ClubData()
        {
            Name = $"Pulse, 6",
            MagicNumber = 0.6897,
            Type = 0,
            Accuracy = 62,
            MaxRange = 253 * 1.1,
            ShotView = 0.7
        };
        return rtn;
    }
    
    public static ClubData Pulse_7()
    {
        var rtn = new ClubData()
        {
            Name = $"Pulse, 7*",
            MagicNumber = 0.813,
            Type = 0,
            Accuracy = 70,
            MaxRange = 255 * 1.1,
            ShotView = 0.8
        };
        return rtn;
    }
    
    public static ClubData Pulse_8()
    {
        var rtn = new ClubData()
        {
            Name = $"Pulse, 8*",
            MagicNumber = 0.8475,
            Type = 0,
            Accuracy = 70,
            MaxRange = 255 * 1.1,
            ShotView = 0.91
        };
        return rtn;
    }
    
    public static ClubData CLUBNAME_LVL()
    {
        var rtn = new ClubData()
        {
            Name = $"CLUNNAME, LVL",
            MagicNumber = 0.0,
            Type = 0,
            Accuracy = 0,
            MaxRange = 0 * 1.1,
            ShotView = 0
        };
        return rtn;
    }

    public static ClubData Eclipse_10()
    {
        var rtn = new ClubData()
        {
            Name = $"Eclipse, 10",
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