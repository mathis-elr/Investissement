using System.Collections.Generic;
using System.Threading.Tasks;

namespace Investissement
{
    public class GestionnaireYahoo
    {
        public static async Task<Dictionary<string, double>> GetPrixActifs(List<string> symboles)
        {
            return await ApiYahoo.GetPrixActifsInvestit(symboles);
        }
    }
}
