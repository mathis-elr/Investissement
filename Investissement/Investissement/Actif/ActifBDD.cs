using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;

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
                    return actifsDataTable;
                }
            }
            catch (SQLiteException ex)
            {
                MessageBox.Show(ex.Message, "Erreur selection actif bdd");
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
                MessageBox.Show(ex.Message, "Erreur selection actif bdd");
            }
            return actifs;
        }


        /**************
         ***METHODES***
         **************/
        public bool ajouterActif(Actif actif)
        {
            if (!CommunBDD.existe(this.maBDD,"Actif","nom",actif.nom))
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
                    MessageBox.Show(ex.Message, "Erreur insertion actif bdd");
                    return false;
                }

                return true;
            }
            return false;
        }

        public bool modifActif()
        {
            //a faire
            return false;
        }


        public bool supprActif(string nom)
        {
            try
            {
                if (!CommunBDD.existe(this.maBDD,"Actif","nom", nom))
                {

                    string suppresionActif = "DELETE FROM Actif WHERE nom=@nom;";
                    using (var commandInsertionActif = new SQLiteCommand(suppresionActif, this.maBDD.connexion))
                    {
                        commandInsertionActif.Parameters.AddWithValue("@nom", nom);
                        commandInsertionActif.ExecuteNonQuery();
                    }
                    return true;
                }
            }
            catch (SQLiteException ex)
            {
                MessageBox.Show(ex.Message, "Erreur suppresion actif bdd");
            }
            return false;
        }
    }
}
