using Dalamud.IoC;
using Dalamud.Plugin;
using Dalamud.Plugin.Services;

namespace Pilz.Dalamud;

public class PluginServices
{
    [PluginService] public static IDalamudPluginInterface PluginInterface { get; set; } = null;
    [PluginService] public static IGameGui GameGui { get; set; } = null;
    [PluginService] public static IClientState ClientState { get; set; } = null;
    [PluginService] public static IDataManager DataManager { get; set; } = null;
    [PluginService] public static IObjectTable ObjectTable { get; set; } = null;
    [PluginService] public static IGameInteropProvider GameInteropProvider { get; set; } = null;

    public static void Initialize(IDalamudPluginInterface dalamudPluginInterface)
    {
        dalamudPluginInterface.Create<PluginServices>();
    }
}
