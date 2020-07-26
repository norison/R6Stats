using R6Stats.Constants;
using R6Stats.Enums;
using System;

namespace R6Stats.Extensions
{
    internal static class PlatformTypeExtensions
    {
        public static string ToStringValue(this EPlatform platform)
        {
            return platform switch
            {
                EPlatform.Uplay => ApiCommon.UplayString,
                EPlatform.Xbox => ApiCommon.XboxString,
                EPlatform.Playstation => ApiCommon.PlaystationString,
                _ => throw new ArgumentOutOfRangeException(nameof(platform), platform, null)
            };
        }

        public static string ToSpaceIdValue(this EPlatform platform)
        {
            return platform switch
            {
                EPlatform.Uplay => ApiCommon.UplaySpaceId,
                EPlatform.Xbox => ApiCommon.XboxSpaceId,
                EPlatform.Playstation => ApiCommon.PlaystationSpaceId,
                _ => throw new ArgumentOutOfRangeException(nameof(platform), platform, null)
            };
        }

        public static string ToUrlValue(this EPlatform platform)
        {
            return platform switch
            {
                EPlatform.Uplay => ApiCommon.UplayUrl,
                EPlatform.Xbox => ApiCommon.XboxUrl,
                EPlatform.Playstation => ApiCommon.PlaystationUrl,
                _ => throw new ArgumentOutOfRangeException(nameof(platform), platform, null)
            };
        }
    }
}
