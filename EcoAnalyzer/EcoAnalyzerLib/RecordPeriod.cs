using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.NetworkInformation;
using System.Numerics;

namespace EcoAnalyzerLib
{
    public class RecordPeriod
    {
        public RecordDomain Domain { get; set; }
        public Dictionary<RecordedFeature, List<Vector2>> Data { get; set; }
        
        public RecordPeriod() // For JSON deserialization
        {
            Data = new Dictionary<RecordedFeature, List<Vector2>>();
        }
        public RecordPeriod(RecordDomain domain)
        {
            Domain = domain;
            Data = new Dictionary<RecordedFeature, List<Vector2>>();
        }
        public RecordPeriod(RecordDomain domain, Dictionary<RecordedFeature, List<Vector2>> data)
        {
            Domain = domain;
            Data = data;
        }

        public List<Vector2> GetAllValuesForFeature(RecordedFeature rf)
        {
            // Vector2.x = valore da 0.0 a 1.0 di quanto è passato del periodo in quella singola misurazione
            // Vector2.y = valore della feature
            return Data[rf];
        }
    }
}
