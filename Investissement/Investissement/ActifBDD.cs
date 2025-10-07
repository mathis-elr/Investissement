using DocumentFormat.OpenXml.Bibliography;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        /**************
         ***METHODES***
         **************/

        public bool ajouterActif(Actif actif)
        {
            /*informer l'utilisateur de son erreur précise*/
            var selectionNoms = "SELECT nom FROM Actif;";
            var commandSelectionNoms = new SQLiteCommand(selectionNoms, this.maBDD.connexion);
            var noms = commandSelectionNoms.ExecuteReader();

            while (noms.Read())
            {
                if (noms.GetString(0) == actif.nom)
                {
                    MessageBox.Show("un actif du même nom existe déjà", "Erreur actif");
                    return false;
                }
            }

            if (actif.nom == "")
            {
                MessageBox.Show("choisissez un nom", "Erreur nom");
                return false;
            }

            if (actif.type == "")
            {
                MessageBox.Show("choisissez un type (ETF, crypto, action ...)", "Erreur type");
                return false;
            }

            else
            {

                /*-------------------------------
                   Ajout dans la base de données
                *-------------------------------*/
                try
                {
                    string insertionActif = "INSERT INTO Actif VALUES(@nom,@type,@ISIN,@risque);";
                    var commandInsertionActif = new SQLiteCommand(insertionActif, this.maBDD.connexion);
                    commandInsertionActif.Parameters.AddWithValue("@nom", actif.nom);
                    commandInsertionActif.Parameters.AddWithValue("@type", actif.type);
                    commandInsertionActif.Parameters.AddWithValue("@ISIN", actif.isin);
                    commandInsertionActif.Parameters.AddWithValue("@risque", actif.risque);

                    commandInsertionActif.ExecuteNonQuery();
                    commandInsertionActif.Dispose();
                }
                catch (SQLiteException ex)
                {
                    MessageBox.Show(ex.Message, "Erreur insertion actif bdd");
                }

                return true;
            }
        }

        public bool modifActif()
        {
            //a faire
            return true;
        }


        public bool supprActif()
        {
            //a faire
            return true;
        }
    }
}
