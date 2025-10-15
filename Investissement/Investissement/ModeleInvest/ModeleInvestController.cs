using MetroFramework.Controls;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;


namespace Investissement
{
    public class ModeleInvestController
    {
        /*ATTRIBUTS*/
        Form1 form;
        ModeleInvestBDD modeleInvestbdd;
        TransactionModelesController transactionModelesController;

        /*CONSTRUCTEUR*/
        public ModeleInvestController(Form1 form, BDD bdd)
        {
            this.form = form;
            this.modeleInvestbdd = new ModeleInvestBDD(bdd);
            this.transactionModelesController = new TransactionModelesController(this.form,this.modeleInvestbdd , bdd);
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

        /**************
         ***METHODES***
         **************/
        public void chargerModeles()
        {
            try
            {
                MetroComboBox modeles = form.getComboBoxModeles();
                DataTable modeleInvest = modeleInvestbdd.getModelesDataTable();
                modeles.DataSource = modeleInvest;
                modeles.DisplayMember = "nom";
            }
            catch (SQLiteException ex)
            {
                MessageBox.Show(ex.Message, "Erreur selection modeles BDD");
            }
        }


        public bool ajouterModele(string nom,string description)
        {
            ModeleInvest modeleInvest = new ModeleInvest(nom,description);
            if (modeleInvestbdd.ajouterModele(modeleInvest))
            {
                transactionModelesController.ajouterTransactionsModele(modeleInvest.id);
                this.chargerModeles(); //mise a jour du combo box pour pouvoir utiliser le modele crée
                return true;
            }
            return false;
        }

        public bool supprModele(string modeleInvest)
        {
            if(modeleInvestbdd.supprModele(modeleInvest))
            {
                this.chargerModeles();
                return true;
            }
            return false;
        }

        public bool majNomDescription(string nomModele, string nvNom,string nvDescription)
        {
            if (modeleInvestbdd.majNomDescription(nomModele, nvNom, nvDescription))
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

        public bool supprTransactionModele()
        {
            if(transactionModelesController.supprTransactionModele())
            {
                return true;
            }
            return false;
        }
    }
}
