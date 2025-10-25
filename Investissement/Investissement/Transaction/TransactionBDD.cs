using System.Collections.Generic;
using System.Data.SQLite;
using System;


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
        public List<(DateTime,double)> getListeQuantiteTotaleInvestitEURParDate()
        {
            List<(DateTime, double)> listeQuantiteTransactionsParDateInvest = new List<(DateTime, double)>();
            try
            {
                string selectionQuantiteTransactionParDate = "SELECT date, quantiteEUR FROM InvestissementTotalParDate ORDER BY date;";
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

        public List<(string actif,string symbole,string type,double quantiteTotale)> getListeQuantiteTotaleInvestitParActif()
        {
            List<(string,string,string,double)> listeActifsQuantiteTotaleInvestit = new List<(string,string,string,double)>();
            try
            {
                string selectionActifsQuantiteTotaleInvestit = "SELECT actif, symbole, type,SUM(quantite) FROM [Transaction] JOIN Actif ON Actif.nom = [Transaction].actif GROUP BY actif";
                using (var commandSelectionActifsQuantiteTotaleInvestit = new SQLiteCommand(selectionActifsQuantiteTotaleInvestit, this.maBDD.connexion))
                {
                    var actifQuantiteTotaleInvestit = commandSelectionActifsQuantiteTotaleInvestit.ExecuteReader();
                    while (actifQuantiteTotaleInvestit.Read())
                    {
                        listeActifsQuantiteTotaleInvestit.Add((actifQuantiteTotaleInvestit.GetString(0), actifQuantiteTotaleInvestit.GetString(1), actifQuantiteTotaleInvestit.GetString(2), actifQuantiteTotaleInvestit.GetDouble(3)));
                    }
                }
            }
            catch (SQLiteException ex)
            {
                Console.Error.WriteLine($"Erreur selection actif et quantiteTotale(somme des quantite par actif) transactions SQLite : {ex.Message}");
            }
            return listeActifsQuantiteTotaleInvestit;
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
        public void ajouterInvestissementTotalParDate(DateTime date, double quantiteTotaleEnEUR)
        {
            try
            {
                double quantiteTotaleEURDernierInvest =  0;
                string selectionQuantiteDernierInvest = "SELECT quantiteEUR FROM InvestissementTotalParDate ORDER BY date DESC LIMIT 1;";
                using (var commandSelectionQuantiteDernierInvest = new SQLiteCommand(selectionQuantiteDernierInvest, this.maBDD.connexion))
                {
                    quantiteTotaleEURDernierInvest = (double)commandSelectionQuantiteDernierInvest.ExecuteScalar();
                }

                string query = "INSERT INTO InvestissementTotalParDate (date,quantiteEUR) VALUES (@date,@sommeQuantite);"; 
                using (var command = new SQLiteCommand(query, this.maBDD.connexion))
                {
                    double totalInvest = quantiteTotaleEURDernierInvest + quantiteTotaleEnEUR;
                    command.Parameters.AddWithValue("@date", date.ToString("yyyy-MM-dd"));
                    command.Parameters.AddWithValue("@sommeQuantite", totalInvest);

                    command.ExecuteNonQuery();
                }

                string queryUpdate= "UPDATE InvestissementTotalParDate SET quantite = quantiteEUR + @ajoutQuantite WHERE date > @dateLimit;";

                using (var commandUpdate = new SQLiteCommand(queryUpdate, this.maBDD.connexion))
                {
                    // @ajoutQuantite est la valeur que vous venez d'ajouter à l'historique
                    commandUpdate.Parameters.AddWithValue("@ajoutQuantite", quantiteTotaleEnEUR);
                    commandUpdate.Parameters.AddWithValue("@dateLimit", date);

                    commandUpdate.ExecuteNonQuery();
                }
            }
            catch (SQLiteException ex)
            {
                Console.Error.WriteLine($"Erreur insertion investissement total par date SQLite : {ex.Message}");
            }
        }
    }
}
