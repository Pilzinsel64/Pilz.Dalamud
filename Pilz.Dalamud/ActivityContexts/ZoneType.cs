﻿using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Pilz.Dalamud.ActivityContexts;

[Flags, JsonConverter(typeof(StringEnumConverter))]
public enum ZoneType
{
    Overworld = 1,
    Doungen = 2,
    Raid = 4,
    AllianceRaid = 8,
    Foray = 16,
    Pvp = 32,
    Everywhere = int.MaxValue
}
