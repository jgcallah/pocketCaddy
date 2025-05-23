namespace PocketCaddy.Model
{
    public class ClubData
    {
        public string Name { get; set; }  = string.Empty;
        public string ID   { get; set; } = string.Empty;
        public double MagicNumber  { get; set; }
        public double Accuracy  { get; set; }
        public int Type  { get; set; }
        public double MaxRange  { get; set; }
        public double ShotView  { get; set; }

        public double ComputePull(double elevation, double windDirection, double windStrength, double yards, int clubType, PullOptions options)
        {
            // wind speed
            var ws = windStrength;

            // elevation factor
            var ef = GetElevationFactor(elevation, options);

            // wind factor
            var wy = GetWindY(windDirection, windStrength);
            var windModifier = wy > 0d ? options.HeadWindMultiplier : options.TailWindMultiplier;
            var wf = 1 - wy * windModifier;
            
            // base pull
            var bp = 0d;

            // yards the adjust,ment becomes 0
            var zr = 0d;
            if (options.ZeroAdjustment == ZeroAdjustmentOptions.AllClubs || (options.ZeroAdjustment == ZeroAdjustmentOptions.WedgeOnly && clubType == 4))
                zr = options.ZeroAdjustmentRange;

            // set the range ratio
            var rr = (yards - zr) / (MaxRange - zr);

            // base pull
            bp = rr * MagicNumber * ws;

            // adjustment for pull method
            var adj = options.GetAdjustment(clubType);

            // effective pull
            var ep = bp * ef * wf - adj;

            return ep;
        }

        private double GetElevationFactor(double elevation, PullOptions options)
        {
            var rtn = 1 - elevation / 100d;
            if (options.AdjustElevationValues)
            {
                if (elevation > 0d)
                {
                    var effElevation = elevation - 3d;
                    if (effElevation > 0d)
                    {
                        rtn = 1 + effElevation / 100d;
                    }
                    else
                    {
                        rtn = 1d;
                    }
                }
            }
            return rtn;
        }

        public double ComputeRollout(double headWindMultiplier, double tailWindMultiplier, double windDirection, double windStrength, double currentShotView)
        {
            var baseRO = currentShotView / ShotView;
            var windY = GetWindY(windDirection, windStrength);
            var adjustment = windY > 0d
                ? tailWindMultiplier
                : headWindMultiplier;

            var finalRO = baseRO * (1 + windY * adjustment );
            return finalRO;
        }
        
        public double ComputeSideOffset(double yards, double rollOut, double yprFactor, double windDirection, double pull)
        {
            var df = yards / MaxRange;
            var ypr = yprFactor / MagicNumber * df;
            var mn = MagicNumber * df;

            var pullRings = pull * System.Math.Abs(Math.Cos(((windDirection - 3d) * 30d) / 180d * System.Math.PI));
            var pullYards = pullRings * ypr;

            var sideOffset = pullYards / yards * rollOut * ypr;
            var holeWidth = 4.25 / 36d;

            var rtn = sideOffset / holeWidth;
            return rtn;
        }

        double GetWindY(double windDirection, double windStrength)
        {
            var rtn = System.Math.Sin(((windDirection - 3d) * 30d) / 180d * System.Math.PI) * windStrength;
            return rtn;
        }

        public static ClubData? GetDriver(string name)
        {
            if(Blast_7().Name == name)
                return Blast_7();
            if(Everest_6().Name == name)
                return Everest_6();
            if(Everest_7().Name == name)
                return Everest_7();
            if(Everest_8().Name == name)
                return Everest_8();
            if(Mammoth_7().Name == name)
                return Mammoth_7();
            if(Mammoth_8().Name == name)
                return Mammoth_8();
            if(Mammoth_9().Name == name)
                return Mammoth_9();
            if(Pulse_6().Name == name)
                return Pulse_6();
            if(Pulse_7().Name == name)
                return Pulse_7();
            if(Pulse_8().Name == name)
                return Pulse_8();
            return Pulse_7();
        }

        public static IEnumerable<string> GetAllDriverNames()
        {
            yield return Blast_7().Name;
            yield return Everest_6().Name;
            yield return Everest_7().Name;
            yield return Everest_8().Name;
            yield return Mammoth_7().Name;
            yield return Mammoth_8().Name;
            yield return Mammoth_9().Name;
            yield return Pulse_6().Name;
            yield return Pulse_7().Name;
            yield return Pulse_8().Name;
        }

        public static ClubData? GetWood(string name)
        {
            if (Bullseye_7().Name == name)
                return Bullseye_7();
            if (Corsair_8().Name == name)
                return Corsair_8();
            if (Corsair_9().Name == name)
                return Corsair_9();
            if (Vortex_6().Name == name)
                return Vortex_6();
            if (Vortex_7().Name == name)
                return Vortex_7();
            if (Vortex_8().Name == name)
                return Vortex_8();
            return Vortex_7();
        }

        public static IEnumerable<string> GetAllWoodNames()
        {
            yield return Bullseye_7().Name;
            yield return Corsair_8().Name;
            yield return Corsair_9().Name;
            yield return Vortex_6().Name;
            yield return Vortex_7().Name;
            yield return Vortex_8().Name;
        }

        public static ClubData? GetLongIron(string name)
        {
            if (Eclipse_8().Name == name)
                return Eclipse_8();
            if (Eclipse_9().Name == name)
                return Eclipse_9();
            if (Eclipse_10().Name == name)
                return Eclipse_10();
            if (Sabre_6().Name == name)
                return Sabre_6();
            if (Sabre_7().Name == name)
                return Sabre_7();
            if (Sabre_8().Name == name)
                return Sabre_8();
            if (Swoop_6().Name == name)
                return Swoop_6();
            if (Swoop_7().Name == name)
                return Swoop_7();
            if (Swoop_8().Name == name)
                return Swoop_8();
            if (Zenith_9().Name == name)
                return Zenith_9();
            return Swoop_7();
        }

        public static IEnumerable<string> GetAllLongIronNames()
        {
            yield return Eclipse_8().Name;
            yield return Eclipse_9().Name;
            yield return Eclipse_10().Name;
            yield return Sabre_6().Name;
            yield return Sabre_7().Name;
            yield return Sabre_8().Name;
            yield return Swoop_6().Name;
            yield return Swoop_7().Name;
            yield return Swoop_8().Name;
            yield return Zenith_9().Name;
        }

        public static ClubData? GetShortIron(string name)
        {
            if (Blaze_6().Name == name)
                return Blaze_6();
            if (Blaze_7().Name == name)
                return Blaze_7();
            if (Blaze_8().Name == name)
                return Blaze_8();
            if (Magnolia_7().Name == name)
                return Magnolia_7();
            if (Magnolia_8().Name == name)
                return Magnolia_8();
            if (Python_7().Name == name)
                return Python_7();
            if (Python_8().Name == name)
                return Python_8();
            if (Python_9().Name == name)
                return Python_9();
            if (Thunder_9().Name == name)
                return Thunder_9();
            if (Thunder_10().Name == name)
                return Thunder_10();
            return Thunder_10();
        }

        public static IEnumerable<string> GetAllShortIronNames()
        {
            yield return Blaze_6().Name;
            yield return Blaze_7().Name;
            yield return Blaze_8().Name;
            yield return Magnolia_7().Name;
            yield return Magnolia_8().Name;
            yield return Python_7().Name;
            yield return Python_8().Name;
            yield return Python_9().Name;
            yield return Thunder_9().Name;
            yield return Thunder_10().Name;
        }

        public static ClubData? GetWedge(string name)
        {
            if (Torque_8().Name == name)
                return Torque_8();
            if (Torque_9().Name == name)
                return Torque_9();
            return Torque_8();
        }

        public static IEnumerable<string> GetAllWedgeNames()
        {
            yield return Torque_8().Name;
            yield return Torque_9().Name;
        }

        public static ClubData? GetRoughIron(string name)
        {
            if (Forge_8().Name == name)
                return Forge_8();
            if (Forge_9().Name == name)
                return Forge_9();
            return Forge_8();
        }

        public static IEnumerable<string> GetAllRoughIronNames()
        {
            yield return Forge_8().Name;
            yield return Forge_9().Name;
        }

        public static ClubData? GetSandWedge(string name)
        {
            if (Catalyst_8().Name == name)
                return Catalyst_8();
            return Catalyst_8();
        }

        public static IEnumerable<string> GetAllSandWedgeNames()
        {
            yield return Catalyst_8().Name;
        }


        
        public static ClubData Blast_7()
        {
            var rtn = new ClubData()
            {
                Name = $"Blast, 7*",
                ID = $"Blast, 7",
                MagicNumber = 0.4926,
                Type = 0,
                Accuracy = 41,
                MaxRange = System.Math.Round(240 * 1.1, 1),
                ShotView = 0.93
            };
            return rtn;
        }

        public static ClubData Blast_8()
        {
            var rtn = new ClubData()
            {
                Name = $"Blast, 8",
                ID = $"Blast, 8",
                MagicNumber = 0.4926,
                Type = 0,
                Accuracy = 41,
                MaxRange = System.Math.Round(242 * 1.1, 1),
                ShotView = 0.93
            };
            return rtn;
        }

        public static ClubData Mammoth_7()
        {
            var rtn = new ClubData()
            {
                Name = $"Mammoth, 7*",
                ID = $"Mammoth, 7",
                MagicNumber = 0.8368,
                Type = 0,
                Accuracy = 75,
                MaxRange = System.Math.Round(235 * 1.1, 1),
                ShotView = 0.96
            };
            return rtn;
        }
        
        public static ClubData Mammoth_8()
        {
            var rtn = new ClubData()
            {
                Name = $"Mammoth, 8",
                ID = $"Mammoth, 8",
                MagicNumber = 0.9569,
                Type = 0,
                Accuracy = 80,
                MaxRange = System.Math.Round(238 * 1.1, 1),
                ShotView = 1
            };
            return rtn;
        }
        
        public static ClubData Mammoth_9()
        {
            var rtn = new ClubData()
            {
                Name = $"Mammoth, 9",
                ID = $"Mammoth, 9",
                MagicNumber = 0.9901,
                Type = 0,
                Accuracy = 80,
                MaxRange = System.Math.Round(241 * 1.1, 1),
                ShotView = 1
            };
            return rtn;
        }
        
        public static ClubData Everest_6()
        {
            var rtn = new ClubData()
            {
                Name = $"Everest, 6",
                ID = $"Everest, 6",
                MagicNumber = 0.8065,
                Type = 0,
                Accuracy = 70,
                MaxRange = System.Math.Round(245 * 1.1, 1),
                ShotView = 0.85
            };
            return rtn;
        }
        
        public static ClubData Everest_7()
        {
            var rtn = new ClubData()
            {
                Name = $"Everest, 7*",
                ID = $"Everest, 7",
                MagicNumber = 0.8696,
                Type = 0,
                Accuracy = 75,
                MaxRange = System.Math.Round(245 * 1.1, 1),
                ShotView = 0.90
            };
            return rtn;
        }
        
        public static ClubData Everest_8()
        {
            var rtn = new ClubData()
            {
                Name = $"Everest, 8*",
                ID = $"Everest, 8",
                MagicNumber = 0.9009,
                Type = 0,
                Accuracy = 75,
                MaxRange = System.Math.Round(247 * 1.1, 1),
                ShotView = 0.98
            };
            return rtn;
        }
        
        public static ClubData Pulse_6()
        {
            var rtn = new ClubData()
            {
                Name = $"Pulse, 6",
                ID = $"Pulse, 6",
                MagicNumber = 0.6897,
                Type = 0,
                Accuracy = 62,
                MaxRange = System.Math.Round(253 * 1.1, 1),
                ShotView = 0.7
            };
            return rtn;
        }
        
        public static ClubData Pulse_7()
        {
            var rtn = new ClubData()
            {
                Name = $"Pulse, 7",
                ID = $"Pulse, 7",
                MagicNumber = 0.813,
                Type = 0,
                Accuracy = 70,
                MaxRange = System.Math.Round(253 * 1.1, 1),
                ShotView = 0.8
            };
            return rtn;
        }
        
        public static ClubData Pulse_8()
        {
            var rtn = new ClubData()
            {
                Name = $"Pulse, 8",
                ID = $"Pulse, 8",
                MagicNumber = 0.8475,
                Type = 0,
                Accuracy = 70,
                MaxRange = System.Math.Round(257 * 1.1, 1),
                ShotView = 0.91
            };
            return rtn;
        }
        
        public static ClubData Bullseye_7()
        {
            var rtn = new ClubData()
            {
                Name = $"Bullseye, 7",
                ID = $"Bullseye, 7",
                MagicNumber = 0.8475,
                Type = 1,
                Accuracy = 50,
                MaxRange = System.Math.Round(200 * 1.1, 1),
                ShotView = 0.92
            };
            return rtn;
        }

        public static ClubData Bullseye_8()
        {
            var rtn = new ClubData()
            {
                Name = $"Bullseye, 8",
                ID = $"Bullseye, 8",
                MagicNumber = 0.8475,
                Type = 1,
                Accuracy = 50,
                MaxRange = System.Math.Round(200 * 1.1, 1),
                ShotView = 0.95
            };
            return rtn;
        }

        public static ClubData Corsair_8()
        {
            var rtn = new ClubData()
            {
                Name = $"Corsair, 8",
                ID = $"Corsair, 8",
                MagicNumber = 1d,
                Type = 1,
                Accuracy = 78,
                MaxRange = System.Math.Round(200 * 1.1, 1),
                ShotView = 0.86
            };
            return rtn;
        }
        
        public static ClubData Corsair_9()
        {
            var rtn = new ClubData()
            {
                Name = $"Corsair, 9",
                ID = $"Corsair, 9",
                MagicNumber = 1.0132d,
                Type = 1,
                Accuracy = 78,
                MaxRange = System.Math.Round(202 * 1.1, 1),
                ShotView = 0.89
            };
            return rtn;
        }
        
        public static ClubData Vortex_6()
        {
            var rtn = new ClubData()
            {
                Name = $"Vortex, 6*",
                ID = $"Vortex, 6",
                MagicNumber = 0.625,
                Type = 1,
                Accuracy = 55,
                MaxRange = System.Math.Round(200 * 1.1, 1),
                ShotView = 0.76
            };
            return rtn;
        }
        
        public static ClubData Vortex_7()
        {
            var rtn = new ClubData()
            {
                Name = $"Vortex, 7",
                ID = $"Vortex, 7",
                MagicNumber = 0.9434,
                Type = 1,
                Accuracy = 75,
                MaxRange = System.Math.Round(202 * 1.1, 1),
                ShotView = 0.88
            };
            return rtn;
        }
        
        public static ClubData Vortex_8()
        {
            var rtn = new ClubData()
            {
                Name = $"Vortex, 8*",
                ID = $"Vortex, 8",
                MagicNumber = 0.9569,
                Type = 1,
                Accuracy = 75,
                MaxRange = System.Math.Round(205 * 1.1, 1),
                ShotView = 0.96
            };
            return rtn;
        }

        public static ClubData Nexus_8()
        {
            var rtn = new ClubData()
            {
                Name = $"Nexus, 8",
                ID = $"Nexus, 8",
                MagicNumber = 0,
                Type = 1,
                Accuracy = 98,
                MaxRange = System.Math.Round(200 * 1.1, 1),
                ShotView = 0.98
            };
            return rtn;
        }

        public static ClubData Eclipse_10()
        {
            var rtn = new ClubData()
            {
                Name = $"Eclipse, 10",
                ID = $"Eclipse, 10",
                MagicNumber = 0.925,
                Type = 2,
                Accuracy = 70,
                MaxRange = System.Math.Round(168 * 1.1, 1),
                ShotView = 0.83
            };
            return rtn;
        }

        public static ClubData Eclipse_9()
        {
            var rtn = new ClubData()
            {
                Name = $"Eclipse, 9*",
                ID = $"Eclipse, 9",
                MagicNumber = 0.7054,
                Type = 2,
                Accuracy = 60,
                MaxRange = System.Math.Round(165 * 1.1, 1),
                ShotView = 0.74
            };
            return rtn;
        }

        public static ClubData Eclipse_8()
        {
            var rtn = new ClubData()
            {
                Name = $"Eclipse, 8*",
                ID = $"Eclipse, 8",
                MagicNumber = 0.6061,
                Type = 2,
                Accuracy = 50,
                MaxRange = System.Math.Round(165 * 1.1, 1),
                ShotView = 0.68
            };
            return rtn;
        }

        public static ClubData Sabre_6()
        {
            var rtn = new ClubData()
            {
                Name = $"Sabre, 6*",
                ID = $"Sabre, 6",
                MagicNumber = 2.34,
                Type = 2,
                Accuracy = 98,
                MaxRange = System.Math.Round(185 * 1.1, 1),
                ShotView = 0.86
            };
            return rtn;
        }


        public static ClubData Sabre_7()
        {
            var rtn = new ClubData()
            {
                Name = $"Sabre, 7",
                ID = $"Sabre, 7",
                MagicNumber = 2.5641,
                Type = 2,
                Accuracy = 100,            
                MaxRange = System.Math.Round(185 * 1.1, 1),
                ShotView = 0.90
            };
            return rtn;
        }

        public static ClubData Sabre_8()
        {
            var rtn = new ClubData()
            {
                Name = $"Sabre, 8",
                ID = $"Sabre, 8",
                MagicNumber = 2.5641,
                Type = 2,
                Accuracy = 100,
                MaxRange = System.Math.Round(185 * 1.1, 1),
                ShotView = 0.97
            };
            return rtn;
        }

        public static ClubData Zenith_9()
        {
            var rtn = new ClubData()
            {
                Name = $"Zenith, 9",
                ID = $"Zenith, 9",
                MagicNumber = 2.4096,
                Accuracy = 100,
                Type = 2,
                MaxRange = System.Math.Round(174 * 1.1, 1),
                ShotView = 0.89
            };
            return rtn;
        }

        public static ClubData Swoop_6()
        {
            var rtn = new ClubData()
            {
                Name = $"Swoop, 6",
                ID = $"Swoop, 6",
                MagicNumber = 1.0288,
                Type = 2,
                Accuracy = 70,
                MaxRange = System.Math.Round(182 * 1.1, 1),
                ShotView = 0.74
            };
            return rtn;
        }


        public static ClubData Swoop_7()
        {
            var rtn = new ClubData()
            {
                Name = $"Swoop, 7",
                ID = $"Swoop, 7",
                MagicNumber = 1.0788,
                Type = 2,
                Accuracy = 0.75,
                MaxRange = System.Math.Round(182 * 1.1, 1),
                ShotView = 0.81
            };
            return rtn;
        }

        public static ClubData Swoop_8()
        {
            var rtn = new ClubData()
            {
                Name = $"Swoop, 8*",
                ID = $"Swoop, 8",
                MagicNumber = 1.1111,
                Type = 2,
                Accuracy = 75,
                MaxRange = System.Math.Round(185 * 1.1, 1),
                ShotView = 0.88
            };
            return rtn;
        }

        public static ClubData Launcher_8()
        {
            var rtn = new ClubData()
            {
                Name = $"Launcher, 8",
                ID = $"Launcher, 8",
                MagicNumber = 0,
                Type = 2,
                Accuracy = 84,
                MaxRange = System.Math.Round(164 * 1.1, 1),
                ShotView = 0.87
            };
            return rtn;
        }

        public static ClubData Magnolia_7()
        {
            var rtn = new ClubData()
            {
                Name = $"Magnolia, 7",
                ID = $"Magnolia, 7",
                MagicNumber = 2.8571,
                Type = 3,
                Accuracy = 100,
                MaxRange = System.Math.Round(127 * 1.1, 1),
                ShotView = 0.88
            };
            return rtn;
        }

        public static ClubData Magnolia_8()
        {
            var rtn = new ClubData()
            {
                Name = $"Magnolia, 8*",
                ID = $"Magnolia, 8",
                MagicNumber = 2.9851,
                Type = 3,
                Accuracy = 100,
                MaxRange = System.Math.Round(128 * 1.1, 1),
                ShotView = 0.92
            };
            return rtn;
        }

        public static ClubData Python_7()
        {
            var rtn = new ClubData()
            {
                Name = $"Python, 7*",
                ID = $"Python, 7",
                MagicNumber = 0.9524,
                Type = 3,
                Accuracy = 55,
                MaxRange = System.Math.Round(145 * 1.1, 1),
                ShotView = 0.84
            };
            return rtn;
        }

        public static ClubData Python_8()
        {
            var rtn = new ClubData()
            {
                Name = $"Python, 8",
                ID = $"Python, 8",
                MagicNumber = 1.2048,
                Type = 3,
                Accuracy = 65,
                MaxRange = System.Math.Round(145 * 1.1, 1),
                ShotView = 0.91
            };
            return rtn;
        }

        public static ClubData Python_9()
        {
            var rtn = new ClubData()
            {
                Name = $"Python, 9",
                ID = $"Python, 9",
                MagicNumber = 1.224,
                Type = 3,
                Accuracy = 65,
                MaxRange = System.Math.Round(145 * 1.1, 1),
                ShotView = 0.94
            };
            return rtn;
        }

        public static ClubData Thunder_9()
        {
            var rtn = new ClubData()
            {
                Name = $"Thunder, 9*",
                ID = $"Thunder, 9",
                MagicNumber = 1.385,
                Type = 3,
                Accuracy = 75,
                MaxRange = System.Math.Round(131 * 1.1, 1),
                ShotView = 0.64
            };
            return rtn;
        }

        public static ClubData Thunder_10()
        {
            var rtn = new ClubData()
            {
                Name = $"Thunder, 10",
                ID = $"Thunder, 10",
                MagicNumber = 1.9011,
                Type = 3,
                Accuracy = 85,
                MaxRange = System.Math.Round(131 * 1.1, 1),
                ShotView = 0.85
            };
            return rtn;
        }

        public static ClubData Blaze_6()
        {
            var rtn = new ClubData()
            {
                Name = $"Blaze, 6",
                ID = $"Blaze, 6",
                MagicNumber = 1.2821,
                Type = 3,
                Accuracy = 70,
                MaxRange = System.Math.Round(142 * 1.1, 1),
                ShotView = 0.85
            };
            return rtn;
        }

        public static ClubData Blaze_7()
        {
            var rtn = new ClubData()
            {
                Name = $"Blaze, 7",
                ID = $"Blaze, 7",
                MagicNumber = 1.4286,
                Type = 3,
                Accuracy = 75,
                MaxRange = System.Math.Round(142 * 1.1, 1),
                ShotView = 0.92
            };
            return rtn;
        }

        public static ClubData Blaze_8()
        {
            var rtn = new ClubData()
            {
                Name = $"Blaze, 8",
                ID = $"Blaze, 8",
                MagicNumber = 1.4706,
                Type = 3,
                Accuracy = 75,
                MaxRange = System.Math.Round(142 * 1.1, 1),
                ShotView = 0.98
            };
            return rtn;
        }

        public static ClubData Torque_8()
        {
            var rtn = new ClubData()
            {
                Name = $"Torque, 8",
                ID = $"Torque, 8",
                MagicNumber = 2.3,
                Type = 4,
                Accuracy = 87,
                MaxRange = System.Math.Round(90 * 1.1, 1),
                ShotView = 0.94
            };
            return rtn;
        }

        public static ClubData Torque_9()
        {
            var rtn = new ClubData()
            {
                Name = $"Torque, 9",
                ID = $"Torque, 9",
                MagicNumber = 2.376,
                Type = 4,
                Accuracy = 87,
                MaxRange = System.Math.Round(93 * 1.1, 1),
                ShotView = 0.97
            };
            return rtn;
        }

        public static ClubData Forge_8()
        {
            var rtn = new ClubData()
            {
                Name = $"Forge, 8",
                ID = $"Forge, 8",
                MagicNumber = 3.8023,
                Type = 5,
                Accuracy = 100,
                MaxRange = System.Math.Round(140 * 1.1, 1),
                ShotView = 0.94
            };
            return rtn;
        }

        public static ClubData Forge_9()
        {
            var rtn = new ClubData()
            {
                Name = $"Forge, 9",
                ID = $"Forge, 9",
                MagicNumber = 3.857,
                Type = 5,
                Accuracy = 100,
                MaxRange = System.Math.Round(142 * 1.1, 1),
                ShotView = 0.97
            };
            return rtn;
        }

        public static ClubData Catalyst_7()
        {
            var rtn = new ClubData()
            {
                Name = $"Catalyst, 7",
                ID = $"Catalyst, 7",
                MagicNumber = System.Math.Round(2.6178 * 121d / 130d, 4),
                Type = 5,
                Accuracy = 92,
                MaxRange = System.Math.Round(121 * 1.1, 1),
                ShotView = 92
            };
            return rtn;
        }

        public static ClubData Catalyst_8()
        {
            var rtn = new ClubData()
            {
                Name = $"Catalyst, 8*",
                ID = $"Catalyst, 8",
                MagicNumber = 2.6178,
                Type = 5,
                Accuracy = 92,
                MaxRange = System.Math.Round(130 * 1.1, 1),
                ShotView = 97
            };
            return rtn;
        }
        
        public override string ToString()
        {
            return Name;
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
}