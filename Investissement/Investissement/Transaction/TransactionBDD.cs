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
        public long getNombreTransaction()
        {
            long nombreTransaction = 0;
            try
            {
                string selectionQuantiteTotalActif = "SELECT COUNT(*) FROM [transaction];";
                using (var commandSelectionQuantiteTotalActif = new SQLiteCommand(selectionQuantiteTotalActif, this.maBDD.connexion))
                {
                    nombreTransaction = Convert.ToInt64(commandSelectionQuantiteTotalActif.ExecuteScalar());

                }
            }
            catch (SQLiteException ex)
            {
                Console.Error.WriteLine($"Erreur selection quantite totale d'un actif SQLite : {ex.Message}");
            }
            return nombreTransaction;
        }

        public List<double> getListeQuantiteParTransaction()
        {
            List<double> listeQuantiteTransaction = new List<double>();
            try
            {
                string selectionQuantiteTransaction = "SELECT quantite FROM [Transaction];";
                using (var commandSelectionQuantiteTransaction = new SQLiteCommand(selectionQuantiteTransaction, this.maBDD.connexion))
                {
                    var quantiteTransaction = commandSelectionQuantiteTransaction.ExecuteReader();
                    while(quantiteTransaction.Read())
                    {
                        listeQuantiteTransaction.Add(quantiteTransaction.GetDouble(0));
                    }
                }
            }
            catch (SQLiteException ex)
            {
                Console.Error.WriteLine($"Erreur selection quantite transactions SQLite : {ex.Message}");
            }
            return listeQuantiteTransaction;
        }

        public List<(DateTime,double)> getListeQuantiteTotaleInvestitParDate()
        {
            List<(DateTime, double)> listeQuantiteTransactionsParDateInvest = new List<(DateTime, double)>();
            try
            {
                string selectionQuantiteTransactionParDate = "SELECT date, quantite FROM InvestissementTotalParDate ORDER BY date;";
                using (var commandSelectionQuantiteTransactionParDate = new SQLiteCommand(selectionQuantiteTransactionParDate, this.maBDD.connexion))
                {
                    var quantiteTransactionParDate = commandSelectionQuantiteTransactionParDate.ExecuteReader();
                    while (quantiteTransactionParDate.Read())
                    {
                        listeQuantiteTransactionsParDateInvest.Add((quantiteTransactionParDate.GetDateTime(0), quantiteTransactionParDate.GetDouble(1)));
                    }
                }
            }
            catch (SQLiteException ex)
            {
                Console.Error.WriteLine($"Erreur selection quantite transactions SQLite : {ex.Message}");
            }
            return listeQuantiteTransactionsParDateInvest;
        }

        public double getQuantiteTotaleDetenuDunActif(string nomActif)
        {
            double quantiteTotale = 0;
            try
            {
                string selectionQuantiteTotalActif = "SELECT SUM(quantite) FROM [transaction] WHERE actif=@actif GROUP BY actif;";
                using (var commandSelectionQuantiteTotalActif = new SQLiteCommand(selectionQuantiteTotalActif, this.maBDD.connexion))
                {
                    commandSelectionQuantiteTotalActif.Parameters.AddWithValue("@actif", nomActif);
                    quantiteTotale = (double)commandSelectionQuantiteTotalActif.ExecuteScalar();

                }
            }
            catch (SQLiteException ex)
            {
                Console.Error.WriteLine($"Erreur selection quantite totale d'un actif SQLite : {ex.Message}");
            }
            return quantiteTotale;
        }

        public List<(string,string)> getListePaireNomSymboleActif()
        {
            List<(string, string)> listeNomsEtSymboleActif = new List<(string, string)>();
            try
            {
                string selectionNomActifs = "SELECT DISTINCT Actif.nom, Actif.symbole FROM [Transaction] JOIN Actif ON Actif.nom = [Transaction].actif";
                using (var commandSelectionNomActifs = new SQLiteCommand(selectionNomActifs, this.maBDD.connexion))
                {
                    var nomEtSymboleActifs = commandSelectionNomActifs.ExecuteReader();
                    while (nomEtSymboleActifs.Read())
                    {
                        listeNomsEtSymboleActif.Add((nomEtSymboleActifs.GetString(0), nomEtSymboleActifs.GetString(1)));
                    }
                }
            }
            catch (SQLiteException ex)
            {
                Console.Error.WriteLine($"Erreur selection Paire Nom/Symbole transactions SQLite : {ex.Message}");
            }
            return listeNomsEtSymboleActif;
        }

        public List<string> getListeSymboleActif()
        {
            List<string> listeNomsEtSymboleActif = new List<string>();
            try
            {
                string selectionNomActifs = "SELECT DISTINCT Actif.symbole FROM [Transaction] JOIN Actif ON Actif.nom = [Transaction].actif";
                using (var commandSelectionNomActifs = new SQLiteCommand(selectionNomActifs, this.maBDD.connexion))
                {
                    var nomEtSymboleActifs = commandSelectionNomActifs.ExecuteReader();
                    while (nomEtSymboleActifs.Read())
                    {
                        listeNomsEtSymboleActif.Add(nomEtSymboleActifs.GetString(0));
                    }
                }
            }
            catch (SQLiteException ex)
            {
                Console.Error.WriteLine($"Erreur selection symbole transactions SQLite : {ex.Message}");
            }
            return listeNomsEtSymboleActif;
        }

        public List<(string,double)> getListePaireQuantiteTotaleInvestitParActif()
        {
            List<(string,double)> listeActifsQuantiteTotaleInvestit = new List<(string,double)>();
            try
            {
                string selectionActifsQuantiteTotaleInvestit = "SELECT actif,SUM(quantite) FROM [Transaction] GROUP BY actif";
                using (var commandSelectionActifsQuantiteTotaleInvestit = new SQLiteCommand(selectionActifsQuantiteTotaleInvestit, this.maBDD.connexion))
                {
                    var actifQuantiteTotaleInvestit = commandSelectionActifsQuantiteTotaleInvestit.ExecuteReader();
                    while (actifQuantiteTotaleInvestit.Read())
                    {
                        listeActifsQuantiteTotaleInvestit.Add((actifQuantiteTotaleInvestit.GetString(0), actifQuantiteTotaleInvestit.GetDouble(1)));
                    }
                }
            }
            catch (SQLiteException ex)
            {
                Console.Error.WriteLine($"Erreur selection actif et quantiteTotale(somme des quantite par actif) transactions SQLite : {ex.Message}");
            }
            return listeActifsQuantiteTotaleInvestit;
        }

        public List<(string,long)> getListePaireNombreTransactionParTypeActif()
        {
            List<(string, long)> listePaireNombreTransactionParTypeActif = new List<(string, long)>();
            try
            {
                string selectionNombreTransactionParTypeActif = "SELECT Actif.type, COUNT([Transaction].id) FROM [Transaction] JOIN Actif ON Actif.nom = [Transaction].actif GROUP BY Actif.type;";
                using (var commandSelectionNombreTransactionParTypeActif = new SQLiteCommand(selectionNombreTransactionParTypeActif, this.maBDD.connexion))
                {
                    var actifQuantiteTotaleInvestit = commandSelectionNombreTransactionParTypeActif.ExecuteReader();
                    while (actifQuantiteTotaleInvestit.Read())
                    {
                        listePaireNombreTransactionParTypeActif.Add((actifQuantiteTotaleInvestit.GetString(0), actifQuantiteTotaleInvestit.GetInt64(1)));
                    }
                }
            }
            catch (SQLiteException ex)
            {
                Console.Error.WriteLine($"Erreur selection actif et quantiteTotale(somme des quantite par actif) transactions SQLite : {ex.Message}");
            }
            return listePaireNombreTransactionParTypeActif;
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

        public void ajouterInvestissementTotalParDate(DateTime date, double sommeQuantite)
        {
            try
            {
                double quantiteDernierInvest =  0;
                string selectionQuantiteDernierInvest = "SELECT quantite FROM InvestissementTotalParDate ORDER BY date DESC LIMIT 1;"; //entre crochets car Transaction est un mot réservé en sql
                using (var commandSelectionQuantiteDernierInvest = new SQLiteCommand(selectionQuantiteDernierInvest, this.maBDD.connexion))
                {
                    quantiteDernierInvest = (double)commandSelectionQuantiteDernierInvest.ExecuteScalar();
                }

                string query = "INSERT INTO InvestissementTotalParDate (date,quantite) VALUES (@date,@sommeQuantite);"; //entre crochets car Transaction est un mot réservé en sql
                using (var command = new SQLiteCommand(query, this.maBDD.connexion))
                {
                    double totalInvest = quantiteDernierInvest + sommeQuantite;
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
