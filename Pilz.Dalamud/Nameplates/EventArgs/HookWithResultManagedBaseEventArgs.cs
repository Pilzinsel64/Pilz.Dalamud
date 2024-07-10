namespace Pilz.Dalamud.Nameplates.EventArgs;

public abstract class HookWithResultManagedBaseEventArgs<TResult>
{
    public HookWithResultBaseEventArgs<TResult> OriginalEventArgs { get; internal set; }
}
