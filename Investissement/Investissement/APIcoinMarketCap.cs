using System.Collections.Specialized;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Text.Json;
using System.Linq;
using System.Net;
using System;


namespace Investissement
{
    public class Status
    {
        public string Timestamp { get; set; }
        public int Error_Code { get; set; }
        public string Error_Message { get; set; }
    }

    public class EURData
    {
        public double Price { get; set; }
    }

    public class CryptoQuote
    {
        public EURData EUR { get; set; }
    }

    public class CryptoData
    {
        public string Symbol { get; set; }
        public CryptoQuote Quote { get; set; }
    }

    public class CoinMarketCapResponse
    {
        public Dictionary<string, CryptoData> Data { get; set; }
        public Status Status { get; set; }
    }

    public class APIcoinMarketCap
    {
        /*ATTRIBUTS*/
        private const string cleeApi = "22feaa45846d41f4aaef2a390341ef79";

        public static List<(string symbol, double price)> GetCryptoPrices()
        {
            try
            {
                var URL = new UriBuilder("https://pro-api.coinmarketcap.com/v1/cryptocurrency/quotes/latest");
                var queryString = new NameValueCollection();
                queryString.Add("symbol", "BTC,ETH"); 
                queryString.Add("convert", "EUR");
                var query = string.Join("&", queryString.AllKeys.Select(key =>
                    $"{Uri.EscapeDataString(key)}={Uri.EscapeDataString(queryString[key])}"));
                URL.Query = query;

                var client = new WebClient();
                client.Headers.Add("X-CMC_PRO_API_KEY", cleeApi);
                client.Headers.Add("Accept", "application/json");
                string json = client.DownloadString(URL.ToString());

                // Désérialiser le JSON
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                var response = JsonSerializer.Deserialize<CoinMarketCapResponse>(json, options);

                // Extraire les prix
                return response.Data.Values
                    .Select(crypto => (crypto.Symbol, crypto.Quote.EUR.Price))
                    .ToList();
            }
            catch (WebException ex)
            {
                MessageBox.Show($"Erreur lors de l'appel à l'API : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new List<(string, double)>();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new List<(string, double)>();
            }
        }

        public long getPrixCrypto(string symbol)
        {
            List<(string symbol, double price)> prices = APIcoinMarketCap.GetCryptoPrices();
            long prix = -1;
            foreach (var item in prices)
            {
                if(item.symbol == symbol)
                {
                    prix = Convert.ToInt64(item.price);
                } 
            }
            return prix ;
        }
    }
}
