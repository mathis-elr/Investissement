using System.Collections.Generic;
using System.Data.SQLite;
using System;
using System.ComponentModel.Design;


namespace Investissement
{
    public class TransactionBDD
    {
        /*ATTRIBUTS*/
        public BDD maBDD;

        /*CONSTRUCTEUR*/
        public TransactionBDD(BDD bdd)
        {
            this.maBDD = bdd;
        }


        /*ENCAPSULATION*/
        public List<long> getQuantiteTransactions()
        {
            List<long> listeQuantiteTransaction = new List<long>();
            try
            {
                string selectionQuantiteTransaction = "SELECT quantite FROM [Transaction];";
                using (var commandSelectionQuantiteTransaction = new SQLiteCommand(selectionQuantiteTransaction, this.maBDD.connexion))
                {
                    var quantiteTransaction = commandSelectionQuantiteTransaction.ExecuteReader();
                    while(quantiteTransaction.Read())
                    {
                        listeQuantiteTransaction.Add(quantiteTransaction.GetInt64(0));
                    }
                }
            }
            catch (SQLiteException ex)
            {
                Console.Error.WriteLine($"Erreur selection quantite transactions SQLite : {ex.Message}");
            }
            return listeQuantiteTransaction;
        }

        public List<(DateTime,long)> getsommeQuantiteParDateInvest()
        {
            List<(DateTime, long)> listeQuantiteTransactionsParDateInvest = new List<(DateTime, long)>();
            try
            {
                string selectionQuantiteTransactionParDate = "SELECT date, quantite FROM InvestissementTotalParDate ORDER BY date;";
                using (var commandSelectionQuantiteTransactionParDate = new SQLiteCommand(selectionQuantiteTransactionParDate, this.maBDD.connexion))
                {
                    var quantiteTransactionParDate = commandSelectionQuantiteTransactionParDate.ExecuteReader();
                    while (quantiteTransactionParDate.Read())
                    {
                        listeQuantiteTransactionsParDateInvest.Add((quantiteTransactionParDate.GetDateTime(0), quantiteTransactionParDate.GetInt64(1)));
                    }
                }
            }
            catch (SQLiteException ex)
            {
                Console.Error.WriteLine($"Erreur selection quantite transactions SQLite : {ex.Message}");
            }
            return listeQuantiteTransactionsParDateInvest;
        }


        /*METHODES*/
        public void ajouterTransaction(Transaction transaction)
        {
            try
            {
                string query = "INSERT INTO [Transaction] (date,actif,quantite,prix) VALUES (@date,@actif,@quantite,@prix);"; //entre crochets car Transaction est un mot réservé en sql
                using (var command = new SQLiteCommand(query, this.maBDD.connexion))
                {
                    command.Parameters.AddWithValue("@date", transaction.date.ToString("yyyy-MM-dd"));
                    command.Parameters.AddWithValue("@actif", transaction.actif);
                    command.Parameters.AddWithValue("@quantite", transaction.quantite);
                    command.Parameters.AddWithValue("@prix", transaction.prix);

                    command.ExecuteNonQuery();
                }
            }
            catch (SQLiteException ex)
            {
                Console.Error.WriteLine($"Erreur insertion transaction SQLite : {ex.Message}");
                throw new Exception("une erreur est survenue lors de l'insertion d'une transaction");
            }
        }

        public void ajouterInvestissementTotalParDate(DateTime date, long sommeQuantite)
        {
            try
            {
                long quantiteDernierInvest =  0;
                string selectionQuantiteDernierInvest = "SELECT quantite FROM InvestissementTotalParDate ORDER BY date DESC LIMIT 1;"; //entre crochets car Transaction est un mot réservé en sql
                using (var commandSelectionQuantiteDernierInvest = new SQLiteCommand(selectionQuantiteDernierInvest, this.maBDD.connexion))
                {
                    quantiteDernierInvest = Convert.ToInt64(commandSelectionQuantiteDernierInvest.ExecuteScalar());
                }

                string query = "INSERT INTO InvestissementTotalParDate (date,quantite) VALUES (@date,@sommeQuantite);"; //entre crochets car Transaction est un mot réservé en sql
                using (var command = new SQLiteCommand(query, this.maBDD.connexion))
                {
                    long totalInvest = quantiteDernierInvest + sommeQuantite;
                    command.Parameters.AddWithValue("@date", date.ToString("yyyy-MM-dd"));
                    command.Parameters.AddWithValue("@sommeQuantite", totalInvest);

                    command.ExecuteNonQuery();
                }
            }
            catch (SQLiteException ex)
            {
                Console.Error.WriteLine($"Erreur insertion investissement total par date SQLite : {ex.Message}");
            }
        }
    }
}
