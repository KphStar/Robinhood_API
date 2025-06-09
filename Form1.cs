using Newtonsoft.Json.Linq;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Generators;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Crypto.Signers;
using Org.BouncyCastle.Security;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Robinhood_API
{
    public partial class Form1 : Form
    {

        // GLOBAL CONSTANTS FILE FOLDER PATH 

        private readonly string keyPath = @"C:\Users\USER PC\Documents\C#\Robinhood_API";
        private readonly string privateKeyFile = "my_private_key.txt";
        private readonly string robinhoodApiKey = "RobKeys.txt"; // <-- Your Robinhood API Key
        public Form1()
        {
            InitializeComponent();
        }

        private async void GetInfo()
        {
            await CallAndDisplayResult(async client => await client.GetAccountInfoAsync());
        }


        // -------- UTILITY TO CREATE CLIENT & DISPLAY --------

        private async Task CallAndDisplayResult(Func<RobinhoodApiClient, Task<string>> action)
        {
            try
            {
                string privateKeyBase64 = File.ReadAllText(Path.Combine(keyPath, privateKeyFile));
                string apiKeyString = File.ReadAllText(Path.Combine(keyPath, robinhoodApiKey)).Trim();
                var client = new RobinhoodApiClient(apiKeyString, privateKeyBase64);

                string result = await action(client);

                // Parse the JSON and set labels
                var j = JObject.Parse(result);
                lablAccountNumber.Text = $"Account Number: {j["account_number"]?.ToString() ?? "N/A"}";
                lablStaus.Text = $"Status: {j["status"]?.ToString() ?? "N/A"}";
                lablBuyingPower.Text = $"Buying Power: {j["buying_power"]?.ToString() ?? "N/A"} {j["buying_power_currency"]?.ToString() ?? ""}";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error");
            }
        }

        private void ChartSetup()
        {
            // Chart setup code can be added here if needed
            chartprice.Series.Clear();
            chartprice.Series.Add("BTC-USD");
            chartprice.Series["BTC-USD"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chartprice.Series["BTC-USD"].XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Time;
            chartprice.Series["BTC-USD"].BorderWidth = 4; 
            chartprice.ChartAreas[0].AxisX.LabelStyle.Format = "HH:mm:ss";
            chartprice.ChartAreas[0].AxisX.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Seconds;

            chartprice.Series.Add("Marker");
            chartprice.Series["Marker"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            chartprice.Series["Marker"].MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle;
            chartprice.Series["Marker"].MarkerSize = 10;
            chartprice.Series["Marker"].Color = Color.Yellow;
            chartprice.Series["Marker"].IsVisibleInLegend = false;

            // ---- Remove grid and set transparent background ----
            var area = chartprice.ChartAreas[0];
            area.AxisX.LabelStyle.Enabled = false; // <---- Hides bottom numbers
            area.AxisY.LabelStyle.Enabled = false; // <---- Hides left numbers
            area.AxisX.LineWidth = 0;
            area.AxisY.LineWidth = 0;
            area.AxisX.MajorTickMark.Enabled = false;
            area.AxisY.MajorTickMark.Enabled = false;
            area.AxisX.MajorGrid.Enabled = false;
            area.AxisY.MajorGrid.Enabled = false;
            area.AxisX.MinorGrid.Enabled = false;
            area.AxisY.MinorGrid.Enabled = false;
            chartprice.BackColor = Color.Transparent;
            area.BackColor = Color.Transparent;
            area.BackSecondaryColor = Color.Transparent;
            area.ShadowColor = Color.Transparent;

            // Hide chart legend/label
            chartprice.Legends[0].Enabled = false;


            // Timer setup
            priceTimer.Interval = 1000; // 1 second
            priceTimer.Tick += priceTimer_Tick;
            priceTimer.Start();
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            GetInfo();
            ChartSetup();
        }

        private void chartprice_MouseMove(object sender, MouseEventArgs e)
        {
            var area = chartprice.ChartAreas[0];
            var series = chartprice.Series["BTC-USD"];
            if (series.Points.Count == 0) return;

            // Convert mouse X to chart X (OADate/time)
            double mouseXVal = area.AxisX.PixelPositionToValue(e.X);

            // Find nearest point (by XValue, i.e., time)
            var nearest = series.Points
                .OrderBy(pt => Math.Abs(pt.XValue - mouseXVal))
                .First();

            DateTime time = DateTime.FromOADate(nearest.XValue);
            double price = nearest.YValues[0];

            // Update marker dot
            var markerSeries = chartprice.Series["Marker"];
            markerSeries.Points.Clear();
            markerSeries.Points.AddXY(nearest.XValue, price);

            // Update label (price changes as you move along the line!)
            lblPrice.Text = $"Time: {time:HH:mm:ss} | Price: {price:N2}";
        }

        private async void priceTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                string privateKeyBase64 = File.ReadAllText(Path.Combine(keyPath, privateKeyFile));
                string apiKeyString = File.ReadAllText(Path.Combine(keyPath, robinhoodApiKey)).Trim();

                var client = new RobinhoodApiClient(apiKeyString, privateKeyBase64);
                string result = await client.GetBestBidAskAsync("BTC-USD");

                var j = JObject.Parse(result);
                var arr = j["results"] as JArray;
                if (arr != null && arr.Count > 0)
                {
                    var priceStr = arr[0]["price"]?.ToString();
                    decimal price = decimal.TryParse(priceStr, out var p) ? p : 0m;
                    DateTime now = DateTime.Now;

                    chartprice.Series["BTC-USD"].Points.AddXY(now, price);

                    if (chartprice.Series["BTC-USD"].Points.Count > 100)
                        chartprice.Series["BTC-USD"].Points.RemoveAt(0);

                    var points = chartprice.Series["BTC-USD"].Points;
                    if (points.Count > 0)
                    {
                        chartprice.ChartAreas[0].AxisX.Minimum = points[0].XValue;
                        chartprice.ChartAreas[0].AxisX.Maximum = points[points.Count - 1].XValue;

                        // === Auto-zoom Y-axis ===
                        double minY = points.Select(pt => pt.YValues[0]).Min();
                        double maxY = points.Select(pt => pt.YValues[0]).Max();
                        double margin = (maxY - minY) * 0.05;
                        if (margin == 0) margin = maxY * 0.01;
                        chartprice.ChartAreas[0].AxisY.Minimum = minY - margin;
                        chartprice.ChartAreas[0].AxisY.Maximum = maxY + margin;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error fetching price: " + ex.Message, "Error");
            }
        }
    }
    
}

// ------------ Robinhood API CLIENT ------------

public class RobinhoodApiClient
{
    private readonly string _apiKey;
    private readonly Ed25519PrivateKeyParameters _privateKey;
    private readonly HttpClient _client = new HttpClient();
    private readonly string _baseUrl = "https://trading.robinhood.com";

    public RobinhoodApiClient(string apiKey, string privateKeyBase64)
    {
        _apiKey = apiKey;
        var privateKeyBytes = Convert.FromBase64String(privateKeyBase64);
        _privateKey = new Ed25519PrivateKeyParameters(privateKeyBytes, 0);
    }

    private string CreateSignature(string message)
    {
        var messageBytes = Encoding.UTF8.GetBytes(message);
        var signer = new Ed25519Signer();
        signer.Init(true, _privateKey);
        signer.BlockUpdate(messageBytes, 0, messageBytes.Length);
        var signature = signer.GenerateSignature();
        return Convert.ToBase64String(signature);
    }

    // ---- Generic GET ----
    private async Task<string> SendRobinhoodGetRequestAsync(string path)
    {
        string method = "GET";
        string body = "";
        long timestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds();

        string message = $"{_apiKey}{timestamp}{path}{method}{body}";
        string signature = CreateSignature(message);

        var request = new HttpRequestMessage(HttpMethod.Get, _baseUrl + path);
        request.Headers.Add("x-api-key", _apiKey);
        request.Headers.Add("x-timestamp", timestamp.ToString());
        request.Headers.Add("x-signature", signature);
        request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        var response = await _client.SendAsync(request);
        return await response.Content.ReadAsStringAsync();
    }

    // ---- Endpoints ----

    public async Task<string> GetAccountInfoAsync()
    {
        string path = "/api/v1/crypto/trading/accounts/";
        return await SendRobinhoodGetRequestAsync(path);
    }

    public async Task<string> GetBestBidAskAsync(params string[] symbols)
    {
        string path = "/api/v1/crypto/marketdata/best_bid_ask/";
        if (symbols != null && symbols.Length > 0)
        {
            var query = string.Join("&", symbols.Select(s => $"symbol={Uri.EscapeDataString(s.ToUpper())}"));
            path += "?" + query;
        }
        return await SendRobinhoodGetRequestAsync(path);
    }
}
    
