using System.Data.SQLite;
using System.Collections.Generic;
using System.Windows.Forms;
using System;

namespace Investissement
{
    public class TransactionModeleBDD
    {
        /*ATTRIBUTS*/
        public BDD maBDD;

        /*CONSTRUCTEUR*/
        public TransactionModeleBDD(BDD bdd)
        {
            this.maBDD = bdd;
        }

        /*ENCAPSULATION*/
        public List<(string actif, long quantite)> getTransactionsModele(string nomModele)
        {
            var listeTransactions = new List<(string actif, long quantite)>();

            try
            {
                var queryTransactions = "SELECT actif,quantite FROM TransactionsModele JOIN ModeleInvest ON ModeleInvest.id=TransactionsModele.idModele WHERE nom=@nom;";
                using (var commandTransactions = new SQLiteCommand(queryTransactions, this.maBDD.connexion))
                {
                    commandTransactions.Parameters.AddWithValue("@nom", nomModele);

                    using (var transactions = commandTransactions.ExecuteReader())
                    {

                        while (transactions.Read())
                        {
                            listeTransactions.Add((transactions.GetString(0), transactions.GetInt64(1)));
                        }
                    }
                }
                return listeTransactions;
            }
            catch (SQLiteException ex)
            {
                MessageBox.Show(ex.Message, "Erreur recuperation d'une transaction");
                return listeTransactions;
            }
        }


        /**************
         ***METHODES***
         **************/

        public void ajouterTransactionsModele(TransactionModele transaction)
        {
            try
            {
                string insertionTransactions = "INSERT INTO TransactionsModele(actif,quantite,idModele) VALUES(@actif,@quantite,@idModele);";
                using (var commandInsertionTransactions = new SQLiteCommand(insertionTransactions, this.maBDD.connexion))
                {
                    commandInsertionTransactions.Parameters.AddWithValue("@actif", transaction.actif);
                    commandInsertionTransactions.Parameters.AddWithValue("@quantite", transaction.quantite);
                    commandInsertionTransactions.Parameters.AddWithValue("@idModele", transaction.id_modele);
                    commandInsertionTransactions.ExecuteNonQuery();
                }
            }
            catch (SQLiteException ex)
            {
                MessageBox.Show(ex.Message, "Erreur insertion transaction modele");
            }
        }

        public bool supprTransactionModele(string nomActif)
        {
            try
            {
                var suppressionTransactionModele = "DELETE FROM TransactionsModele WHERE actif=@actif;";
                using (var commandeSuppressionTransactionModele = new SQLiteCommand(suppressionTransactionModele, this.maBDD.connexion))
                {
                    commandeSuppressionTransactionModele.Parameters.AddWithValue("@actif", nomActif);
                    commandeSuppressionTransactionModele.ExecuteNonQuery();
                }
                return true;
            }
            catch(SQLiteException ex)
            {
                MessageBox.Show(ex.Message, "Erreur suppresion transaction modele");
                return false;
            }
        }

        public bool supprTransactionsModele(string nomModele)
        {
            try
            {
                var suppressionTransactionModele = "DELETE FROM TransactionsModele WHERE idModele=(SELECT id FROM ModeleInvest WHERE nom=@nom);";
                using (var commandeSuppressionTransactionModele = new SQLiteCommand(suppressionTransactionModele, this.maBDD.connexion))
                {
                    commandeSuppressionTransactionModele.Parameters.AddWithValue("@nom", nomModele);
                    commandeSuppressionTransactionModele.ExecuteNonQuery();
                }
                return true;
            }
            catch (SQLiteException ex)
            {
                MessageBox.Show(ex.Message, "Erreur suppresion des transactions d'un modele");
                return false;
            }
        }
    }
}
