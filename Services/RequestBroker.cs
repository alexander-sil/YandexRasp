using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace YandexRasp {
    public class RequestBroker {
        public enum SelectionType { Airport, DateTime, BothWays }
        public static object GetRaspModels(SelectionType selectionType, DateTime date, string from, string to, string apikey = "", string format = "json", string system = "iata") {
            
            HttpClient client = new HttpClient();
            HttpRequestMessage request = new HttpRequestMessage();

            request.Method = HttpMethod.Get;
            request.RequestUri = 
            selectionType == SelectionType.Airport ? new Uri($"https://api.rasp.yandex.net/v3.0/search/?from={from}&to={to}&system={system}&apikey={apikey}&format={format}")
            : selectionType == SelectionType.DateTime ? new Uri($"https://api.rasp.yandex.net/v3.0/search/?date={string.Format("{0}-{1}-{2}", date.Year, date.Month, date.Day)}&system={system}&apikey={apikey}&format={format}")
            : new Uri($"https://api.rasp.yandex.net/v3.0/search/?date={string.Format("{0}-{1}-{2}", date.Year, date.Month, date.Day)}&from={from}&to={to}&system={system}&apikey={apikey}&format={format}");

            HttpResponseMessage response = client.SendAsync(request).Result;
            string json = response.Content.ReadAsStringAsync().Result;

            if ((response.StatusCode == HttpStatusCode.BadRequest) || (response.StatusCode == HttpStatusCode.NotFound)) {
                JToken subroot = JToken.Parse(json);
                string error = ((string)(subroot["error"]["text"]));
                return error;
            }

            List<RaspModel> modelsToReturn = new List<RaspModel>();

            JToken root = JToken.Parse(json);
            JArray segments = (JArray)root["segments"];

            foreach (JToken segment in segments) {
                modelsToReturn.Add(new RaspModel() {
                    From = ((string)(segment["thread"]["title"])).Split(" — ")[0],
                    To = ((string)(segment["thread"]["title"])).Split(" — ")[1],
                    Date = ((string)(segment["start_date"])),
                    FlightNo = ((string)(segment["thread"]["number"]))
                });
            }

            return modelsToReturn;
        }
    }
}
