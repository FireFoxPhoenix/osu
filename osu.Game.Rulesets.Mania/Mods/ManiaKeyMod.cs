// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using System;
using System.Linq;
using osu.Game.Beatmaps;
using osu.Game.Rulesets.Mania.Beatmaps;
using osu.Game.Rulesets.Mods;
using osu.Game.Screens.Play;

namespace osu.Game.Rulesets.Mania.Mods
{
    public abstract class ManiaKeyMod : Mod, IApplicableToBeatmapConverter, IApplicableToPlayer
    {
        public override string Acronym => Name;
        public abstract int KeyCount { get; }
        public override ModType Type => ModType.Conversion;
        public override bool Ranked => UsesDefaultConfiguration;
        public override ModVisibility Visibility => IsManiaMap ? ModVisibility.FullHide : ModVisibility.Show;

        private bool IsManiaMap;

        public void ApplyToBeatmapConverter(IBeatmapConverter beatmapConverter)
        {
            var mbc = (ManiaBeatmapConverter)beatmapConverter;

            // Although this can work, for now let's not allow keymods for mania-specific beatmaps
            if (mbc.IsForCurrentRuleset)
            {
                IsManiaMap = true;
                return;
            }

            IsManiaMap = false;

            mbc.TargetColumns = KeyCount;
        }

        public void ApplyToPlayer(Player player)
        {
            if (IsManiaMap)
            {
                var scoreInfo = player.Score.ScoreInfo;

                scoreInfo.Mods = scoreInfo.Mods.Where(m => m.GetType() != this.GetType()).ToArray();
            }
        }

        public override Type[] IncompatibleMods => new[]
        {
            typeof(ManiaModKey1),
            typeof(ManiaModKey2),
            typeof(ManiaModKey3),
            typeof(ManiaModKey4),
            typeof(ManiaModKey5),
            typeof(ManiaModKey6),
            typeof(ManiaModKey7),
            typeof(ManiaModKey8),
            typeof(ManiaModKey9),
            typeof(ManiaModKey10),
        }.Except(new[] { GetType() }).ToArray();
    }
}
