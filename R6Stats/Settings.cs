namespace R6Stats
{
    public class Settings
    {
        /// <summary>
        /// Ubisoft Email
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Ubisoft Password
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Ubisoft appid, not required
        /// </summary>
        public string UbiAppId { get; set; }

        /// <summary>
        /// How long players are cached for (in seconds).
        /// </summary>
        public uint CacheTime { get; set; }

        /// <summary>
        /// How many times the auth client will automatically try to reconnect, high numbers can get you temporarily banned
        /// </summary>
        public uint MaxConnectRetries { get; set; }

        /// <summary>
        /// How frequently the http session should be refreshed, in seconds. Zero number for never. Defaults to 3 minutes.
        /// </summary>
        public uint RefreshSessionPeriod { get; set; } = 180;
    }
}
