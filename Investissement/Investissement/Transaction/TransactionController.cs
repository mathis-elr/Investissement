using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TwelveDataSharp.Api.ResponseModels;

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
        public long getNombreTransaction()
        {
            return transactionbdd.getNombreTransaction();
        }

        public List<(double,double)> getPaireQuantitePrixParTransaction()
        {
            return transactionbdd.getPaireQuantitePrixParTransaction();
        }

        public List<(DateTime,double)> getListeQuantiteTotaleInvestitEURParDate()
        {
            return transactionbdd.getListeQuantiteTotaleInvestitEURParDate();
        }

        public double getQuantiteTotaleDetenuDunActif(string nomActif)
        {
            return transactionbdd.getQuantiteTotaleDetenuDunActif(nomActif);
        }

        public List<(string, double)> getListePaireQuantiteEnEURTotaleInvestitParActif()
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

        public double getValeurTotaleInvestit()
        {
            double valeurTotaleInvestit = 0;
            foreach ((double quantite, double prix) in this.getPaireQuantitePrixParTransaction())
            {
                valeurTotaleInvestit += quantite * prix;
            }
            return Math.Round(valeurTotaleInvestit,1);
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
            this.dictionnairePrixActif = await GestionnairePrixActifs.GetPrixActifs(listeSymboles);
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
