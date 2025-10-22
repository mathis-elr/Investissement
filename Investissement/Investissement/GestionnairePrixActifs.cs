using System.Collections.Generic;
using System.Threading.Tasks;

namespace Investissement
{
    public class GestionnairePrixActifs
    {
        public static async Task<Dictionary<string, double>> GetPrixActifs(List<string> symboles)
        {
            return await ApiYahoo.GetPrixActifsInvestit(symboles);
        }
    }
}
