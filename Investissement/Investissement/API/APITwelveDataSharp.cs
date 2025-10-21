using TwelveDataSharp.Interfaces;
using System.Threading.Tasks;
using System.Net.Http;
using TwelveDataSharp;
using System;


namespace Investissement
{
    public class APITwelveDataSharp
    {
        // Déclaration et initialisation de _httpClient
        private static readonly HttpClient _httpClient = new HttpClient();
        private static readonly ITwelveDataClient _twelveDataClient;
        private static string cleAPI = "ef864ec78b2447028a44f46253360006"; // Remplace par ta clé API réelle

        // Constructeur statique (une seule fois !)
        static APITwelveDataSharp()
        {
            _twelveDataClient = new TwelveDataClient(cleAPI, _httpClient);
        }

        public static async Task<double> GetPrixActif(string symbol)
        {
            try
            {
                var quote = await _twelveDataClient.GetRealTimePriceAsync(symbol);
                return quote.Price;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erreur lors de la récupération du prix pour {symbol} : {ex.Message}");
                throw;
            }
        }

        public static void Dispose()
        {
            _httpClient?.Dispose();
        }
    }
}
