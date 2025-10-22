using System.Collections.Generic;
using System.Threading.Tasks;
using YahooFinanceApi;
using System.Linq;
using System;


namespace Investissement
{
    public class ApiYahoo
    {
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
                        dictionnairePrix[symbole] = (double)data.RegularMarketPrice;
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
                // L'échec peut arriver si Yahoo change son site ou si tu es bloqué (très rare)
                Console.WriteLine($"ERREUR (YahooApi) lors de l'appel groupé: {ex.Message}");
            }

            return dictionnairePrix;
        }
    }
}
