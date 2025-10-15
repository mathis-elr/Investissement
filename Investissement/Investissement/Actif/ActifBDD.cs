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
            var query = "SELECT nom FROM Actif;";
            using (var command = new SQLiteCommand(query, this.maBDD.connexion))
            {
                var noms = command.ExecuteReader();

                DataTable actifsDataTable = new DataTable();
                actifsDataTable.Load(noms);

                return actifsDataTable;
            }
        }

        /**************
         ***METHODES***
         **************/

        public bool ajouterActif(Actif actif)
        {
            if (!this.existe(actif))
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
            try {

                //tester si l'actif n'existe dans aucun modele
                var selectionNbActifsDansModele = "SELECT COUNT(1) FROM TransactionsModele WHERE actif=@nom;";
                using (var commandsSlectionNbActifsDansModele = new SQLiteCommand(selectionNbActifsDansModele, this.maBDD.connexion))
                {
                    commandsSlectionNbActifsDansModele.Parameters.AddWithValue("@nom", nom);
                    long existe = Convert.ToInt64(commandsSlectionNbActifsDansModele.ExecuteScalar());
                    if (existe > 0)
                    {
                        MessageBox.Show("impossible de supprimer cette actif car il est utilisé dans au moins un modele", "Erreur suppresion actif bdd");
                        return false;
                    }
                }

                string suppresionActif = "DELETE FROM Actif WHERE nom=@nom;";
                using (var commandInsertionActif = new SQLiteCommand(suppresionActif, this.maBDD.connexion))
                {
                    commandInsertionActif.Parameters.AddWithValue("@nom", nom);
                    commandInsertionActif.ExecuteNonQuery();
                }
            }
            catch (SQLiteException ex)
            {
                MessageBox.Show(ex.Message, "Erreur suppresion actif bdd");
                return false;
            }

            return true;
        }


        public List<string> getListeActifs()
        {
            var actifs = new List<string>();
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
            return actifs;
        }

        public bool existe(Actif actif)
        {
            /*informer l'utilisateur de son erreur précise*/
            var selectionNoms = "SELECT COUNT(1) FROM Actif WHERE nom=@nom;"; //retourne 0 si il n'existe pas sinon 1
            using (var commandSelectionNoms = new SQLiteCommand(selectionNoms, this.maBDD.connexion))       
            {
                commandSelectionNoms.Parameters.AddWithValue("@nom", actif.nom);
                long existe = Convert.ToInt64(commandSelectionNoms.ExecuteScalar());
                if (existe > 0)
                {
                    MessageBox.Show("un actif du même nom existe déjà", "Erreur actif");
                    return true;
                }
            }
            return false;
        }
    }
}
