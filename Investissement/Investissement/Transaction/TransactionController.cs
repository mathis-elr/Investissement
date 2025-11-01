using System.Collections.Generic;
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
        private readonly TransactionBDD transactionbdd;
        private readonly ValeurPatrimoineController valeurPatrimoineController;

        /*CONSTRUCTEUR*/
        public TransactionController(BDD bdd, ValeurPatrimoineController valeurPatrimoineController)
        {
            this.transactionbdd = new TransactionBDD(bdd);
            this.valeurPatrimoineController = valeurPatrimoineController;
        }

        /*ENCAPSULATION*/
        public Dictionary<string, double> getValeurActuelleParActif()
        {
            Dictionary<string, double> dictionaireValeurActuelle = new Dictionary<string, double>();
            foreach (SyntheseDetentionActif syntheseDetentionActif in transactionbdd.getSynthesesDetentionActifs())
            {
                double prixActuelActif = valeurPatrimoineController.dictionnairePrixActif[syntheseDetentionActif.symboleActif];
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
                double prixActuelActif = valeurPatrimoineController.dictionnairePrixActif[syntheseDetentionActif.symboleActif];
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


        /*METHODES*/
        public void ajouterTransaction(Transaction nvlTransaction)
        {
            transactionbdd.ajouterTransaction(nvlTransaction);
        }
        public double calculerProportion(double part, double partTotale)
        {
            return Math.Round(part / partTotale * 100, 2);
        }
    }
}
