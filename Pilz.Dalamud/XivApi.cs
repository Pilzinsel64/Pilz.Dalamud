using FFXIVClientStructs.FFXIV.Client.System.Framework;
using Pilz.Dalamud.Nameplates.Model;

namespace Pilz.Dalamud;

public class XivApi
{
    private static IntPtr _RaptureAtkModulePtr = IntPtr.Zero;

    public static IntPtr RaptureAtkModulePtr
    {
        get
        {
            if (_RaptureAtkModulePtr == IntPtr.Zero)
            {
                unsafe
                {
                    var framework = Framework.Instance();
                    var uiModule = framework->GetUiModule();

                    _RaptureAtkModulePtr = new IntPtr(uiModule->GetRaptureAtkModule());
                }
            }

            return _RaptureAtkModulePtr;
        }
    }

    public static SafeAddonNameplate GetSafeAddonNamePlate()
    {
        return new(PluginServices.PluginInterface);
    }
}
