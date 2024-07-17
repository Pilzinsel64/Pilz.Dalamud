using Pilz.Dalamud.NamePlate;

namespace Pilz.Dalamud.Tools.NamePlates;

public class NameplateChanges
{
    private readonly List<NameplateElementChange> changes = [];

    public NameplateChanges(INamePlateUpdateHandler handler)
    {
        changes.Add(new(NameplateElements.Title, handler));
        changes.Add(new(NameplateElements.Name, handler));
        changes.Add(new(NameplateElements.FreeCompany, handler));
    }

    /// <summary>
    /// Gets the properties with the changes of an element of your choice where you can add your payloads to a change and setup some options.
    /// </summary>
    /// <param name="element">The position of your choice.</param>
    /// <returns></returns>
    public NameplateElementChange GetChange(NameplateElements element)
    {
        return changes.FirstOrDefault(n => n.Element == element);
    }
}
