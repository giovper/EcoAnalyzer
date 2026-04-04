using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoAnalyzerLib
{
    public struct RecordDomain
    {
        public float Latitude;
        public float Longitude;
        public DateTime StartingTime;
        public DateTime EndingTime;

        public RecordDomain() { }
        public RecordDomain(float latitude, float longitude, DateTime startingTime, DateTime endingTime)
        {
            Latitude = latitude;
            Longitude = longitude;
            StartingTime = startingTime;
            EndingTime = endingTime;
        }
    }
}
