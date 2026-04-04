using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace EcoAnalyzerLib
{
    public class RecordPeriod
    {
        // è la classe che tiene tutti i dati di un periodo
        // tipo possiede per tutti gli istanti del periodo o qualcosa del genere

        public List<Vector2> GetAllValuesForFeature(RecordedFeature rf)
        {
            // Vector2.x = valore da 0.0 a 1.0 di quanto è passato del periodo in quella singola misurazione
            // Vector2.y = valore della feature
            //throw new NotImplementedException();

            var l = new List<Vector2>();
            if (rf == RecordedFeature.Temperature)
            {
                l.Add(new Vector2(0.1f, 10));
                l.Add(new Vector2(0.4f, 50));
                l.Add(new Vector2(0.8f, 10));
            }
            else
            {
                l.Add(new Vector2(0.1f, 10));
                l.Add(new Vector2(0.5f, 50));
            }
            return l;
        }
    }
}
