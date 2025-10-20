using System;
using System.Collections.Generic;

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
        private List<long> getQuantiteTransactions()
        {
            return transactionbdd.getQuantiteTransactions();
        }

        public List<(DateTime,long)> getsommeQuantiteParDateInvest()
        {
            return transactionbdd.getsommeQuantiteParDateInvest();
        }

        public long getQuantiteTotale(string nomActif)
        {
            return transactionbdd.getQuantiteTotale(nomActif);
        }

        public List<(string, long)> getListeActifQuantiteTotaleInvestit()
        {
            return transactionbdd.getListeActifQuantiteTotaleInvestit();
        }

        public long getValeurTotalePatrimoine()
        {
            long valeurTotalePatrimoine = 0;
            foreach (string nomActif in transactionbdd.getListeActifs())
            {
                valeurTotalePatrimoine += transactionbdd.getQuantiteTotale(nomActif); //faudra faire * prix actuel de l'actif
            }
            return valeurTotalePatrimoine;
        }

        public long getValeurTotaleInvestit()
        {
            long valeurTotaleInvestit = 0;
            foreach (long quantite in this.getQuantiteTransactions())
            {
                valeurTotaleInvestit += quantite;
            }
            return valeurTotaleInvestit;
        }


        /*METHODES*/
        public void ajouterTransaction(Transaction nvlTransaction)
        {
            transactionbdd.ajouterTransaction(nvlTransaction);
        }

        public void ajouterInvestissementTotalParDate(DateTime date, long sommeQuantite)
        {
            transactionbdd.ajouterInvestissementTotalParDate(date,sommeQuantite);
        }
    }
}
