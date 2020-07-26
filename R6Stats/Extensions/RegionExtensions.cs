using R6Stats.Constants;
using R6Stats.Enums;
using System;

namespace R6Stats.Extensions
{
    internal static class RegionExtensions
    {
        public static string ToStringValue(this ERegion region)
        {
            return region switch
            {
                ERegion.Eu => ApiRanks.Emea,
                ERegion.Na => ApiRanks.Ncsa,
                ERegion.Asia => ApiRanks.Apac,
                _ => throw new ArgumentOutOfRangeException(nameof(region), region, null)
            };
        }
    }
}
