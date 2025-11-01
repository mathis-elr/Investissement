using System.Collections.Generic;
using System.Data.SQLite;
using System;


namespace Investissement
{
    public class InvestissementTotalBDD
    {
        /*ATTRIBUTS*/
        public BDD maBDD;


        /*CONSTRUCTEUR*/
        public InvestissementTotalBDD(BDD bdd)
        {
            this.maBDD = bdd;
        }


        /*encapsulation*/
        public Dictionary<DateTime, double> getQuantiteInvestitParDate()
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
        public DateTime? getDateDernierInvest()
        {
            try
            {
                string selectionDateDernierInvest = "SELECT date FROM InvestissementTotal ORDER BY date DESC LIMIT 1;";
                using (var commandSelectionDateDernierInvest = new SQLiteCommand(selectionDateDernierInvest, this.maBDD.connexion))
                {
                    var res = commandSelectionDateDernierInvest.ExecuteScalar();
                    if (res == null || res == DBNull.Value)
                    {
                        return null; 
                    }
                    DateTime dateDernierInvest = Convert.ToDateTime(res);
                    return dateDernierInvest;
                }
            }
            catch (SQLiteException ex)
            {
                Console.Error.WriteLine($"Erreur selection quantite totale d'un actif SQLite : {ex.Message}");
                throw new Exception("erreur de traitement des donnees");
            }
        }
        public double getQuantiteTotalePrecedente(DateTime date)
        {
            try
            {
                string selectionQuantiteDernierInvest = "SELECT quantiteEUR FROM InvestissementTotal WHERE date < @date ORDER BY date DESC LIMIT 1;";
                using (var commandSelectionQuantiteDernierInvest = new SQLiteCommand(selectionQuantiteDernierInvest, this.maBDD.connexion))
                {
                    commandSelectionQuantiteDernierInvest.Parameters.AddWithValue("@date", date.ToString("yyyy-MM-dd"));
                    var res = commandSelectionQuantiteDernierInvest.ExecuteScalar();
                    if (res == null || res == DBNull.Value)
                    {
                        return Convert.ToInt64(0);
                    }
                    return Convert.ToInt64(res);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message, "erreur recuperation quantite totale investit");
                throw new Exception("erreur de traitement des donnees");
            }
        }


        /*methodes*/
        public void ajouterInvestissementTotal(DateTime date, double quantiteInvestit)
        {
            try
            {
                string query = "INSERT INTO InvestissementTotal (date,quantiteEUR) VALUES (@date,@sommeQuantiteTotale);";
                using (var command = new SQLiteCommand(query, this.maBDD.connexion))
                {
                    double sommeQuantiteTotal = this.getQuantiteTotalePrecedente(date) + quantiteInvestit;
                    command.Parameters.AddWithValue("@date", date.ToString("yyyy-MM-dd"));
                    command.Parameters.AddWithValue("@sommeQuantiteTotale", sommeQuantiteTotal);
                    command.ExecuteNonQuery();
                }
            }
            catch (SQLiteException ex)
            {
                Console.Error.WriteLine($"Erreur insertion investissement total par date SQLite : {ex.Message}");
                throw new Exception("erreur de traitement des donnees");
            }
        }
        public void modifierInvestissementTotal(DateTime date, double quantiteInvestit)
        {
            try
            {
                string queryUpdate = "UPDATE InvestissementTotal SET quantiteEUR = @sommeQuantiteInvestit WHERE date=@date;";

                using (var commandUpdate = new SQLiteCommand(queryUpdate, this.maBDD.connexion))
                {
                    double sommeQuantite = this.getQuantiteTotalePrecedente(date) + quantiteInvestit;
                    commandUpdate.Parameters.AddWithValue("@sommeQuantiteInvestit", sommeQuantite);
                    commandUpdate.Parameters.AddWithValue("@date", date.ToString("yyyy-MM-dd"));
                    commandUpdate.ExecuteNonQuery();
                }
            }
            catch (SQLiteException ex)
            {
                Console.WriteLine($"erreur modification Investissement du jour {ex.Message}");
                throw new Exception("erreur de traitement des donnees");
            }
        }
        public void modifierInvestissementTotalApresDate(DateTime date, double quantiteInvestit)
        {
            try
            {
                string queryUpdate = "UPDATE InvestissementTotal SET quantiteEUR = quantiteEUR + @ajoutQuantite WHERE date > @dateInvest;";

                using (var commandUpdate = new SQLiteCommand(queryUpdate, this.maBDD.connexion))
                {
                    commandUpdate.Parameters.AddWithValue("@ajoutQuantite", quantiteInvestit);
                    commandUpdate.Parameters.AddWithValue("@dateInvest", date.ToString("yyyy-MM-dd"));
                    commandUpdate.ExecuteNonQuery();
                }
            }
            catch (SQLiteException ex)
            {
                Console.Error.WriteLine($"Erreur modif investissements total après une certaine date  SQLite : {ex.Message}");
                throw new Exception("erreur de traitement des donnees");
            }
        }
    }
}
