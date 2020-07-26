using R6Stats.Enums;

namespace R6Stats.Entities
{
    public class Operator
    {
        public string Name { get; set; }
        public double Kd { get; set; }
        public double Wl { get; set; }
        public int Wins { get; internal set; }
        public int Losses { get; internal set; }
        public int Kills { get; internal set; }
        public int Deaths { get; internal set; }
        public int Headshots { get; internal set; }
        public int Melees { get; internal set; }
        public int Dbno { get; internal set; }
        public int Xp { get; internal set; }
        public int TimePlayed { get; internal set; }
        public string BadgeUrl { get; set; }
        public string MaskUrl { get; set; }
        public string SmallFigureUrl { get; set; }
        public string LargeFigureUrl { get; set; }
        public EOperatorCategory OperatorCategory { get; set; }
    }
}
