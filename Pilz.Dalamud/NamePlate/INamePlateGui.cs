using System.Collections.Generic;

namespace Pilz.Dalamud.NamePlate;

/// <summary>
/// Class used to modify the data used when rendering nameplates.
/// </summary>
public interface INamePlateGui
{
    /// <summary>
    /// The delegate used for receiving nameplate update events.
    /// </summary>
    /// <param name="context">An object containing information about the pending data update.</param>
    /// <param name="handlers>">A list of handlers used for updating nameplate data.</param>
    public delegate void OnPlateUpdateDelegate(INamePlateUpdateContext context, IReadOnlyList<INamePlateUpdateHandler> handlers);

    /// <summary>
    /// An event which fires when nameplate data is updated and at least one nameplate has important updates. The
    /// subscriber is provided with a list of handlers for nameplates with important updates.
    /// </summary>
    /// <remarks>
    /// Fires after <see cref="OnDataUpdate"/>.
    /// </remarks>
    event OnPlateUpdateDelegate? OnNamePlateUpdate;

    /// <summary>
    /// An event which fires when nameplate data is updated. The subscriber is provided with a list of handlers for all
    /// nameplates.
    /// </summary>
    /// <remarks>
    /// This event is likely to fire every frame even when no nameplates are actually updated, so in most cases
    /// <see cref="OnNamePlateUpdate"/> is preferred. Fires before <see cref="OnNamePlateUpdate"/>.
    /// </remarks>
    event OnPlateUpdateDelegate? OnDataUpdate;

    /// <summary>
    /// Requests that all nameplates should be redrawn on the following frame.
    /// </summary>
    void RequestRedraw();
}
