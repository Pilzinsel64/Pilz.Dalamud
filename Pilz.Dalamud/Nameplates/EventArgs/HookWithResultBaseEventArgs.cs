using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pilz.Dalamud.Nameplates.EventArgs
{
    public abstract class HookWithResultBaseEventArgs<TResult> : HookBaseEventArgs
    {
        public TResult Result { get; set; }
    }
}
