using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace Investissement
{
    public class ValeurPatrimoineController
    {
        /*ATTRIBUTS*/
        private readonly ValeurPatrimoineBDD valeurPatrimoinebdd;
        private readonly TransactionBDD transactionbdd;
        public Dictionary<string, double> dictionnairePrixActif { get; set; }

        /*CONSTRUCTEUR*/
        public ValeurPatrimoineController(BDD bdd)
        {
            this.valeurPatrimoinebdd = new ValeurPatrimoineBDD(bdd);
            this.transactionbdd = new TransactionBDD(bdd);
        }

        /*encapsulation*/
        public Dictionary<DateTime, double> getMoyenneValeurPatrimoineParJour()
        {
            return valeurPatrimoinebdd.getMoyenneValeurPatrimoineParJour();
        }

        /*methodes*/
        public async Task recupererPrixActifsActuel()
        {
            List<string> listeSymboles = transactionbdd.getSymbolesActif();
            this.dictionnairePrixActif = await GestionnaireYahoo.GetPrixActifs(listeSymboles);
        }
        public double calculerEnregistrerValeurPatrimoineActuel(double ancienPrix)
        {
            double valeurPatrimoine = this.calculerValeurPatrimoineActuel(this.dictionnairePrixActif);
            if (valeurPatrimoine == 0) { throw new Exception("Auncun investissement effectué"); }
            if (valeurPatrimoine != ancienPrix)
            {
                valeurPatrimoinebdd.enregistrerValeurPatrimoineActuel(valeurPatrimoine, DateTime.Now);
            }
            ;
            return valeurPatrimoine;
        }
        private double calculerValeurPatrimoineActuel(Dictionary<string, double> dictionnairePrixParActif)
        {
            double valeurTotalePatrimoine = 0;
            foreach (KeyValuePair<string, string> symboleParActif in transactionbdd.getSymboleParActif())
            {
                double quantite = transactionbdd.getQuantiteTotaleDetenuDunActif(symboleParActif.Key);

                double prix = 0;
                if (dictionnairePrixParActif.ContainsKey(symboleParActif.Value))
                {
                    prix = dictionnairePrixParActif[symboleParActif.Value];
                }

                valeurTotalePatrimoine += quantite * prix;
            }
            return Math.Round(valeurTotalePatrimoine, 2);
        }
    }
}
