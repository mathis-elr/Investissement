using System.Collections.Generic;
using System.Threading.Tasks;
using System;

/*
 A FAIRE :
- recupererPrixActifsActuel gestion d'erreur (ex quand on est hors connexion, que ca affiche un message d'erreur et pas un crash de l'application
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
        public List<(DateTime,double)> getPaireQuantiteTotaleInvestitEURParDate()
        {
            return transactionbdd.getListeQuantiteTotaleInvestitEURParDate();
        }
        public List<(string, double)> getPaireQuantiteEnEURTotaleInvestitParActif()
        {
            List<(string, double)> listePaireQuantiteEnEURTotaleInvestitParActif = new List<(string, double)>();
            foreach ((string actif, string symbole, string type, double quantiteTotale) in transactionbdd.getListeQuantiteTotaleInvestitParActif())
            {
                double prixActuelActif = this.dictionnairePrixActif[symbole];
                double quantiteEUR = quantiteTotale * prixActuelActif;
                listePaireQuantiteEnEURTotaleInvestitParActif.Add((actif, quantiteEUR));
            }
            return listePaireQuantiteEnEURTotaleInvestitParActif;
        }
        public Dictionary<string, double> getDictionnaireQuantiteEnEURTotaleInvestitParTypeActif()
        {
            Dictionary<string, double> dictionnaireQuantiteEnEURTotaleInvestitParTypeActif = new Dictionary<string, double>();
            foreach ((string actif,string symbole,string type,double quantiteTotale) in transactionbdd.getListeQuantiteTotaleInvestitParActif())
            {
                double prixActuelActif = this.dictionnairePrixActif[symbole];
                double quantiteEUR = quantiteTotale * prixActuelActif;
                if(dictionnaireQuantiteEnEURTotaleInvestitParTypeActif.ContainsKey(type))
                {
                    dictionnaireQuantiteEnEURTotaleInvestitParTypeActif[type] += quantiteEUR;
                }
                else
                {
                    dictionnaireQuantiteEnEURTotaleInvestitParTypeActif.Add(type, quantiteEUR);
                }

            }
            return dictionnaireQuantiteEnEURTotaleInvestitParTypeActif;
        }
        public double getValeurTotalePatrimoineActuel()
        {
            double valeurTotalePatrimoine = 0;
            foreach ((string nomActif, string symboleActif) in transactionbdd.getListePaireNomSymboleActif())
            {
                double quantite = transactionbdd.getQuantiteTotaleDetenuDunActif(nomActif);

                double prix = 0;
                if (this.dictionnairePrixActif.ContainsKey(symboleActif))
                {
                    prix = this.dictionnairePrixActif[symboleActif];
                }

                valeurTotalePatrimoine += quantite * prix;
            }
            return Math.Round(valeurTotalePatrimoine, 1);
        }
        public double getProportion(double part, double partTotale)
        {
            return Math.Round(part/partTotale * 100, 2);
        }
        public async Task recupererPrixActifsActuel()
        {
            List<string> listeSymboles = transactionbdd.getListeSymboleActif();
            this.dictionnairePrixActif = await GestionnaireYahoo.GetPrixActifs(listeSymboles);
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
    }
}
