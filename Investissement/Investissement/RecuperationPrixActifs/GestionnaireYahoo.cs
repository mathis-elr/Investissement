using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace Investissement
{
    public class GestionnaireYahoo
    {
        public static async Task<Dictionary<string, double>> GetPrixActifs(List<string> symboles)
        {
            return await ApiYahoo.GetPrixActifsInvestit(symboles);
        }

        //public static async Task<Dictionary<string, double>> GetPrixHistorique(List<string> symboles, DateTime date)
        //{
        //    return await ApiYahoo.GetPrixHistorique(symboles, date);
        //}

        //public static async Task<Dictionary<string,double>> GetMoyennePrixParDate(List<string> symboles, DateTime date)
        //{
        //    Dictionary<string, double> dictionnairePrixMoyenParActif = new Dictionary<string, double>();
        //    foreach (string symbole in symboles)
        //    {
        //        double prixMoyen = await ApiYahoo.GetPrixHistorique(symbole, date);
        //        dictionnairePrixMoyenParActif[symbole] = prixMoyen;
        //    }
        //    return dictionnairePrixMoyenParActif;        
        //}
    }
}
