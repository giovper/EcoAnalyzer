using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EcoAnalyzerLib
{
    public static class RecordedFeatureExtension
    {
        public static FeatureInformation GetInfo(this RecordedFeature value)
        {
            FieldInfo field = value.GetType().GetField(value.ToString())!;
            return (FeatureInformation)Attribute.GetCustomAttribute(field, typeof(FeatureInformation))!;
        }
    }
}
