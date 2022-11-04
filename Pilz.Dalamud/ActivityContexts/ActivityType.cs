using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pilz.Dalamud.ActivityContexts
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum ActivityType
    {
        None,
        PveDuty,
        PvpDuty
    }
}
