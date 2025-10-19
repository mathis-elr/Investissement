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


         /*METHODES*/
        public void ajouterTransaction(Transaction nvlTransaction)
        {
            transactionbdd.ajouterTransaction(nvlTransaction);
        }

        public void ajouterInvestissementTotalParDate(DateTime date, long sommeQuantite)
        {
            transactionbdd.ajouterInvestissementTotalParDate(date,sommeQuantite);
        }

        public long calculerValeurTotaleInvestit()
        {
            long valeurTotaleInvestit = 0;
            foreach (long quantite in this.getQuantiteTransactions())
            {
                valeurTotaleInvestit += quantite;
            }
            return valeurTotaleInvestit;
        }
    }
}
