using System;
using System.Collections.Generic;
using System.Text;


public class GemFactory
{
    public IGem Create(string gemInfo)
    {
        var gemData = gemInfo.Split(' ');

        string clarity = gemData[0];
        string gemType = gemData[1];

        switch (gemType)
        {
            case "Ruby":
                Type typeRuby = typeof(Ruby);
                var ruby = (Ruby)Activator.CreateInstance(typeRuby, new object[] { clarity });
                return ruby;

            case "Amethyst":
                Type typeAmethyst = typeof(Amethyst);
                var amethyst = (Amethyst)Activator.CreateInstance(typeAmethyst, new object[] { clarity });
                return amethyst;

            case "Emerald":
                Type typeEmerald = typeof(Emerald);
                var emerald = (Emerald)Activator.CreateInstance(typeEmerald, new object[] { clarity });
                return emerald;

            default:
                break;
        }

        throw new ArgumentException("Incorrect gem data!");
    }
}

