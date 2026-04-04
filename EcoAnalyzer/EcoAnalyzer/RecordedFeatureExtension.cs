using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoAnalyzer
{

    public static class RecordedFeatureExtension
    {
        public static FeatureInformation GetInfo(this Enum value)
        {
            var field = value.GetType().GetField(value.ToString())!;
            return (FeatureInformation)Attribute.GetCustomAttribute(field, typeof(FeatureInformation))!;
        }
    }
}
