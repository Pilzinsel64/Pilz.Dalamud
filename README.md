# Pilz.Dalamud

This library is a set of usefull functions you can use within your Dalamud plugin.\
At the moment it's far away from being complete or even good. Right now it as some basic functions and tools to work with Nameplates and TextPayloads.

## How to install

Install the latest version of `Pilz.Dalamud` via NuGet Package Manager or NuGet Console:\
https://www.nuget.org/packages/Pilz.Dalamud

## Get started

### Initialize Plugin Services

To be able to use most features of that lib you must initialize the Plugin Services. The best time to do this is when you initialize your own Plugin Services at your IDalamudPlugin class constructor.

```cs
public Plugin(DalamudPluginInterface pluginInterface)
{
    // Initialize our own Plugin Services if we use them
    PluginServices.Initialize(pluginInterface);
    
    // Initialize Plugin Services for `Pilz.Dalamud` because the lib uses them
    Pilz.Dalamud.PluginServices.Initialize(pluginInterface);
}
```

### Hook into Nameplates

To edit the nameplate, you first need to hook and listen to the Game's updates. Also don't forget to unhook and dispose on unloading the plugins!

```cs
public class NameplateFeature : IDisposable
{
    public NameplateManager NameplateManager { get; init; }
    
    /// <summary>
    /// Occurs when a player nameplate is updated by the game.
    /// </summary>
    public event PlayerNameplateUpdatedDelegate? PlayerNameplateUpdated;
    
    public NameplateFeature()
    {
        NameplateManager = new();
        NameplateManager.Hooks.AddonNamePlate_SetPlayerNameManaged += Hooks_AddonNamePlate_SetPlayerNameManaged;
    }
    
    public void Dispose()
    {
        NameplateManager.Hooks.AddonNamePlate_SetPlayerNameManaged -= Hooks_AddonNamePlate_SetPlayerNameManaged;
        NameplateManager.Dispose();
    }
    
    private void Hooks_AddonNamePlate_SetPlayerNameManaged(Pilz.Dalamud.Nameplates.EventArgs.AddonNamePlate_SetPlayerNameManagedEventArgs eventArgs)
    {
    }
}
```

This is an example of editing the title to "Good Player", make the name italic and also force the title to always be above the name:

```cs
private void Hooks_AddonNamePlate_SetPlayerNameManaged(Pilz.Dalamud.Nameplates.EventArgs.AddonNamePlate_SetPlayerNameManagedEventArgs eventArgs)
{
    try
    {
        // Get the referenced player object for the nameplate object
        PlayerCharacter? playerCharacter = NameplateManager.GetNameplateGameObject<PlayerCharacter>(eventArgs.SafeNameplateObject);
        
        if (playerCharacter != null && playerCharacter.StatusFlags.HasFlag(StatusFlags.Friend))
        {
            const string TEXT_GOOD_PLAYER = "Good Player";
            
            // Create a new change
            var nameplateChanges = new NameplateChanges(eventArgs);
            
            // Replace the title
            var titleChange = nameplateChanges.GetChange(NameplateElements.Title, StringPosition.Replace);
            titleChange.Payloads.Add(new TextPayload(TEXT_GOOD_PLAYER));
            
            // Make the name italic
            var nameChangeBefore = nameplateChanges.GetChange(NameplateElements.Name, StringPosition.Before);
            nameChangeBefore.Payloads.Add(new EmphasisItalicPayload(true));
            
            var nameChangeAfter = nameplateChanges.GetChange(NameplateElements.Name, StringPosition.After);
            nameChangeAfter.Payloads.Add(new EmphasisItalicPayload(false));
            
            // Forge the title to be always above the name (this we can edit directly)
            eventArgs.IsTitleAboveName = true;
            
            // Apply the string changes!
            NameplateUpdateFactory.ApplyNameplateChanges(new NameplateChangesProps(nameplateChanges));
        }
    }
    catch (Exception ex)
    {
        PluginLog.Error(ex, $"SetPlayerNameplateDetour");
    }
}
```

## Contribute

- Freel free to PR changes or new features/libraries.
- If you want to address bigger changes or want a discussion about something, feel free to open an issue.
