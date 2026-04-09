using System;
using System.Drawing;

[AttributeUsage(AttributeTargets.Field)]
public class FeatureInformation : Attribute
{
    public string Name { get; }
    public Color Color { get; }
    public bool suitableForLineGraph { get; }

    public FeatureInformation(string name, int r, int g, int b, bool suitableForLineGraph=false)
    {
        Name = name;
        Color = Color.FromArgb(r, g, b);
        this.suitableForLineGraph = suitableForLineGraph;
    }
}