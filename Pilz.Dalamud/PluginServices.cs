using Dalamud.Data;
using Dalamud.Game.ClientState;
using Dalamud.Game.ClientState.Objects;
using Dalamud.Game.Gui;
using Dalamud.IoC;
using Dalamud.Plugin;
using Dalamud.Plugin.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pilz.Dalamud
{
    public class PluginServices
    {
        [PluginService] public static DalamudPluginInterface PluginInterface { get; set; } = null;
        [PluginService] public static IGameGui GameGui { get; set; } = null;
        [PluginService] public static IClientState ClientState { get; set; } = null;
        [PluginService] public static IDataManager DataManager { get; set; } = null;
        [PluginService] public static IObjectTable ObjectTable { get; set; } = null;
        [PluginService] public static IGameInteropProvider GameInteropProvider { get; set; } = null;

        public static void Initialize(DalamudPluginInterface dalamudPluginInterface)
        {
            dalamudPluginInterface.Create<PluginServices>();
        }
    }
}
