// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using System;

namespace osu.Game.Rulesets.Mods
{
    [Flags]
    public enum ModVisibility
    {
        /// <summary>
        /// Show mod everywhere.
        /// </summary>
        Show = 0,

        /// <summary>
        /// Hide mod in the loader screen (PlayerLoader).
        /// </summary>
        HideInLoader = 1 << 0,

        /// <summary>
        /// Hide mod in the HUD during gameplay.
        /// </summary>
        HideInHUD = 1 << 1,

        /// <summary>
        /// Hide mod in the results screen.
        /// </summary>
        HideInResults = 1 << 2,

        /// <summary>
        /// Hide mod from all gameplay UI.
        /// </summary>
        FullHide = HideInLoader | HideInHUD | HideInResults
    }
}
