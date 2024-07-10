using Dalamud.Game.Text.SeStringHandling;

namespace Pilz.Dalamud.Tools.Strings;

public class StringChangesProps
{
    /// <summary>
    /// The string where the changes should be applied.
    /// </summary>
    public SeString Destination { get; set; }
    /// <summary>
    /// The changes that should be applied to the destination.
    /// </summary>
    public StringChanges StringChanges { get; set; } = new();
    /// <summary>
    /// Payloads to use as anchor where the changes should be applied to.
    /// </summary>
    public List<Payload> AnchorPayloads { get; set; } = [];
    /// <summary>
    /// A single payload to use as anchor where the changes should be applied to.
    /// This property will only be used if StringChange.ForceSingleAnchorPayload is true.
    /// </summary>
    public Payload AnchorPayload { get; set; }
}
