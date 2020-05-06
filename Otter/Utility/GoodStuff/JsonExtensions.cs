using Otter.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace Otter.Utility.GoodStuff
{
    public static class JsonExtensions
    {
        public static Color GetColor(this JsonElement jsonElement, string key)
        {
            var colorString = jsonElement.GetProperty(key).GetString();

            if (colorString.StartsWith("#"))
            {
                colorString = colorString.Substring(1);
            }

            return new Color(colorString);
        }
    }
}
