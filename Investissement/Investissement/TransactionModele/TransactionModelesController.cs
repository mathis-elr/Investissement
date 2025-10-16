using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Investissement
{
    public class TransactionModelesController
    {
        /*ATTRIBUTS*/
        TransactionModeleBDD transactionModelebdd;

        /*CONSTRUCTEUR*/
        public TransactionModelesController(BDD bdd)
        {
            this.transactionModelebdd = new TransactionModeleBDD(bdd);
        }


        /*ENCAPSULATON*/
        public List<(string actif, long quantite)> getTransactionsModele(string nomModele)
        {
            return transactionModelebdd.getTransactionsModele(nomModele);
        }


        /**************
         ***METHODES***
         **************/
        public void ajouterTransactionsModele(TransactionModele transactionModele)
        {
            transactionModelebdd.ajouterTransactionsModele(transactionModele);
        }

        public bool supprTransactionModele(string nomActif)
        {
            return transactionModelebdd.supprTransactionModele(nomActif);
        }


        public bool editTransactionModele(string nomModele)
        {
            if(transactionModelebdd.supprTransactionsModele(nomModele))
            {
                return true;
            }
            return false;
        }
    }
}
