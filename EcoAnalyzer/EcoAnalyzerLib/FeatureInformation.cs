using System;
using System.Drawing;

[AttributeUsage(AttributeTargets.Field)]
public class FeatureInformation : Attribute
{
    public string Name { get; }
    public Color Color { get; }

    public FeatureInformation(string name, int r, int g, int b)
    {
        Name = name;
        Color = Color.FromArgb(r, g, b);
    }
}