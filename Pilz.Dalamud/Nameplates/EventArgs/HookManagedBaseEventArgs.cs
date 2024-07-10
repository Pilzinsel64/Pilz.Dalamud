namespace Pilz.Dalamud.Nameplates.EventArgs;

public abstract class HookManagedBaseEventArgs
{
    public HookBaseEventArgs OriginalEventArgs { get; internal set; }
}
