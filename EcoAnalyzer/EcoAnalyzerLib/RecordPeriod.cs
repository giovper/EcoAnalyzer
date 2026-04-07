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
        public Dictionary<RecordedFeature, List<DataPoint>> Data { get; set; }
        
        public RecordPeriod() // For JSON deserialization
        {
            Data = new Dictionary<RecordedFeature, List<DataPoint>>();
        }
        public RecordPeriod(RecordDomain domain)
        {
            Domain = domain;
            Data = new Dictionary<RecordedFeature, List<DataPoint>>();
        }
        public RecordPeriod(RecordDomain domain, Dictionary<RecordedFeature, List<DataPoint>> data)
        {
            Domain = domain;
            Data = data;
        }

        public List<DataPoint> GetAllValuesForFeature(RecordedFeature rf)
        {
            return Data[rf];
        }
    }
}
