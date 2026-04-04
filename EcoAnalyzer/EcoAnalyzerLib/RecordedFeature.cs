using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace EcoAnalyzerLib
{
    public enum RecordedFeature
    {
        //[Description("Temperature")]
        [FeatureInformation("Temperature", 220, 20, 60)]
        Temperature,

        [FeatureInformation("Humidity", 30, 144, 255)]
        RelativeHumidity,

        [FeatureInformation("Apparent Temperature", 255, 140, 0)]
        ApparentTemperature,

        [FeatureInformation("Precipitation %", 138, 43, 226)]
        PrecipitationProbability,

        [FeatureInformation("Wind Speed", 0, 200, 140)]
        WindSpeed,

        [FeatureInformation("Pressure", 128, 128, 128)]
        SurfacePressure,

        [FeatureInformation("Air Quality", 50, 205, 50)]
        AirQuality
    }
}
