namespace R6Stats.Constants
{
    internal static class ApiRoutes
    {
        internal const string RainbowSixBaseUrl = "https://game-rainbow6.ubi.com/";
        internal const string ApiBaseUrl = "https://public-ubiservices.ubi.com";
        internal const string Authorization = "v3/profiles/sessions";
        internal const string Profiles = "v3/profiles";
        internal const string Progression = "v1/spaces/{0}/sandboxes/{1}/r6playerprofile/playerprofile/progressions";
        internal const string Rank = "v1/spaces/{0}/sandboxes/{1}/r6karma/players";
        internal const string Operators = "v1/spaces/{0}/sandboxes/{1}/playerstats2/statistics";
        internal const string Weapons = "v1/spaces/{0}/sandboxes/{1}/playerstats2/statistics";
    }
}
