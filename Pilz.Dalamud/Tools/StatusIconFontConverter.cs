﻿using Dalamud.Game.Text.SeStringHandling;
using Pilz.Dalamud.Icons;

namespace Pilz.Dalamud.Tools;

public static class StatusIconFontConverter
{
    public static StatusIcons? GetStatusIconFromBitmapFontIcon(BitmapFontIcon fontIcon)
    {
        return fontIcon switch
        {
            BitmapFontIcon.NewAdventurer => StatusIcons.NewAdventurer,
            BitmapFontIcon.Mentor => StatusIcons.Mentor,
            BitmapFontIcon.MentorPvE => StatusIcons.MentorPvE,
            BitmapFontIcon.MentorCrafting => StatusIcons.MentorCrafting,
            BitmapFontIcon.MentorPvP => StatusIcons.MentorPvP,
            BitmapFontIcon.Returner => StatusIcons.Returner,
            _ => null
        };
    }

    public static BitmapFontIcon? GetBitmapFontIconFromStatusIcon(StatusIcons icon)
    {
        return icon switch
        {
            StatusIcons.NewAdventurer => BitmapFontIcon.NewAdventurer,
            StatusIcons.Mentor => BitmapFontIcon.Mentor,
            StatusIcons.MentorPvE => BitmapFontIcon.MentorPvE,
            StatusIcons.MentorCrafting => BitmapFontIcon.MentorCrafting,
            StatusIcons.MentorPvP => BitmapFontIcon.MentorPvP,
            StatusIcons.Returner => BitmapFontIcon.Returner,
            _ => null
        };
    }
}
