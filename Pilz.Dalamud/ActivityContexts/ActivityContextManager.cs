﻿using Lumina.Excel;
using Lumina.Excel.GeneratedSheets;

namespace Pilz.Dalamud.ActivityContexts;

public class ActivityContextManager : IDisposable
{
    public delegate void ActivityContextChangedEventHandler(ActivityContextManager sender, ActivityContext activityContext);
    public event ActivityContextChangedEventHandler ActivityContextChanged;

    private readonly ExcelSheet<ContentFinderCondition> contentFinderConditionsSheet;

    public ActivityContext CurrentActivityContext { get; protected set; }

    public ActivityContextManager()
    {
        // Get condition sheet
        contentFinderConditionsSheet = PluginServices.DataManager.GameData.GetExcelSheet<ContentFinderCondition>();

        // Checks current territory type (if enabled/installed during a dutiy e.g.)
        CheckCurrentTerritory();

        // Enable event for automatic checks
        PluginServices.ClientState.TerritoryChanged += ClientState_TerritoryChanged;
    }

    public void Dispose()
    {
        PluginServices.ClientState.TerritoryChanged -= ClientState_TerritoryChanged;
    }

    private void ClientState_TerritoryChanged(ushort obj)
    {
        CheckCurrentTerritory();
    }

    private void CheckCurrentTerritory()
    {
        var content = contentFinderConditionsSheet.FirstOrDefault(c => c.TerritoryType.Row == PluginServices.ClientState.TerritoryType);
        ActivityType newActivityContext;
        ZoneType newZoneType;

        if (content == null)
        {
            // No content found, so we must be on the overworld
            newActivityContext = ActivityType.None;
            newZoneType = ZoneType.Overworld;
        }
        else
        {
            if (content.PvP)
            {
                newActivityContext = ActivityType.PvpDuty;
                newZoneType = ZoneType.Pvp;
            }
            else
            {
                newActivityContext = ActivityType.PveDuty;

                // Find correct member type
                var memberType = content.ContentMemberType.Row;
                if (content.RowId == 16 || content.RowId == 15)
                    memberType = 2; // Praetorium and Castrum Meridianum
                else if (content.RowId == 735 || content.RowId == 778)
                    memberType = 127; // Bozja

                // Check for ZoneType
                newZoneType = memberType switch
                {
                    2 => ZoneType.Doungen,
                    3 => ZoneType.Raid,
                    4 => ZoneType.AllianceRaid,
                    127 => ZoneType.Foray,
                    _ => ZoneType.Doungen,
                };
            }
        }

        CurrentActivityContext = new(newActivityContext, newZoneType);
        ActivityContextChanged?.Invoke(this, CurrentActivityContext);
    }
}
