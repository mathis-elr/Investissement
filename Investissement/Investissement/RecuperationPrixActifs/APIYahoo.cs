using System.Collections.Generic;
using System.Threading.Tasks;
using YahooFinanceApi;
using System.Linq;
using System;
using System.CodeDom;


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
    }
}
