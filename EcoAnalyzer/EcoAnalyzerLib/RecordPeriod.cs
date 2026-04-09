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

        public string ObtainCSV(string separator = "\t")
        {
            string output = "Tempo\t";

            foreach (RecordedFeature rc in Enum.GetValues(typeof(RecordedFeature)))
            {
                output += rc.GetInfo().Name + separator;
            }

            output += "\n";

            Dictionary<RecordedFeature, List<DataPoint>> values = new();
            foreach (RecordedFeature rc in Enum.GetValues(typeof(RecordedFeature)))
            {
                values.Add(rc, GetAllValuesForFeature(rc));
            }

            for (int i = 0; i<values[0].Count; i++)
            {
                output += values[RecordedFeature.Temperature][i].Time + separator;

                foreach (RecordedFeature rc in Enum.GetValues(typeof(RecordedFeature)))
                {
                    output += values[rc][i].Value + separator;
                }

                output += "\n";
            }

            return output;
        }
    }
}
