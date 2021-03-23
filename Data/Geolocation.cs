using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.JSInterop;
using System.Text.Json;
using System.Net.Http;

namespace Wadatsumi.Data
{
    public class Geolocation
    {
        private IJSRuntime Runtime { get; init; }
        private IJSObjectReference JSGeolocationModule { get; set; }
        private HttpClient HttpClient { get; init; }
        public double Latitude { get; private set; }
        public double Longitude { get; private set; }
        public int PrefectureID { get; private set; }
        public string Prefecture { get; private set; }
        public int MunicipalityID { get; private set; }
        public string Municipality { get; private set; }
        public string Address { get; private set; }

        public Geolocation(IJSRuntime jsruntime, HttpClient httpClient)
        {
            Runtime = jsruntime;
            jsruntime.InvokeAsync<IJSObjectReference>("import", "./js/geolocation.js");
            HttpClient = httpClient;
        }

        private async Task Import()
        {
            if (JSGeolocationModule == null)
            {
                JSGeolocationModule = await Runtime.InvokeAsync<IJSObjectReference>("import", "./js/geolocation.js");
            }
        }

        public async Task GetCurrentPositionAsync()
        {
            await Import();
            var jselement = await JSGeolocationModule.InvokeAsync<JsonElement>("getCurrentPosition");
            Latitude = jselement.GetProperty("latitude").GetDouble();
            Longitude = jselement.GetProperty("longitude").GetDouble();
            await GetAddressAsync();
        }

        public async Task GetAddressAsync()
        {
            var requestUri = $"https://mreversegeocoder.gsi.go.jp/reverse-geocoder/LonLatToAddress?lat={Latitude}&lon={Longitude}";
            var response = await HttpClient.GetAsync(requestUri);
            var jsonDocument = await JsonDocument.ParseAsync(await response.Content.ReadAsStreamAsync());
            var results = jsonDocument.RootElement.GetProperty("results");
            var muniarray = (await JSGeolocationModule.InvokeAsync<string>("getMuni", results.GetProperty("muniCd").GetString())).Split(',');
            PrefectureID = int.Parse(muniarray[0]);
            Prefecture = muniarray[1];
            MunicipalityID = int.Parse(muniarray[2]);
            Municipality = muniarray[3];
            Address = results.GetProperty("lv01Nm").GetString();
        }
    }
}
