using System;
using R6Stats.Enums;

namespace R6Stats.Entities
{
    public class Player
    {
        public string UserId { get; internal set; }
        public EPlatform Platform { get; internal set; }
        public string Username { get; internal set; }
        public Progression Progression { get; set; }

        internal Player() { }


        public override string ToString()
        {
            return $"{nameof(UserId)}: {UserId}, {nameof(Platform)}: {Platform}, {nameof(Username)}: {Username}";
        }

        protected bool Equals(Player other)
        {
            return UserId == other.UserId && Platform == other.Platform;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof(Player)) return false;
            return Equals((Player) obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(UserId, (int) Platform);
        }

        public static bool operator ==(Player left, Player right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Player left, Player right)
        {
            return !Equals(left, right);
        }
    }
}
