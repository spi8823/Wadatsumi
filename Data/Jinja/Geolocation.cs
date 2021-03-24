using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.JSInterop;
using System.Text.Json;
using System.Net.Http;

namespace Wadatsumi.Jinja.Data
{
    public class Geolocation
    {
        private IJSRuntime Runtime { get; init; }
        private IJSObjectReference JSGeolocationModule { get; set; }
        private JinjaDbContext JinjaDB { get; set; }
        private HttpClient HttpClient { get; init; }
        public double Latitude { get; private set; }
        public double Longitude { get; private set; }
        public int PrefectureID { get; private set; }
        public string Prefecture { get; private set; }
        public int MunicipalityID { get; private set; }
        public string Municipality { get; private set; }
        public string Address { get; private set; }

        public Geolocation(IJSRuntime jsruntime, HttpClient httpClient, JinjaDbContext jinjadb = null)
        {
            Runtime = jsruntime;
            jsruntime.InvokeAsync<IJSObjectReference>("import", "./js/geolocation.js");
            HttpClient = httpClient;
            JinjaDB = jinjadb;
        }

        public async Task LoadAsync()
        {
            await LoadCurrentPositionAsync();
            await LoadAddressAsync();
        }

        private async Task Import()
        {
            if (JSGeolocationModule == null)
            {
                JSGeolocationModule = await Runtime.InvokeAsync<IJSObjectReference>("import", "./js/geolocation.js");
            }
        }

        private async Task LoadCurrentPositionAsync()
        {
            await Import();
            var jselement = await JSGeolocationModule.InvokeAsync<JsonElement>("getCurrentPosition");
            Latitude = jselement.GetProperty("latitude").GetDouble();
            Longitude = jselement.GetProperty("longitude").GetDouble();
        }

        private async Task LoadAddressAsync()
        {
            var requestUri = $"https://mreversegeocoder.gsi.go.jp/reverse-geocoder/LonLatToAddress?lat={Latitude}&lon={Longitude}";
            var response = await HttpClient.GetAsync(requestUri);
            var jsonDocument = await JsonDocument.ParseAsync(await response.Content.ReadAsStreamAsync());
            var results = jsonDocument.RootElement.GetProperty("results");
            var municd = results.GetProperty("muniCd").GetString();
            if (JinjaDB == null)
            {
                var muniarray = (await JSGeolocationModule.InvokeAsync<string>("getMuni", municd)).Split(',');
                PrefectureID = int.Parse(muniarray[0]);
                Prefecture = muniarray[1];
                MunicipalityID = int.Parse(muniarray[2]);
                Municipality = muniarray[3];
            }
            else
            {
                var prefecture = JinjaDB.PrefectureDbSet.Find(int.Parse(municd) / 1000);
                var municipality = JinjaDB.MunicipalityDbSet.First(m => m.MuniCd == municd);
                PrefectureID = prefecture.ID;
                Prefecture = prefecture.Name;
                MunicipalityID = int.Parse(municipality.MuniCd);
                Municipality = municipality.Name;
            }
            Address = results.GetProperty("lv01Nm").GetString();
        }

        public static async Task<Geolocation> GetAsync(IJSRuntime jsruntime, HttpClient httpClient, JinjaDbContext jinjadb = null)
        {
            var geo = new Geolocation(jsruntime, httpClient, jinjadb);
            await geo.LoadAsync();
            return geo;
        }
    }
}
