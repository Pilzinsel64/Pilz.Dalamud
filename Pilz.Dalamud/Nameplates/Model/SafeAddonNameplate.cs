using FFXIVClientStructs.FFXIV.Client.UI;
using System.Runtime.InteropServices;

namespace Pilz.Dalamud.Nameplates.Model;

public class SafeAddonNameplate
{
    private readonly DalamudPluginInterface Interface;

    public IntPtr Pointer => PluginServices.GameGui.GetAddonByName("NamePlate", 1);

    public SafeAddonNameplate(DalamudPluginInterface pluginInterface)
    {
        Interface = pluginInterface;
    }

    public unsafe SafeNameplateObject GetNamePlateObject(int index)
    {
        SafeNameplateObject result = null;

        if (Pointer != IntPtr.Zero)
        {
            var npObjectArrayPtrPtr = Pointer + Marshal.OffsetOf(typeof(AddonNamePlate), nameof(AddonNamePlate.NamePlateObjectArray)).ToInt32();
            var npObjectArrayPtr = Marshal.ReadIntPtr(npObjectArrayPtrPtr);

            if (npObjectArrayPtr != IntPtr.Zero)
            {
                var npObjectPtr = npObjectArrayPtr + Marshal.SizeOf(typeof(AddonNamePlate.NamePlateObject)) * index;
                result = new(npObjectPtr, index);
            }
        }

        return result;
    }
}
