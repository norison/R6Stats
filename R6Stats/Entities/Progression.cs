namespace R6Stats.Entities
{
    public class Progression
    {
        public int Xp { get; internal set; }
        public string ProfileId { get; internal set; }
        public int LootboxProbability { get; internal set; }
        public int Level { get; internal set; }

        internal Progression() { }

        public override string ToString()
        {
            return $"{nameof(Xp)}: {Xp}, {nameof(ProfileId)}: {ProfileId}, {nameof(LootboxProbability)}: {LootboxProbability}, {nameof(Level)}: {Level}";
        }
    }
}
