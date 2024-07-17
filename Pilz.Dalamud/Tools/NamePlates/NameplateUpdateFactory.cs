using Dalamud.Game.Text.SeStringHandling;
using Dalamud.Game.Text.SeStringHandling.Payloads;
using Pilz.Dalamud.ActivityContexts;
using Pilz.Dalamud.Icons;
using Pilz.Dalamud.NamePlate;

namespace Pilz.Dalamud.Tools.NamePlates;

public static class NameplateUpdateFactory
{
    public static void ApplyNameplateChanges(NameplateChangesProps props)
    {
        foreach (NameplateElements element in Enum.GetValues(typeof(NameplateElements)))
        {
            var change = props.Changes.GetChange(element);
            change.ApplyChanges();
        }
    }

    public static bool ApplyStatusIconWithPrio(INamePlateUpdateHandler handler, int newStatusIcon, ActivityContext activityContext, StatusIconPriorizer priorizer, bool moveIconToNameplateIfPossible)
    {
        bool? isPrio = null;
        var fontIcon = StatusIconFontConverter.GetBitmapFontIconFromStatusIcon((StatusIcons)handler.NameIconId);

        if (moveIconToNameplateIfPossible)
        {
            if (fontIcon != null)
            {
                // Set new font icon as string change
                var icon = new IconPayload(fontIcon.Value); ;
                if (handler.StatusPrefix is SeString str)
                    str.Payloads.Insert(0, icon);
                else
                    handler.StatusPrefix =  SeString.Empty.Append(icon);

                // If we moved it, we don't need it as icon anymore, yay :D
                isPrio = false;
            }
        }

        isPrio ??= priorizer.IsPriorityIcon(handler.NameIconId, activityContext);

        if (!isPrio.Value)
            handler.NameIconId = newStatusIcon;

        return isPrio.Value;
    }
}
