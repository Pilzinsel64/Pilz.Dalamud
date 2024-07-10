using Dalamud.IoC;
using Dalamud.Plugin;
using Dalamud.Plugin.Services;

namespace Pilz.Dalamud;

public class PluginServices
{
    [PluginService] public static IDalamudPluginInterface PluginInterface { get; set; }
    [PluginService] public static IGameGui GameGui { get; set; }
    [PluginService] public static IClientState ClientState { get; set; }
    [PluginService] public static IDataManager DataManager { get; set; }
    [PluginService] public static IObjectTable ObjectTable { get; set; }
    [PluginService] public static IGameInteropProvider GameInteropProvider { get; set; }

    public static void Initialize(IDalamudPluginInterface dalamudPluginInterface)
    {
        dalamudPluginInterface.Create<PluginServices>();
    }
}
