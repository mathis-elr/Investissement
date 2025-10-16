using MetroFramework.Controls;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;


namespace Investissement
{
    public class ModeleInvestController
    {
        /*ATTRIBUTS*/
        ModeleInvestBDD modeleInvestbdd;
        TransactionModelesController transactionModelesController;

        /*CONSTRUCTEUR*/
        public ModeleInvestController(BDD bdd)
        {
            this.modeleInvestbdd = new ModeleInvestBDD(bdd);
            this.transactionModelesController = new TransactionModelesController(bdd);
        }

        /*ENCAPSUALTION*/
        public string getDescriptionModeleInvest(string nomModele)
        {
            return modeleInvestbdd.getDescriptionModeleInvest(nomModele);
        }

        public List<(string actif, long quantite)> getTransactionsModele(string nomModele)
        {
            return transactionModelesController.getTransactionsModele(nomModele);
        }

        public DataTable getModelesDataTable()
        {
            return modeleInvestbdd.getModelesDataTable();
        }


        /**************
         ***METHODES***
         **************/

        public bool ajouterModele(ModeleInvest modeleInvest)
        {
            if (string.IsNullOrWhiteSpace(modeleInvest.nom))
                throw new Exception("Nom du modèle vide");
            if (string.IsNullOrWhiteSpace(modeleInvest.description))
                throw new Exception("Nom du modèle vide");

            return modeleInvestbdd.ajouterModele(modeleInvest);
        }

        public bool supprModele(string modeleInvest)
        {
            if(modeleInvestbdd.supprModele(modeleInvest))
            {
                return true;
            }
            return false;
        }

        public void ajouterTransactionsModele(TransactionModele transactionModele)
        {
            transactionModelesController.ajouterTransactionsModele(transactionModele);
        }

        public bool majNomDescription(string ancienNomModele, ModeleInvest ModeleInvestModifie)
        {
            if (modeleInvestbdd.majNomDescription(ancienNomModele, ModeleInvestModifie))
            {
                return true;
            }
            return false;
        }

        public bool editTransactionModele(string modeleInvest)
        {
            if(transactionModelesController.editTransactionModele(modeleInvest))
            {
                return true;
            }
            return false;
        }

        public bool supprTransactionModele(string nomActif)
        {
            if(transactionModelesController.supprTransactionModele(nomActif))
            {
                return true;
            }
            return false;
        }
    }
}
