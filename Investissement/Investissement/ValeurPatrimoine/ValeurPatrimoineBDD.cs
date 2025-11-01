using System.Collections.Generic;
using System.Data.SQLite;
using System;


namespace Investissement
{
    public class ValeurPatrimoineBDD
    {
        /*ATTRIBUTS*/
        public BDD maBDD;


        /*CONSTRUCTEUR*/
        public ValeurPatrimoineBDD(BDD bdd)
        {
            this.maBDD = bdd;
        }

        /*encapsulation*/
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

        /*methodes*/
        public void enregistrerValeurPatrimoineActuel(double valeurEUR, DateTime date)
        {
            try
            {
                string insererValeurPatrimoine = "INSERT INTO ValeurPatrimoine (date,valeurEUR) VALUES (@date,@valeurEUR);";
                using (var commandInsererValeurPatrimoine = new SQLiteCommand(insererValeurPatrimoine, this.maBDD.connexion))
                {
                    commandInsererValeurPatrimoine.Parameters.AddWithValue("@date", date);
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
