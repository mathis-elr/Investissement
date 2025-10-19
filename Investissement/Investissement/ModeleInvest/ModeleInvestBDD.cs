using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Windows.Controls.Primitives;
using System.Windows.Forms;

namespace Investissement
{
    public class ModeleInvestBDD
    {
        /*ATTRIBUT*/
        public BDD maBDD;

        /*CONSTRUCTEUR*/
        public ModeleInvestBDD(BDD bdd)
        {
            this.maBDD = bdd;
        }

        /*ENCAPSULATION*/
        public DataTable getModelesDataTable()
        {
            DataTable modeleInvest = new DataTable();
            try
            {
                var query = "SELECT id,nom FROM ModeleInvest;";
                using (var command = new SQLiteCommand(query, this.maBDD.connexion))
                {
                    var noms = command.ExecuteReader();
                    modeleInvest.Load(noms);
                }
            }
            catch (SQLiteException ex)
            {
                Console.Error.WriteLine($"Erreur selection DataTable modele SQLite : {ex.Message}");
            }
            return modeleInvest;
        }

        public long? getIdModeleInvest(string nom)
        {
            long? idModele = null;
            try
            {
                var query = "SELECT id FROM ModeleInvest WHERE nom=@nom;";
                using (var command = new SQLiteCommand(query, this.maBDD.connexion))
                {
                    command.Parameters.AddWithValue("@nom", nom);
                    idModele = Convert.ToInt64(command.ExecuteScalar());
                }
            }
            catch (SQLiteException ex)
            {
                Console.Error.WriteLine($"Erreur selection id modele SQLite : {ex.Message}");
            }
            return idModele;
        }

        public string getDescriptionModeleInvest(string nom)
        {
            string description = null;
            try
            {
                var query = "SELECT description FROM ModeleInvest WHERE nom=@nom;";
                using (var command = new SQLiteCommand(query, this.maBDD.connexion))
                {
                    command.Parameters.AddWithValue("@nom", nom);
                    description = command.ExecuteScalar().ToString();
                }
            }
            catch (SQLiteException ex)
            {
                Console.Error.WriteLine($"Erreur selection description modele SQLite : {ex.Message}");
            }
            return description;

        }

        public (long?,string) getIdEtDescriptionModeleInvest(string nom)
        {
            try
            {
                var query = "SELECT id,description FROM ModeleInvest WHERE nom=@nom;";
                using (var command = new SQLiteCommand(query, this.maBDD.connexion))
                {
                    command.Parameters.AddWithValue("@nom", nom);
                    var modele = command.ExecuteReader();
                    modele.Read();
                    return (modele.GetInt64(0), modele.GetString(1));
                }
            }
            catch (SQLiteException ex)
            {
                Console.Error.WriteLine($"Erreur selection id et description modele SQLite : {ex.Message}");
                return (null, null);
            }
        }


        /*ENCAPSULATION TRANSACTIONS MODELE*/
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
            }
            catch (SQLiteException ex)
            {
                MessageBox.Show(ex.Message, "Erreur recuperation d'une transaction");
            }
            return listeTransactions;
        }


        /*METHODES MODELE INVEST*/
        public void ajouterModele(ModeleInvest modeleInvest)
        {
            try
            {
                string insertionModele = "INSERT INTO ModeleInvest(nom,description) VALUES(@nom,@description);";
                using (var commandInsertionModele = new SQLiteCommand(insertionModele, this.maBDD.connexion))
                {
                    commandInsertionModele.Parameters.AddWithValue("@nom", modeleInvest.nom);
                    commandInsertionModele.Parameters.AddWithValue("@description", modeleInvest.description);
                    commandInsertionModele.ExecuteNonQuery();
                }
                modeleInvest.id = (int)this.maBDD.connexion.LastInsertRowId; //pour pouvoir inserer les transactions associée à ce modele grace à son id
            }
            catch (SQLiteException ex)
            {
                Console.Error.WriteLine($"Erreur insertion modele SQLite : {ex.Message}");
                throw new Exception("une erreur est survenue lors de l'insertion d'un modele");
            }
        }

        public void supprModele(string modeleInvest)
        {
            try
            {
                if (this.transactionDependante(modeleInvest))
                { 
                    return;
                } 

                var suppressionModele = "DELETE FROM ModeleInvest WHERE nom=@nom;";
                using (var commandeSuppressionModele = new SQLiteCommand(suppressionModele, this.maBDD.connexion))
                {
                    commandeSuppressionModele.Parameters.AddWithValue("@nom", modeleInvest);
                    commandeSuppressionModele.ExecuteNonQuery();
                }
            }
            catch(SQLiteException ex)
            {
                Console.Error.WriteLine($"Erreur suppression modele SQLite : {ex.Message}");
                throw new Exception("une erreur est survenue lors de la suppresion du modele");
            }
        }

        public void majNomDescription(string ancienNomModele,ModeleInvest ModeleInvestModifie)
        {
            try
            {
                string insertionModele = "UPDATE ModeleInvest SET nom=@nom, description=@description WHERE nom=@nomModele;";
                using (var commandInsertionModele = new SQLiteCommand(insertionModele, this.maBDD.connexion))
                {
                    commandInsertionModele.Parameters.AddWithValue("@nom", ModeleInvestModifie.nom);
                    commandInsertionModele.Parameters.AddWithValue("@description", ModeleInvestModifie.description);
                    commandInsertionModele.Parameters.AddWithValue("@nomModele", ancienNomModele);
                    commandInsertionModele.ExecuteNonQuery();
                }
            }
            catch (SQLiteException ex)
            {
                Console.Error.WriteLine($"Erreur modification modele (nom ou description) SQLite : {ex.Message}");
                throw new Exception("une erreur est survenue lors de la modification des informations du modele");
            }
        }


        /*METHODES TRANSACTIONS MODELE*/
        private bool transactionDependante(string modeleInvest)
        {
            try
            {
                var selectionTransactionDependantes = "SELECT COUNT(*) FROM TransactionsModele JOIN ModeleInvest ON ModeleInvest.id=TransactionsModele.idModele WHERE nom=@nom;";
                using (var commandeselectionTransactionDependantes = new SQLiteCommand(selectionTransactionDependantes, this.maBDD.connexion))
                {
                    commandeselectionTransactionDependantes.Parameters.AddWithValue("@nom", modeleInvest);
                    long nbTransactions = Convert.ToInt64(commandeselectionTransactionDependantes.ExecuteScalar());
                    if (nbTransactions > 0) { throw new Exception("impossible de supprimer le modele, des transactions en dépendent"); }
                    return false;
                }
            }
            catch (SQLiteException ex)
            {
                Console.Error.WriteLine($"Erreur lors du test : transactionDependante(unModele) SQLite : {ex.Message}");
                return true; //pour faire arreter la fonction de suppression
            }
        }
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
                Console.Error.WriteLine($"Erreur insertion transaction Modele SQLite : {ex.Message}");
                throw new Exception("une erreur est survenue lors de l'insertion d'une transaction");
            }
        }

        public void supprTransactionModele(long idModeleAssocie, string nomActif)
        {
            try
            {
                var suppressionTransactionModele = "DELETE FROM TransactionsModele WHERE idModele=@idModele AND actif=@actif;";
                using (var commandeSuppressionTransactionModele = new SQLiteCommand(suppressionTransactionModele, this.maBDD.connexion))
                {
                    commandeSuppressionTransactionModele.Parameters.AddWithValue("@actif", nomActif);
                    commandeSuppressionTransactionModele.Parameters.AddWithValue("@idModele", idModeleAssocie);
                    commandeSuppressionTransactionModele.ExecuteNonQuery();
                }
            }
            catch (SQLiteException ex)
            {
                Console.Error.WriteLine($"Erreur suppression transaction Modele SQLite : {ex.Message}");
                throw new Exception("une erreur est survenue lors de la suppression d'une transaction");
            }
        }

        public void supprTransactionsModele(string nomModele)
        {
            try
            {
                var suppressionTransactionModele = "DELETE FROM TransactionsModele WHERE idModele=(SELECT id FROM ModeleInvest WHERE nom=@nom);";
                using (var commandeSuppressionTransactionModele = new SQLiteCommand(suppressionTransactionModele, this.maBDD.connexion))
                {
                    commandeSuppressionTransactionModele.Parameters.AddWithValue("@nom", nomModele);
                    commandeSuppressionTransactionModele.ExecuteNonQuery();
                }
            }
            catch (SQLiteException ex)
            {
                Console.Error.WriteLine($"Erreur suppression transactions Modele SQLite : {ex.Message}");
                throw new Exception("une erreur est survenue lors de la suppression de transactions");
            }
        }
    }
}
