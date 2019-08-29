using Microsoft.Maps.MapControl.WPF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using RestSharp;
using Newtonsoft.Json;


namespace LuisaKatrinaReyes.Bingmaps.windows
{
    public class WeatherArea
    {
        public string Lat { get; set; }

        public string Lon { get; set; }

        public Weather[] Weather { get; set; }

        public Main Main { get; set; }

        public Wind Wind { get; set; }
    }

    public class Weather
    {
        public string description { get; set; }

        public string Icon { get; set; }
    }

    public class Main
    {
        public string Temp { get; set; }

        public string Humidity { get; set; }

        public string Pressure { get; set; }
    }

    public class Wind
    {
        public string speed { get; set; }
    }

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            KathMap.Focus();
            KathMap.Mode = new AerialMode(true);
        }

 
        private void KathMap_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var client = new RestClient("https://api.openweathermap.org/data/2.5/weather?q=Dinalupihan&AppID=1b140e3fe06f80d15e36286b073f86ab");

            var request = new RestRequest("", Method.GET);

            IRestResponse response = client.Execute(request);

            var content = response.Content;

            var area = JsonConvert.DeserializeObject<WeatherArea>(content);

            lblDateTime.Content = DateTime.Now.ToString("dd MMMM yyyy hh:mm tt");

            lblSummary.Content = " Description: " + area.Weather[0].description;

            lblTemperature.Content = " Temperature: " + area.Main.Temp;

            lblHumidity.Content = " Humidity: " + area.Main.Humidity;

            lblPressure.Content = " Pressure: " + area.Main.Pressure;

            lblWindspeed.Content = " Windspeed: " + area.Wind.speed;

        }
    }

}    
