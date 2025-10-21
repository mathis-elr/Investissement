using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json; // Nécessite le package System.Net.Http.Json
using System.Text.Json.Serialization; // Nécessite System.Text.Json
using System.Threading.Tasks;

public class APIFinnhub
{
    // L'HttpClient est statique pour de meilleures performances
    private static readonly HttpClient _httpClient = new HttpClient();

    // -----------------------------------------------------------------
    //  METS TA CLÉ API FINNHUB (obtenue gratuitement sur finnhub.io)
    // -----------------------------------------------------------------
    private static string _cleAPI = "d338japr01qs3viofvvgd338japr01qs3viog000";
    // -----------------------------------------------------------------


    /// <summary>
    /// Récupère les prix pour une liste de symboles (ETF et Crypto).
    /// Respecte le rate limit de Finnhub (60/min) en faisant une pause.
    /// </summary>
    /// <param name="symboles">La liste des symboles à interroger.</param>
    /// <returns>Un dictionnaire [Symbole] -> [Prix]</returns>
    public static async Task<Dictionary<string, double>> getPrixActifsInvestit(List<string> symboles)
    {
        var dictionnairePrix = new Dictionary<string, double>();

        if (_cleAPI == "VOTRE_CLE_API_FINNHUB_ICI")
        {
            Console.WriteLine("ERREUR FATALE: Veuillez configurer votre clé API Finnhub dans FinnhubAPI.cs");
            return dictionnairePrix; // Retourne un dictionnaire vide
        }

        // On boucle sur chaque symbole demandé
        foreach (var symbole in symboles)
        {
            // Vérification pour éviter les symboles vides
            if (string.IsNullOrEmpty(symbole)) continue;

            try
            {
                // 1. Construire l'URL de l'API
                string url = $"https://finnhub.io/api/v1/quote?symbol={symbole}&token={_cleAPI}";

                // 2. Faire l'appel API (en utilisant le helper GetFromJsonAsync)
                FinnhubQuote quote = await _httpClient.GetFromJsonAsync<FinnhubQuote>(url);

                // 3. Traiter la réponse
                double prix = 0;
                if (quote != null)
                {
                    // L'API renvoie "c" (current price) et "pc" (previous close)
                    // Si le marché est fermé, "c" est 0. On prend "pc" comme solution de repli.
                    prix = (quote.CurrentPrice != 0) ? quote.CurrentPrice : quote.PreviousClose;
                }

                if (prix == 0)
                {
                    Console.WriteLine($"AVERTISSEMENT (FinnhubAPI): Prix non trouvé (0) pour {symbole}. Symbole incorrect ou non couvert ?");
                }

                dictionnairePrix[symbole] = prix;
            }
            catch (Exception ex)
            {
                // Si l'appel échoue (ex: 404, 429 Rate limit, etc.)
                Console.WriteLine($"ERREUR (FinnhubAPI) lors de l'appel pour {symbole}: {ex.Message}");
                dictionnairePrix[symbole] = 0; // En cas d'erreur, on met 0
            }

            // 4. LA PARTIE CRUCIALE : LA PAUSE
            // Le plan gratuit de Finnhub est de 60 appels/minute.
            // On attend 1.1 seconde (1100 ms) entre chaque appel pour être sûr.
            // C'est lent, mais ça NE PLANTERA PAS.
            await Task.Delay(1100);
        }

        return dictionnairePrix;
    }


    // Classe privée pour lire la réponse JSON de Finnhub
    private class FinnhubQuote
    {
        [JsonPropertyName("c")]
        public double CurrentPrice { get; set; }

        [JsonPropertyName("pc")]
        public double PreviousClose { get; set; }
    }
}