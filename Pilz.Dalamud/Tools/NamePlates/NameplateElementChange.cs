﻿using Dalamud.Game.Text.SeStringHandling;
using Pilz.Dalamud.NamePlate;
using Pilz.Dalamud.Tools.Strings;

namespace Pilz.Dalamud.Tools.NamePlates;

public class NameplateElementChange(NameplateElements element, INamePlateUpdateHandler handler)
{
    public NameplateElements Element => element;
    public StringChanges Changes { get; set; } = new();

    public void ApplyFormatting(SeString prefix, SeString postfix)
    {
        var parts = (prefix, postfix);

        switch (element)
        {
            case NameplateElements.Name:
                handler.NameParts.TextWrap = parts;
                break;
            case NameplateElements.Title:
                handler.TitleParts.OuterWrap = parts;
                break;
            case NameplateElements.FreeCompany:
                handler.FreeCompanyTagParts.OuterWrap = parts;
                break;
        }
    }

    public void ApplyChanges()
    {
        if (Changes.Any())
        {
            StringUpdateFactory.ApplyStringChanges(new()
            {
                StringChanges = Changes,
                Destination = element switch
                {
                    NameplateElements.Name => handler.NameParts.Text ??= handler.InfoView.Name,
                    NameplateElements.Title => handler.TitleParts.Text ??= handler.InfoView.Title,
                    NameplateElements.FreeCompany => handler.FreeCompanyTagParts.Text ??= handler.InfoView.FreeCompanyTag,
                    _ => null,
                },
            });
        }
    }
}
