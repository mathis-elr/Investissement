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
        public Dictionary<DateTime,double> getQuantiteInvestitParDate()
        {
            Dictionary<DateTime, double> dictionnaireQuantiteInvestitParDate = new Dictionary<DateTime, double>();
            try
            {
                string selectionQuantiteInvestitParDate = "SELECT date, quantiteEUR FROM InvestissementTotal ORDER BY date;";
                using (var commandSelectionQuantiteInvestitParDate = new SQLiteCommand(selectionQuantiteInvestitParDate, this.maBDD.connexion))
                {
                    var quantiteInvestitParDate = commandSelectionQuantiteInvestitParDate.ExecuteReader();
                    while (quantiteInvestitParDate.Read())
                    {
                        dictionnaireQuantiteInvestitParDate[quantiteInvestitParDate.GetDateTime(0)] = quantiteInvestitParDate.GetDouble(1);
                    }
                }
            }
            catch (SQLiteException ex)
            {
                Console.Error.WriteLine($"Erreur selection quantite transactions SQLite : {ex.Message}");
            }
            return dictionnaireQuantiteInvestitParDate;
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
        public Dictionary<string,string> getSymboleParActif()
        {
            Dictionary<string, string> dictionnaireSymboleParActif = new Dictionary<string, string>();
            try
            {
                string selectionSymboleParAcif = "SELECT DISTINCT Actif.nom, Actif.symbole FROM [Transaction] JOIN Actif ON Actif.nom = [Transaction].actif";
                using (var commandSelectionSymboleParActif = new SQLiteCommand(selectionSymboleParAcif, this.maBDD.connexion))
                {
                    var symboleParActif = commandSelectionSymboleParActif.ExecuteReader();
                    while (symboleParActif.Read())
                    {
                        dictionnaireSymboleParActif[symboleParActif.GetString(0)] = symboleParActif.GetString(1);
                    }
                }
            }
            catch (SQLiteException ex)
            {
                Console.Error.WriteLine($"Erreur selection Paire Nom/Symbole transactions SQLite : {ex.Message}");
            }
            return dictionnaireSymboleParActif;
        }
        public List<string> getSymbolesActif()
        {
            List<string> listeSymboleActif = new List<string>();
            try
            {
                string selectionNomActifs = "SELECT DISTINCT Actif.symbole FROM [Transaction] JOIN Actif ON Actif.nom = [Transaction].actif";
                using (var commandSelectionNomActifs = new SQLiteCommand(selectionNomActifs, this.maBDD.connexion))
                {
                    var nomEtSymboleActifs = commandSelectionNomActifs.ExecuteReader();
                    while (nomEtSymboleActifs.Read())
                    {
                        listeSymboleActif.Add(nomEtSymboleActifs.GetString(0));
                    }
                }
            }
            catch (SQLiteException ex)
            {
                Console.Error.WriteLine($"Erreur selection symbole transactions SQLite : {ex.Message}");
            }
            return listeSymboleActif;
        }
        public List<SyntheseDetentionActif> getSynthesesDetentionActifs()
        {
            List<SyntheseDetentionActif> listeSyntheseDetentionActif = new List<SyntheseDetentionActif>();
            try
            {
                string selectionSyntheseDetentionActif = "SELECT actif, symbole, type,SUM(quantite) FROM [Transaction] JOIN Actif ON Actif.nom = [Transaction].actif GROUP BY actif";
                using (var commandSelectionSyntheseDetentionActif = new SQLiteCommand(selectionSyntheseDetentionActif, this.maBDD.connexion))
                {
                    var syntheseParActif = commandSelectionSyntheseDetentionActif.ExecuteReader();
                    while (syntheseParActif.Read())
                    {
                        SyntheseDetentionActif syntheseDetentionActif = new SyntheseDetentionActif(syntheseParActif.GetString(0), 
                                                                                                   syntheseParActif.GetString(1), 
                                                                                                   syntheseParActif.GetString(2),
                                                                                                   syntheseParActif.GetDouble(3));
                        listeSyntheseDetentionActif.Add(syntheseDetentionActif);
                    }
                }
            }
            catch (SQLiteException ex)
            {
                Console.Error.WriteLine($"Erreur selection actif et quantiteTotale(somme des quantite par actif) transactions SQLite : {ex.Message}");
            }
            return listeSyntheseDetentionActif;
        }
        public Dictionary<DateTime, double> getMoyenneValeurPatrimoineParJour()
        {
            Dictionary<DateTime, double> dictionnaireMoyenneValeurPatrimoineParJour = new Dictionary<DateTime, double>();
            try
            {
                string recupererMoyenneValeurPatrimoineParDate = "SELECT DATE(date) AS date_sans_heure,AVG(valeurEUR) FROM ValeurPatrimoine GROUP BY date_sans_heure;";
                using (var commandRecupererMoyenneValeurPatrimoineParDate = new SQLiteCommand(recupererMoyenneValeurPatrimoineParDate, this.maBDD.connexion))
                {
                    var moyenneValeurPatrimoineParDate = commandRecupererMoyenneValeurPatrimoineParDate.ExecuteReader();
                    while (moyenneValeurPatrimoineParDate.Read())
                    {
                        dictionnaireMoyenneValeurPatrimoineParJour[moyenneValeurPatrimoineParDate.GetDateTime(0)] = moyenneValeurPatrimoineParDate.GetDouble(1);
                    }
                }
            }
            catch (SQLiteException ex)
            {
                Console.Error.WriteLine($"Erreur recuperation Moyenne Valeur Patrimoine par Date SQLite : {ex.Message}");
            }
            return dictionnaireMoyenneValeurPatrimoineParJour;
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
                string selectionQuantiteDernierInvest = "SELECT quantiteEUR FROM InvestissementTotal ORDER BY date DESC LIMIT 1;";
                using (var commandSelectionQuantiteDernierInvest = new SQLiteCommand(selectionQuantiteDernierInvest, this.maBDD.connexion))
                {
                    quantiteTotaleEURDernierInvest = (double)commandSelectionQuantiteDernierInvest.ExecuteScalar();
                }

                string query = "INSERT INTO InvestissementTotal (date,quantiteEUR) VALUES (@date,@sommeQuantite);"; 
                using (var command = new SQLiteCommand(query, this.maBDD.connexion))
                {
                    double totalInvest = quantiteTotaleEURDernierInvest + quantiteTotaleEnEUR;
                    command.Parameters.AddWithValue("@date", date.ToString("yyyy-MM-dd"));
                    command.Parameters.AddWithValue("@sommeQuantite", totalInvest);

                    command.ExecuteNonQuery();
                }

                string queryUpdate= "UPDATE InvestissementTotal SET quantite = quantiteEUR + @ajoutQuantite WHERE date > @dateLimit;";

                using (var commandUpdate = new SQLiteCommand(queryUpdate, this.maBDD.connexion))
                {
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
        public void enregistrerValeurPatrimoineActuel(double valeurEUR)
        {
            try
            {
                string insererValeurPatrimoine = "INSERT INTO ValeurPatrimoine (date,valeurEUR) VALUES (@date,@valeurEUR);";
                using (var commandInsererValeurPatrimoine = new SQLiteCommand(insererValeurPatrimoine, this.maBDD.connexion))
                {
                    commandInsererValeurPatrimoine.Parameters.AddWithValue("@date", DateTime.Now);
                    commandInsererValeurPatrimoine.Parameters.AddWithValue("@valeurEUR", valeurEUR);
                    commandInsererValeurPatrimoine.ExecuteNonQuery();
                }
            }
            catch (SQLiteException ex)
            {
                Console.Error.WriteLine($"Erreur insertion ValeurPatrimoine SQLite : {ex.Message}");
                throw new Exception("une erreur est survenue lors de l'insertion d'une transaction");
            }
        }
    }
}
