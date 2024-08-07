﻿using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Pilz.Dalamud.ActivityContexts;

[JsonConverter(typeof(StringEnumConverter))]
public enum ActivityType
{
    None = 0x0,
    PveDuty = 0x1,
    PvpDuty = 0x2
}
