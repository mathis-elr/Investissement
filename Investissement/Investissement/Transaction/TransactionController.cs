using System;
using System.Data.SQLite;
using System.Windows.Forms;
using MetroFramework.Controls;

namespace Investissement
{
    public class TransactionController
    {
        /*ATTRIBUTS*/
        Form1 form;
        TransactionBDD transactionbdd;

        /*CONSTRUCTEUR*/
        public TransactionController(Form1 form, BDD bdd)
        {
            this.form = form;
            this.transactionbdd = new TransactionBDD(bdd);
        }


        /**************
         ***METHODES***
         **************/
        public bool ajouterInvestissement()
        {
            foreach (DataGridViewRow transaction in form.getGridViewActifs().Rows)
            {
                DateTime date = form.getDateInvest().Value;
                var actif = transaction.Cells[0].Value;
                var quantiteVar = transaction.Cells[1].Value;
                var prixVar = transaction.Cells[2].Value;

                long quantiteLong = 0;
                long prixLong = 0;

                if (quantiteVar != DBNull.Value) quantiteLong = Convert.ToInt64(quantiteVar);
                if (prixVar != DBNull.Value) prixLong = Convert.ToInt64(prixVar);

                if (quantiteLong != 0 && prixLong != 0)
                {
                    Transaction nvltransaction = new Transaction(date, actif.ToString(), quantiteLong, prixLong);

                    try
                    {
                        transactionbdd.ajouterTransaction(nvltransaction);
                    }
                    catch (SQLiteException ex)
                    {
                        MessageBox.Show(ex.Message, "erreur insertion transaction bdd");
                        return false;
                    }
                }
            }
            return true;
        }

      
    }
}
