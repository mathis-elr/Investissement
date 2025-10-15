using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Investissement
{
    public class TransactionModelesController
    {
        /*ATTRIBUTS*/
        Form1 form;
        TransactionModeleBDD transactionModelebdd;
        ModeleInvestBDD modeleInvestbdd;

        /*CONSTRUCTEUR*/
        public TransactionModelesController(Form1 form,ModeleInvestBDD modeleInvestbdd, BDD bdd)
        {
            this.form = form;
            this.transactionModelebdd = new TransactionModeleBDD(bdd);
            this.modeleInvestbdd = modeleInvestbdd;
        }


        /*ENCAPSULATON*/
        public List<(string actif, long quantite)> getTransactionsModele(string nomModele)
        {
            return transactionModelebdd.getTransactionsModele(nomModele);
        }


        /**************
         ***METHODES***
         **************/
        public void ajouterTransactionsModele(long idModele)
        {
            foreach (DataGridViewRow transaction in form.getGridViewActifs().Rows)
            {
                if (transaction.IsNewRow) continue; //ne prend pas en compte la ligne vide en bas

                string actif = transaction.Cells[0].Value.ToString();
                var quantiteVar = transaction.Cells[1].Value;
                long quantiteLong = 0;
                if (quantiteVar != DBNull.Value) quantiteLong = Convert.ToInt64(quantiteVar);

                if (quantiteLong != 0)
                {
                    TransactionModele transactionModele = new TransactionModele(actif, quantiteLong, idModele);
                    transactionModelebdd.ajouterTransactionsModele(transactionModele);
                }
            }
        }

        public bool supprTransactionModele()
        {
            if (form.getGridViewActifs().SelectedRows.Count > 0)
            {
                DataGridViewRow row = form.getGridViewActifs().SelectedRows[0];
                string nomActif = row.Cells["Nom"].Value.ToString();
                DialogResult result = MessageBox.Show(
                    "Voulez-vous vraiment supprimer cette transaction ?", 
                    "Confirmation",                               
                    MessageBoxButtons.YesNo,                      
                    MessageBoxIcon.Question                       
                );

                if (result == DialogResult.Yes)
                {
                    if (transactionModelebdd.supprTransactionModele(nomActif))
                    {
                        form.changerModele(); //pour que la grille se mette a jour en consequence de la suppression d'une transaction
                        return true;
                    }
                }
            }
            return false;
        }


        public bool editTransactionModele(string nomModele)
        {
            if(transactionModelebdd.supprTransactionsModele(nomModele))
            {
                long idModele = modeleInvestbdd.getIdModeleInvest(nomModele);
                this.ajouterTransactionsModele(idModele);
            }
            return true;
        }
    }
}
