using System.Collections.Generic;
using System.Data.SQLite;
using System.Data;
using System;


namespace Investissement
{
    public class ActifBDD
    {
        /*ATTRIBUT*/
        public BDD maBDD;


        /*CONSTRUCTEUR*/
        public ActifBDD(BDD bdd)
        {
            this.maBDD = bdd;
        }


        /*ENCAPSULATION*/
        public DataTable getActifsDataTable()
        {
            DataTable actifsDataTable = new DataTable();
            try
            {
                var query = "SELECT nom FROM Actif;";
                using (var command = new SQLiteCommand(query, this.maBDD.connexion))
                {
                    var noms = command.ExecuteReader();
                    actifsDataTable.Load(noms);
                }
            }
            catch (SQLiteException ex)
            {
                Console.Error.WriteLine($"Erreur selection DataTable actifs SQLite : {ex.Message}");
            }
            return actifsDataTable;
        }

        public List<string> getListeActifs()
        {
            var actifs = new List<string>();
            try
            {
                string query = "SELECT nom FROM Actif ORDER BY type;";
                using (var command = new SQLiteCommand(query, this.maBDD.connexion))
                {
                    using (var lecteurActifs = command.ExecuteReader())
                    {
                        while (lecteurActifs.Read())
                        {
                            actifs.Add(lecteurActifs.GetString(0));
                        }
                    }
                }
            }
            catch (SQLiteException ex)
            {
                Console.Error.WriteLine($"Erreur selection liste actifs SQLite : {ex.Message}");
            }
            return actifs;
        }


        /*METHODES*/
        public void ajouterActif(Actif actif)
        {
            try
            {
                string insertionActif = "INSERT INTO Actif VALUES(@nom,@type,@ISIN,@risque);";
                using (var commandInsertionActif = new SQLiteCommand(insertionActif, this.maBDD.connexion))
                {
                    commandInsertionActif.Parameters.AddWithValue("@nom", actif.nom);
                    commandInsertionActif.Parameters.AddWithValue("@type", actif.type);
                    commandInsertionActif.Parameters.AddWithValue("@ISIN", actif.isin);
                    commandInsertionActif.Parameters.AddWithValue("@risque", actif.risque);

                    commandInsertionActif.ExecuteNonQuery();
                }
            }
            catch (SQLiteException ex)
            {
                Console.Error.WriteLine($"Erreur insertion actif SQLite : {ex.Message}");
                throw new Exception("une erreur est survenue lors de l'insertion d'un actif");
            }
        }

        public void modifActif()
        {
            //a faire
        }


        public void supprActif(string nom)
        {
            try
            {

                string suppresionActif = "DELETE FROM Actif WHERE nom=@nom;";
                using (var commandInsertionActif = new SQLiteCommand(suppresionActif, this.maBDD.connexion))
                {
                    commandInsertionActif.Parameters.AddWithValue("@nom", nom);
                    commandInsertionActif.ExecuteNonQuery();
                }
            }
            catch (SQLiteException ex)
            {
                Console.Error.WriteLine($"Erreur suppression actif SQLite : {ex.Message}");
                throw new Exception("une erreur est survenue lors de la suppression de l'actif");
            }
        }
    }
}
