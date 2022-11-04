using Dalamud.Hooking;
using Pilz.Dalamud.Nameplates.EventArgs;
using Dalamud.Utility.Signatures;

namespace Pilz.Dalamud.Nameplates
{
    public class NameplateManager : IDisposable
    {
        /// <summary>
        /// Provides events that you can hook to.
        /// </summary>
        public NameplateHooks Hooks { get; init; } = new();

        /// <summary>
        /// Defines if all hooks are enabled and the NameplateManager is ready to go. If this is false, then there might be something wrong or something already has been disposed.
        /// </summary>
        public bool IsValid => Hooks.IsValid;

        /// <summary>
        /// Creates a new instance of the NameplateManager.
        /// </summary>
        public NameplateManager()
        {
            Hooks.Initialize();
        }

        ~NameplateManager()
        {
            Dispose();
        }

        public void Dispose()
        {
            Hooks?.Dispose();
        }
    }
}
