﻿using Dalamud.Data;
using Dalamud.Game.ClientState;
using Dalamud.Game.ClientState.Objects;
using Dalamud.Game.Gui;
using Dalamud.IoC;
using Dalamud.Plugin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pilz.Dalamud
{
    public class PluginServices
    {
        [PluginService] public static GameGui GameGui { get; private set; } = null!;
        [PluginService] public static DalamudPluginInterface PluginInterface { get; private set; } = null!;
        [PluginService] public static ClientState ClientState { get; private set; } = null!;
        [PluginService] public static DataManager DataManager { get; private set; } = null!;
        [PluginService] public static ObjectTable ObjectTable { get; private set; } = null!;

        public static void Initialize(DalamudPluginInterface dalamudPluginInterface)
        {
            dalamudPluginInterface.Create<PluginServices>();
        }
    }
}
