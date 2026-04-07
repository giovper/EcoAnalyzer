using System.Globalization;
using System.IO;
using System.Numerics;
using System.Text.Json;

namespace EcoAnalyzerLib
{
    public class WeatherService
    {
        private string dataFolder;
        private readonly string cacheFilename = "wheatherDataCache.json";
        public WeatherService(string dataFolder = "EcoAnalyzerData\\") 
        {
            this.dataFolder = dataFolder;
        }

        public async Task<RecordPeriod> GetRecordsFromDomain(RecordDomain rd)
        {
            RecordPeriod rp = new RecordPeriod(rd);
            if (File.Exists(dataFolder + cacheFilename))
            {
                List<RecordPeriod>? cachedData = GetRecordsFromFile(dataFolder + cacheFilename);
                if (cachedData != null)
                {
                    RecordPeriod? found = cachedData.Find((RecordPeriod r) => r.Domain.Equals(rd));
                    if (found != null)
                        rp = found;
                    else
                    {
                        (RecordPeriod data, bool gotError) retrievedData = await RetrieveRecordPeriodFromAPI(rd);
                        if (!retrievedData.gotError)
                        {
                            cachedData.Add(retrievedData.data);
                            string jsonData = JsonSerializer.Serialize(cachedData);
                            File.WriteAllText(dataFolder + cacheFilename, jsonData);
                            rp = retrievedData.data;
                        }
                        else
                        {
                            throw new Exception("Failed to retrieve data from API.");
                        }
                    }
                }
            }
            else
            {
                (RecordPeriod data, bool gotError) retrievedData = await RetrieveRecordPeriodFromAPI(rd);
                if (!retrievedData.gotError)
                {
                    List<RecordPeriod> newCache = new List<RecordPeriod>() { retrievedData.data };
                    string jsonData = JsonSerializer.Serialize(newCache);
                    if (!Path.Exists(dataFolder))
                    {
                        Directory.CreateDirectory(dataFolder);
                    }
                    File.WriteAllText(dataFolder + cacheFilename, jsonData);
                    rp = retrievedData.data;
                }
                else
                {
                    throw new Exception("Failed to retrieve data from API.");
                }
            }
            return rp;
        }

        private List<RecordPeriod>? GetRecordsFromFile(string filename)
        {
            string rawData = File.ReadAllText(dataFolder + cacheFilename);
            List<RecordPeriod>? cachedData = JsonSerializer.Deserialize<List<RecordPeriod>>(rawData);
            return cachedData;
        }

        private async Task<(RecordPeriod data,bool gotError)> RetrieveRecordPeriodFromAPI(RecordDomain rd)
        {
            try
            {
                using HttpClient client = new HttpClient();

                string frmttLat = rd.Coordinates.Lat.ToString(CultureInfo.InvariantCulture);
                string frmttLng = rd.Coordinates.Lng.ToString(CultureInfo.InvariantCulture);

                string weatherUrl =
                    $"https://archive-api.open-meteo.com/v1/archive?" +
                    $"latitude={frmttLat}&longitude={frmttLng}" +
                    $"&hourly=temperature_2m,relativehumidity_2m,apparent_temperature,precipitation,windspeed_10m,surface_pressure" +
                    $"&start_date={rd.StartingTime:yyyy-MM-dd}" +
                    $"&end_date={rd.EndingTime:yyyy-MM-dd}";

                string airUrl =
                    $"https://air-quality-api.open-meteo.com/v1/air-quality?" +
                    $"latitude={frmttLat}&longitude={frmttLng}" +
                    $"&hourly=european_aqi" +
                    $"&start_date={rd.StartingTime:yyyy-MM-dd}" +
                    $"&end_date={rd.EndingTime:yyyy-MM-dd}";

                string weatherResponse = await client.GetStringAsync(weatherUrl);
                string airResponse = await client.GetStringAsync(airUrl);

                using JsonDocument weatherJson = JsonDocument.Parse(weatherResponse);
                using JsonDocument airJson = JsonDocument.Parse(airResponse);

                RecordPeriod rp = new RecordPeriod(rd);

                var weatherHourly = weatherJson.RootElement.GetProperty("hourly");
                var airHourly = airJson.RootElement.GetProperty("hourly");

                var timeArray = weatherHourly.GetProperty("time");

                int count = timeArray.GetArrayLength();

                for (int i = 0; i < count; i++)
                {
                    float t = (float)i / (count - 1); // normalized time

                    void Add(RecordedFeature rf, float value)
                    {
                        if (!rp.Data.ContainsKey(rf))
                            rp.Data[rf] = new List<Vector2>();

                        rp.Data[rf].Add(new Vector2(t, value));
                    }

                    Add(RecordedFeature.Temperature,
                        weatherHourly.GetProperty("temperature_2m")[i].GetSingle());

                    Add(RecordedFeature.RelativeHumidity,
                        weatherHourly.GetProperty("relativehumidity_2m")[i].GetSingle());

                    Add(RecordedFeature.ApparentTemperature,
                        weatherHourly.GetProperty("apparent_temperature")[i].GetSingle());

                    Add(RecordedFeature.PrecipitationProbability,
                        weatherHourly.GetProperty("precipitation")[i].GetSingle());

                    Add(RecordedFeature.WindSpeed,
                        weatherHourly.GetProperty("windspeed_10m")[i].GetSingle());

                    Add(RecordedFeature.SurfacePressure,
                        weatherHourly.GetProperty("surface_pressure")[i].GetSingle());

                    Add(RecordedFeature.AirQuality,
                        airHourly.GetProperty("european_aqi")[i].GetSingle());
                }

                return (rp, false);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return (null, true);
            }
        }
    }
}
