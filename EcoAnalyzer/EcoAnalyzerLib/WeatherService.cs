namespace EcoAnalyzerLib
{
    public class WeatherService
    {
        public WeatherService() { }

        public RecordPeriod GetRecordsFromDomain(RecordDomain rd)
        {
            //suppongo che guarda prima se ha il json salvato tipo cache da prima, e altrimenti chiama api
            //throw new NotImplementedException();

            return new RecordPeriod();
        }
    }
}
