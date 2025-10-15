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
            DataTable modeleInvest = new DataTable();
            try
            {
                var query = "SELECT nom FROM ModeleInvest;";
                using (var command = new SQLiteCommand(query, this.maBDD.connexion))
                {
                    var noms = command.ExecuteReader();
                    modeleInvest.Load(noms);
                }
            }
            catch (SQLiteException ex)
            {
                MessageBox.Show(ex.Message, "Erreur selection modele bdd");
            }
            return modeleInvest;
        }

        public long? getIdModeleInvest(string nom)
        {
            long? idModele = null;
            try
            {
                var query = "SELECT id FROM ModeleInvest WHERE nom=@nom;";
                using (var command = new SQLiteCommand(query, this.maBDD.connexion))
                {
                    command.Parameters.AddWithValue("@nom", nom);
                    idModele = Convert.ToInt64(command.ExecuteScalar());
                }
            }
            catch (SQLiteException ex)
            {
                MessageBox.Show(ex.Message, "Erreur selection modele bdd");
            }
            return idModele;
        }

        public string getDescriptionModeleInvest(string nom)
        {
            string description = null;
            try
            {
                var query = "SELECT description FROM ModeleInvest WHERE nom=@nom;";
                using (var command = new SQLiteCommand(query, this.maBDD.connexion))
                {
                    command.Parameters.AddWithValue("@nom", nom);
                    description = command.ExecuteScalar().ToString();
                }
            }
            catch (SQLiteException ex)
            {
                MessageBox.Show(ex.Message, "Erreur selection modele bdd");
            }
            return description;

        }

        public (long?,string) getIdEtDescriptionModeleInvest(string nom)
        {
            try
            {
                var query = "SELECT id,description FROM ModeleInvest WHERE nom=@nom;";
                using (var command = new SQLiteCommand(query, this.maBDD.connexion))
                {
                    command.Parameters.AddWithValue("@nom", nom);
                    var modele = command.ExecuteReader();
                    modele.Read();
                    return (modele.GetInt64(0), modele.GetString(1));
                }
            }
            catch (SQLiteException ex)
            {
                MessageBox.Show(ex.Message, "Erreur selection modele bdd");
                return (null, null);
            }
        }


        /**************
         ***METHODES***
         **************/
        public bool ajouterModele(ModeleInvest modeleInvest)
        {   
            if (modeleInvest.nom == "")
            {
                MessageBox.Show("chosissez un nom", "Erreur nom");
                return false;
            }
            if (modeleInvest.description == "")
            {
                MessageBox.Show("decrivez votre modèle", "Erreur desccription");
                return false;
            }
            if (!CommunBDD.existe(this.maBDD, "ModeleInvest", "nom", modeleInvest.nom))
            {
                MessageBox.Show("l'actif existe déjà", "Erreur actif");
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
                if (CommunBDD.existe(this.maBDD, "TransactionsModele", "idModele", $"(SELECT id FROM ModeleInvest WHERE nom = {modeleInvest})"))
                {
                    MessageBox.Show("impossible de supprimer ce modele car des transactions en dépendent", "Erreur suppresion modele bdd");
                    return false;
                }
                else
                {
                    var suppressionModele = "DELETE FROM ModeleInvest WHERE nom=@nom;";
                    using (var commandeSuppressionModele = new SQLiteCommand(suppressionModele, this.maBDD.connexion))
                    {
                        commandeSuppressionModele.Parameters.AddWithValue("@nom", modeleInvest);
                        commandeSuppressionModele.ExecuteNonQuery();
                    }
                    return true;
                }
            }
            catch(SQLiteException ex)
            {
                MessageBox.Show(ex.Message, "Erreur suppresion modele bdd");
                return false;
            }
        }

        public bool majNomDescription(string nomModele, string nom, string description)
        {
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
                MessageBox.Show(ex.Message, "Erreur mise à jour elmt modele bdd");
                return false;
            }
        }
    }
}
