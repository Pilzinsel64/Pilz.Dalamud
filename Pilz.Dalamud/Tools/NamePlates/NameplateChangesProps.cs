namespace Pilz.Dalamud.Tools.NamePlates;

public class NameplateChangesProps
{
    /// <summary>
    /// All the changes to the nameplate that should be made.
    /// </summary>
    public NameplateChanges Changes { get; set; }

    public NameplateChangesProps()
    {
    }

    public NameplateChangesProps(NameplateChanges changes) : this()
    {
        Changes = changes;
    }
}
