using Dalamud.Game.Text.SeStringHandling;
using Pilz.Dalamud.Tools.Strings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pilz.Dalamud.Nameplates.Tools
{
    public static class NameplateUpdateFactory
    {
        public static void ApplyNameplateChanges(NameplateChangesProps props)
        {
            foreach (NameplateElements element in Enum.GetValues(typeof(NameplateElements)))
            {
                var change = props.Changes.GetProps(element);
                StringUpdateFactory.ApplyStringChanges(change);
            }
        }
    }
}
