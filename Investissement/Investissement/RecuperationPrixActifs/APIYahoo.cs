using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
//using System.Text.Json.Serialization;
using System.Threading.Tasks;
using YahooFinanceApi;
using System.Text.Json;

// Les prix sont dans des tableaux, même pour une seule valeur
//public class Quote
//{
//    [JsonPropertyName("open")]
//    public List<double> Open { get; set; }

//    [JsonPropertyName("high")]
//    public List<double> High { get; set; }

//    [JsonPropertyName("low")]
//    public List<double> Low { get; set; }

//    [JsonPropertyName("close")]
//    public List<double> Close { get; set; }
//}

//public class Indicators
//{
//    [JsonPropertyName("quote")]
//    public List<Quote> Quote { get; set; }
//}

//public class Result
//{
//    [JsonPropertyName("indicators")]
//    public Indicators Indicators { get; set; }
//}

//public class Chart
//{
//    [JsonPropertyName("result")]
//    public List<Result> Result { get; set; }
//}

//public class ChartResponse
//{
//    [JsonPropertyName("chart")]
//    public Chart Chart { get; set; }
//}

namespace Investissement
{
    public class ApiYahoo
    {
        //private static readonly HttpClient client = new HttpClient();
        /// <summary>
        /// Récupère les prix pour une liste de symboles (ETF et Crypto) via Yahoo Finance.
        /// C'est rapide et n'a pas de limite d'appels.
        /// </summary>
        /// <param name="symboles">La liste des symboles à interroger.</param>
        /// <returns>Un dictionnaire [Symbole] -> [Prix]</returns>
        public static async Task<Dictionary<string, double>> GetPrixActifsInvestit(List<string> symboles)
        {
            var dictionnairePrix = new Dictionary<string, double>();

            // S'il n'y a rien à demander, on retourne le dictionnaire vide
            if (symboles == null || !symboles.Any())
            {
                return dictionnairePrix;
            }

            try
            {
                // 1. C'est la magie de la bibliothèque :
                // Elle fait UN SEUL appel pour TOUS les symboles en même temps.
                // Pas de boucle, pas de "Rate Limit".
                IReadOnlyDictionary<string, Security> resultats =
                    await Yahoo.Symbols(symboles.ToArray()).QueryAsync();

                // 2. On traite les résultats
                foreach (var symbole in symboles)
                {
                    if (resultats.TryGetValue(symbole, out Security data))
                    {
                        // "RegularMarketPrice" est le prix actuel (ou le dernier prix de clôture)
                        dictionnairePrix[symbole] = Math.Round((double)data.RegularMarketPrice,2);
                    }
                    else
                    {
                        Console.WriteLine($"AVERTISSEMENT (YahooApi): Symbole non trouvé {symbole}");
                        dictionnairePrix[symbole] = 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ERREUR recuperation prix actifs API yahoo : {ex.Message}");
                throw new Exception($"ERREUR de connexion pour la recuperation prix");
            }

            return dictionnairePrix;
        }

        //public static async Task<Dictionary<string, double>> GetPrixHistorique(List<string> symboles, DateTime date)
        //{
        //    Dictionary<string, double> dictionnairePrixMoyenParActif = new Dictionary<string, double>();

        //    if (symboles == null || !symboles.Any())
        //    {
        //        return dictionnairePrixMoyenParActif;
        //    }

        //    // Conversion des dates en timestamps Unix (en secondes)
        //    DateTime epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        //    long period1 = (long)(date.Date.ToUniversalTime() - epoch).TotalSeconds;
        //    long period2 = (long)(date.Date.AddDays(1).ToUniversalTime() - epoch).TotalSeconds;

        //    foreach (string symbole in symboles.Distinct())
        //    {
        //        double prixMoyen = await GetPrixMoyenChartAsync(symbole, period1, period2);
        //        dictionnairePrixMoyenParActif[symbole] = prixMoyen;
        //    }

        //    return dictionnairePrixMoyenParActif;
        //}

        ///// <summary>
        ///// Fonction interne pour effectuer la requête Chart et calculer la moyenne.
        ///// </summary>
        //private static async Task<double> GetPrixMoyenChartAsync(string symbole, long period1, long period2)
        //{
        //    string url = $"https://query1.finance.yahoo.com/v8/finance/chart/{symbole}?interval=1d&period1={period1}&period2={period2}";

        //    try
        //    {
        //        var response = await client.GetAsync(url);
        //        response.EnsureSuccessStatusCode();

        //        string jsonResponse = await response.Content.ReadAsStringAsync();
        //        var chartData = JsonSerializer.Deserialize<ChartResponse>(jsonResponse);

        //        // Extraction des données :
        //        var result = chartData?.Chart?.Result?.FirstOrDefault();

        //        // On vérifie que les prix existent (quote.Open, High, Low, Close)
        //        if (result?.Indicators?.Quote?.FirstOrDefault() is var quote &&
        //            quote?.Open?.Any() == true)
        //        {
        //            // Les prix sont dans des tableaux, on prend le premier élément
        //            double highPrice = quote.High.FirstOrDefault();
        //            double lowPrice = quote.Low.FirstOrDefault();

        //            // Si les prix sont NaN (pas de trading), on retourne 0
        //            if (double.IsNaN(highPrice) || double.IsNaN(lowPrice))
        //            {
        //                return 0.0;
        //            }

        //            double moyenne = (highPrice + lowPrice) / 2.0;
        //            return Math.Round(moyenne, 2);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        // On affiche l'erreur, mais on retourne 0 pour ne pas planter le dictionnaire
        //        Console.WriteLine($"ERREUR (Chart API) pour {symbole}: {ex.Message}");
        //    }

        //    return 0.0; // Retourne 0 si aucune donnée valide n'est trouvée
        //}


    //    public static async Task<double> GetPrixHistorique(string symbole, DateTime date)
    //    {
    //        try
    //        {
    //            // 1. Définir la plage de recherche (la date.Date garantit minuit)
    //            DateTime dateDebut = date.Date;
    //            // La date de fin doit être le jour suivant pour inclure la journée entière
    //            DateTime dateFin = date.Date.AddDays(1);

    //            // 2. Appel de la fonction historique de la librairie
    //            IReadOnlyList<Candle> historique = await Yahoo.GetHistoricalAsync(
    //                symbole,
    //                dateDebut,
    //                dateFin,
    //                Period.Daily // On demande une granularité journalière
    //            );

    //            // 3. Traiter le résultat
    //            if (historique != null && historique.Any())
    //            {
    //                // La première (et seule) bougie (Candle) contient les données de la journée
    //                var bougie = historique.First();

    //                double prixHaut = (double)bougie.High;
    //                double prixBas = (double)bougie.Low;

    //                // Calcul de la moyenne (sur le Haut et le Bas, comme c'est souvent fait)
    //                double moyenne = (prixHaut + prixBas) / 2.0;

    //                // On retourne les valeurs arrondies au format (Ouverture, Clôture, Moyenne)
    //                return Math.Round(moyenne, 2);
    //            }
    //            else
    //            {
    //                Console.WriteLine($"AVERTISSEMENT (YahooApi): Aucune donnée historique trouvée pour {symbole} à la date {date.ToShortDateString()}");
    //                throw new Exception($"ERREUR de connexion pour la recuperation prix");
    //            }
    //        }
    //        catch (Exception ex)
    //        {
    //            Console.WriteLine($"ERREUR recuperation prix historique API yahoo pour {symbole} : {ex.Message}");
    //            // Vous pouvez choisir de relancer l'exception ou de retourner null
    //            throw new Exception($"ERREUR de connexion avec Yahoo pour la recuperation prix");
    //        }
    //    }
    }
}

