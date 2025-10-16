using MetroFramework.Controls;
using System;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Windows.Forms;

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


        /**************
         ***METHODES***
         **************/
        public bool ajouterInvestissement(Transaction nvlTransaction)
        {
            return transactionbdd.ajouterTransaction(nvlTransaction);
        }
    }
}
