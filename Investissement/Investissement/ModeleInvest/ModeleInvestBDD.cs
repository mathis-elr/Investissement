using System;
using System.Data;
using System.Data.SQLite;
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
            var query = "SELECT nom FROM ModeleInvest;";
            using (var command = new SQLiteCommand(query, this.maBDD.connexion))
            {
                var noms = command.ExecuteReader();

                DataTable modeleInvest = new DataTable();
                modeleInvest.Load(noms);
                return modeleInvest;
            }
        }

        public long getIdModeleInvest(string nom)
        {
            var query = "SELECT id FROM ModeleInvest WHERE nom=@nom;";
            using (var command = new SQLiteCommand(query, this.maBDD.connexion))
            {
                command.Parameters.AddWithValue("@nom", nom);
                return Convert.ToInt64(command.ExecuteScalar());
            }
        }

        public string getDescriptionModeleInvest(string nom)
        {
            var query = "SELECT description FROM ModeleInvest WHERE nom=@nom;";
            using (var command = new SQLiteCommand(query, this.maBDD.connexion))
            {
                command.Parameters.AddWithValue("@nom", nom);
                return command.ExecuteScalar().ToString();
            }
        }

        public (long,string) getIdEtDescriptionModeleInvest(string nom)
        {
            var query = "SELECT id,description FROM ModeleInvest WHERE nom=@nom;";
            using (var command = new SQLiteCommand(query, this.maBDD.connexion))
            {
                command.Parameters.AddWithValue("@nom", nom);
                var modele = command.ExecuteReader();
                modele.Read();
                return (modele.GetInt64(0),modele.GetString(1));
            }
        }


        /**************
         ***METHODES***
         **************/
        public bool ajouterModele(ModeleInvest modeleInvest)
        {
            /*informer l'utilisateur de son erreur précise*/
            var query = "SELECT nom FROM ModeleInvest;";
            using (var command = new SQLiteCommand(query, this.maBDD.connexion))
            {
                var noms = command.ExecuteReader();

                while (noms.Read())
                {
                    if (noms.GetString(0) == modeleInvest.nom)
                    {
                        MessageBox.Show("un modele du même nom existe déjà", "Erreur modele");
                        return false;
                    }
                }
            }
                
            if (modeleInvest.nom == "")
            {
                MessageBox.Show("chosissez un nom", "Erreur nom");
                return false;
            }
            else if (modeleInvest.description == "")
            {
                MessageBox.Show("decrivez votre modèle", "Erreur desccription");
                return false;
            }
            else
            {
                try
                {
                    string insertionModele = "INSERT INTO ModeleInvest(nom,description) VALUES(@nom,@description);";
                    using (var commandInsertionModele = new SQLiteCommand(insertionModele, this.maBDD.connexion))
                    {
                        commandInsertionModele.Parameters.AddWithValue("@nom", modeleInvest.nom);
                        commandInsertionModele.Parameters.AddWithValue("@description", modeleInvest.description);
                        commandInsertionModele.ExecuteNonQuery();

                        modeleInvest.id = (int)this.maBDD.connexion.LastInsertRowId;
                        return true;
                    }
                }
                catch (SQLiteException ex)
                {
                    MessageBox.Show(ex.Message, "Erreur insertion modele bdd");
                    return false;
                }
            }
        }

        public bool supprModele(string modeleInvest)
        {
            try
            {
                var selectionNbTransactionSurModele = "SELECT COUNT(1) FROM TransactionsModele WHERE idModele=(SELECT id FROM ModeleInvest WHERE nom=@nom);";
                using (var commandSelectionNbTransactionSurModele = new SQLiteCommand(selectionNbTransactionSurModele, this.maBDD.connexion))
                {
                    commandSelectionNbTransactionSurModele.Parameters.AddWithValue("@nom", modeleInvest);
                    long existe = Convert.ToInt64(commandSelectionNbTransactionSurModele.ExecuteScalar());
                    if(existe > 0)
                    {
                        MessageBox.Show("impossible de supprimer ce modele car des transactions en dépendent", "Erreur suppresion modele bdd");
                        return false;
                    }
                }

                var suppressionModele = "DELETE FROM ModeleInvest WHERE nom=@nom;";
                using (var commandeSuppressionModele = new SQLiteCommand(suppressionModele, this.maBDD.connexion))
                {
                    commandeSuppressionModele.Parameters.AddWithValue("@nom", modeleInvest);
                    commandeSuppressionModele.ExecuteNonQuery();
                }
                return true;
            }
            catch(SQLiteException ex)
            {
                MessageBox.Show(ex.Message, "Erreur suppresion modele bdd");
                return false;
            }
        }

        public bool majNomDescription(string nomModele, string nom, string description)
        {
            //POV CA MARCHE PAS
            try
            {
                string insertionModele = "UPDATE ModeleInvest SET nom=@nom, description=@description WHERE nom=@nomModele;";
                using (var commandInsertionModele = new SQLiteCommand(insertionModele, this.maBDD.connexion))
                {
                    commandInsertionModele.Parameters.AddWithValue("@nom", nom);
                    commandInsertionModele.Parameters.AddWithValue("@description", description);
                    commandInsertionModele.Parameters.AddWithValue("@nomModele", nomModele);
                    commandInsertionModele.ExecuteNonQuery();

                    return true;
                }
            }
            catch (SQLiteException ex)
            {
                MessageBox.Show(ex.Message, "Erreur insertion modele bdd");
                return false;
            }
        }
    }
}
