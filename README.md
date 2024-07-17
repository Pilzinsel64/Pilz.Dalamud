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

Nameplates has been reworked by @nebel and will be part of core Dalamud soon.

Read more at: https://github.com/goatcorp/Dalamud/pull/1915

Use the new service already now via Pilz.Dalamud:

```cs
var namePlateGui = Pilz.Dalamud.NamePlate.INamePlateGui.Instance;
```


## Contribute

- Freel free to PR changes or new features/libraries.
- If you want to address bigger changes or want a discussion about something, feel free to open an issue.
