using System.Collections.Generic;
using System.Data;
using System;


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
        public string getDescriptionModeleInvest(long idModele)
        {
            return modeleInvestbdd.getDescriptionModeleInvest(idModele);
        }

        public DataTable getModelesDataTable()
        {
            return modeleInvestbdd.getModelesDataTable();
        }

        /*ENCAPSULATION TRANSACTIONS MODELE*/
        public List<(string actif, long quantite)> getTransactionsModele(long idModele)
        {
            return modeleInvestbdd.getTransactionsModele(idModele);
        }


        /*METHODES MODELE INVEST*/
        public void ajouterModele(ModeleInvest modeleInvest)
        {
            if (string.IsNullOrEmpty(modeleInvest.nom)) { throw new ArgumentException("Nom du modèle vide"); }
            modeleInvestbdd.ajouterModele(modeleInvest);
        }

        public void majNomDescription(long idAncienModele, ModeleInvest modeleInvestModifie)
        {
            if (string.IsNullOrEmpty(modeleInvestModifie.nom)) { throw new ArgumentException("Nom du modèle vide"); }
            modeleInvestbdd.majNomDescription(idAncienModele, modeleInvestModifie);
        }

        public void supprModele(long idModele)
        {
            modeleInvestbdd.supprModele(idModele);
        }


        /*METHODES TRANSACTIONS MODELE*/
        public void ajouterTransactionsModele(TransactionModele transactionModele)
        {
            if (string.IsNullOrEmpty(transactionModele.actif)) { throw new ArgumentException("modele inconnu"); }
            modeleInvestbdd.ajouterTransactionsModele(transactionModele);
        }
        public void supprUneTransactionModele(long idModeleAssocie, string nomActif)
        {
            if (string.IsNullOrEmpty(nomActif)) { throw new ArgumentException("Nom du modele vide"); }
            modeleInvestbdd.supprUneTransactionModele(idModeleAssocie, nomActif);
        }
        public void supprToutesTransactionsModele(long idModele)
        {
            modeleInvestbdd.supprToutesTransactionsModele(idModele);
        }
    }
}
