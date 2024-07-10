namespace Pilz.Dalamud.Nameplates.EventArgs;

public abstract class HookBaseEventArgs
{
    internal event Action CallOriginal;

    public void Original()
    {
        CallOriginal?.Invoke();
    }
}
