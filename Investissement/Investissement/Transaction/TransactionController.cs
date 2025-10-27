using System.Collections.Generic;
using System.Threading.Tasks;
using System;

/*
 A FAIRE :
- manque de gestion d'erreur en general
 */

namespace Investissement
{
    public class TransactionController
    {
        /*ATTRIBUTS*/
        TransactionBDD transactionbdd;
        Dictionary<string, double> dictionnairePrixActif;

        /*CONSTRUCTEUR*/
        public TransactionController(BDD bdd)
        {
            this.transactionbdd = new TransactionBDD(bdd);
        }

        /*ENCAPSULATION*/
        public Dictionary<string, double> getValeurActuelleParActif()
        {
            Dictionary<string, double> dictionaireValeurActuelle = new Dictionary<string, double>();
            foreach (SyntheseDetentionActif syntheseDetentionActif in transactionbdd.getSynthesesDetentionActifs())
            {
                double prixActuelActif = this.dictionnairePrixActif[syntheseDetentionActif.symboleActif];
                double quantiteEUR = syntheseDetentionActif.quantiteTotaleDetenue * prixActuelActif;
                dictionaireValeurActuelle[syntheseDetentionActif.nomActif] = quantiteEUR;
            }
            return dictionaireValeurActuelle;
        }
        public Dictionary<string, double> getQuantiteInvestitParTypeActif()
        {
            Dictionary<string, double> dictionnaireQuantiteInvestitParTypeActif = new Dictionary<string, double>();
            foreach (SyntheseDetentionActif syntheseDetentionActif in transactionbdd.getSynthesesDetentionActifs())
            {
                double prixActuelActif = this.dictionnairePrixActif[syntheseDetentionActif.symboleActif];
                double quantiteEUR = syntheseDetentionActif.quantiteTotaleDetenue * prixActuelActif;
                if(dictionnaireQuantiteInvestitParTypeActif.ContainsKey(syntheseDetentionActif.typeActif))
                {
                    dictionnaireQuantiteInvestitParTypeActif[syntheseDetentionActif.typeActif] += quantiteEUR;
                }
                else
                {
                    dictionnaireQuantiteInvestitParTypeActif.Add(syntheseDetentionActif.typeActif, quantiteEUR);
                }

            }
            return dictionnaireQuantiteInvestitParTypeActif;
        }
        public Dictionary<DateTime, double> getQuantiteInvestitParDate()
        {
            return transactionbdd.getQuantiteInvestitParDate();
        }
        public Dictionary<DateTime, double> getMoyenneValeurPatrimoineParJour()
        {
            return transactionbdd.getMoyenneValeurPatrimoineParJour();
        }


        /*METHODES*/
        public void ajouterTransaction(Transaction nvlTransaction)
        {
            transactionbdd.ajouterTransaction(nvlTransaction);
        }
        public void ajouterInvestissementTotalParDate(DateTime date, double quantiteTotaleEnEUR)
        {
            transactionbdd.ajouterInvestissementTotalParDate(date, quantiteTotaleEnEUR);
        }
        public async Task recupererPrixActifsActuel()
        {
            List<string> listeSymboles = transactionbdd.getSymbolesActif();
            this.dictionnairePrixActif = await GestionnaireYahoo.GetPrixActifs(listeSymboles);
        }
        public double calculerEnregistrerValeurPatrimoineActuel()
        {
            double valeurPatrimoine = this.calculerValeurPatrimoineActuel();
            if(valeurPatrimoine == 0) { throw new Exception("Auncun investissement effectué"); }
            transactionbdd.enregistrerValeurPatrimoineActuel(valeurPatrimoine);
            return valeurPatrimoine;
        }
        private double calculerValeurPatrimoineActuel()
        {
            double valeurTotalePatrimoine = 0;
            foreach (KeyValuePair<string,string> symboleParActif in transactionbdd.getSymboleParActif())
            {
                double quantite = transactionbdd.getQuantiteTotaleDetenuDunActif(symboleParActif.Key);

                double prix = 0;
                if (this.dictionnairePrixActif.ContainsKey(symboleParActif.Value))
                {
                    prix = this.dictionnairePrixActif[symboleParActif.Value];
                }

                valeurTotalePatrimoine += quantite * prix;
            }
            return Math.Round(valeurTotalePatrimoine, 1);
        }
        public double calculerProportion(double part, double partTotale)
        {
            return Math.Round(part / partTotale * 100, 2);
        }
    }
}
