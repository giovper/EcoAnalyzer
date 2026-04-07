using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoAnalyzerLib
{
    public struct RecordDomain
    {
        public (float Lat, float Lng) Coordinates;
        public DateTime StartingTime;
        public DateTime EndingTime;

        public RecordDomain() { }
        public RecordDomain((float, float) coordinates, DateTime startingTime, DateTime endingTime)
        {
            Coordinates = coordinates;
            StartingTime = startingTime;
            EndingTime = endingTime;
        }
    }
}
