using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Investissement
{
    public class TransactionController
    {
        /*ATTRIBUTS*/
        TransactionBDD transactionbdd;

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

        public List<double> getListeQuantiteParTransaction()
        {
            return transactionbdd.getListeQuantiteParTransaction();
        }

        public List<(DateTime,double)> getListeQuantiteTotaleInvestitParDate()
        {
            return transactionbdd.getListeQuantiteTotaleInvestitParDate();
        }

        public double getQuantiteTotaleDetenuDunActif(string nomActif)
        {
            return transactionbdd.getQuantiteTotaleDetenuDunActif(nomActif);
        }

        public List<(string, double)> getListePaireQuantiteTotaleInvestitParActif()
        {
            return transactionbdd.getListePaireQuantiteTotaleInvestitParActif();
        }

        public List<(string, long)> getListePaireNombreTransactionParTypeActif()
        {
            return transactionbdd.getListePaireNombreTransactionParTypeActif();
        }

        public long getValeurTotaleInvestit()
        {
            long valeurTotaleInvestit = 0;
            foreach (long quantite in this.getListeQuantiteParTransaction())
            {
                valeurTotaleInvestit += quantite;
            }
            return valeurTotaleInvestit;
        }

        public async Task<double> getValeurTotalePatrimoineActuel()
        {
            List<string> listeSymboles = transactionbdd.getListeSymboleActif();
            //Dictionary<string, double> dictionnaireActifPrix = await APIFinnhub.getPrixActifsInvestit(listeSymboles);
            Dictionary<string, double> dictionnaireActifPrix = await ApiYahoo.GetPrixActifsInvestit(listeSymboles);

            double valeurTotalePatrimoine = 0;
            foreach ((string nomActif, string symboleActif) in transactionbdd.getListePaireNomSymboleActif())
            {
                // On récupère la quantité
                double quantite = transactionbdd.getQuantiteTotaleDetenuDunActif(nomActif);

                // On récupère le prix depuis le dictionnaire 
                double prix = 0;
                if (dictionnaireActifPrix.ContainsKey(symboleActif))
                {
                    prix = dictionnaireActifPrix[symboleActif];
                }

                // On additionne au total
                Console.WriteLine($"{quantite}, {prix}");
                valeurTotalePatrimoine += quantite * prix;
            }
            return valeurTotalePatrimoine;
        }


        /*METHODES*/
        public void ajouterTransaction(Transaction nvlTransaction)
        {
            transactionbdd.ajouterTransaction(nvlTransaction);
        }

        public void ajouterInvestissementTotalParDate(DateTime date, double sommeQuantite)
        {
            transactionbdd.ajouterInvestissementTotalParDate(date,sommeQuantite);
        }
    }
}
