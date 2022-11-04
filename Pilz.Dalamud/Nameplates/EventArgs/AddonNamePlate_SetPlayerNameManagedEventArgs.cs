using Dalamud.Game.Text.SeStringHandling;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pilz.Dalamud.Nameplates.EventArgs
{
    public class AddonNamePlate_SetPlayerNameManagedEventArgs : HookWithResultManagedBaseEventArgs<IntPtr>
    {
        private new AddonNamePlate_SetPlayerNameEventArgs OriginalEventArgs
            => base.OriginalEventArgs as AddonNamePlate_SetPlayerNameEventArgs;

        public SeString Title { get; set; }
        public SeString Name { get; set; }
        public SeString FreeCompany { get; set; }

        public bool IsTitleAboveName
        {
            get => OriginalEventArgs.IsTitleAboveName;
            set => OriginalEventArgs.IsTitleAboveName = value;
        }

        public bool IsTitleVisible
        {
            get => OriginalEventArgs.IsTitleVisible;
            set => OriginalEventArgs.IsTitleVisible = value;
        }

        public int IconID
        {
            get => OriginalEventArgs.IconID;
            set => OriginalEventArgs.IconID = value;
        }
    }
}
