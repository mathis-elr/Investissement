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

        /*CONSTRUCTEUR*/
        public ModeleInvestController(BDD bdd)
        {
            this.modeleInvestbdd = new ModeleInvestBDD(bdd);
        }

        /*ENCAPSUALTION MODELE INVEST*/
        public string getDescriptionModeleInvest(string nomModele)
        {
            return modeleInvestbdd.getDescriptionModeleInvest(nomModele);
        }

        public DataTable getModelesDataTable()
        {
            return modeleInvestbdd.getModelesDataTable();
        }

        /*ENCAPSULATION TRANSACTIONS MODELE*/
        public List<(string actif, long quantite)> getTransactionsModele(string nomModele)
        {
            return modeleInvestbdd.getTransactionsModele(nomModele);
        }


        /*METHODES MODELE INVEST*/

        public void ajouterModele(ModeleInvest modeleInvest)
        {
            if (string.IsNullOrEmpty(modeleInvest.nom)) { throw new ArgumentException("Nom du modèle vide"); }
            modeleInvestbdd.ajouterModele(modeleInvest);
        }

        public void majNomDescription(string ancienNomModele, ModeleInvest modeleInvestModifie)
        {
            if (string.IsNullOrEmpty(ancienNomModele)) { throw new ArgumentException("modele inconnu"); }
            if (string.IsNullOrEmpty(modeleInvestModifie.nom)) { throw new ArgumentException("Nom du modèle vide"); }
            modeleInvestbdd.majNomDescription(ancienNomModele, modeleInvestModifie);
        }

        public void supprModele(string modeleInvest)
        {
            if (string.IsNullOrEmpty(modeleInvest)) { throw new ArgumentException("modele inconnu"); }
            modeleInvestbdd.supprModele(modeleInvest);
        }


        /*METHODES TRANSACTIONS MODELE*/
        public void ajouterTransactionsModele(TransactionModele transactionModele)
        {
            if (string.IsNullOrEmpty(transactionModele.actif)) { throw new ArgumentException("modele inconnu"); }
            modeleInvestbdd.ajouterTransactionsModele(transactionModele);
        }

        public void supprTransactionsModele(string modeleInvest)
        {
            if (string.IsNullOrEmpty(modeleInvest)) { throw new ArgumentException("modele inconnu"); }
            modeleInvestbdd.supprTransactionsModele(modeleInvest);
        }

        public void supprTransactionModele(long idModeleAssocie, string nomActif)
        {
            if (string.IsNullOrEmpty(nomActif)) { throw new ArgumentException("Nom du modele vide"); }
            modeleInvestbdd.supprTransactionModele(idModeleAssocie, nomActif);
        }

    }
}
