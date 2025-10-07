using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        /**************
         ***METHODES***
         **************/
        public bool ajouterModele(ModeleInvest modeleInvest)
        {
            /*informer l'utilisateur de son erreur précise*/
            var query = "SELECT nom FROM ModeleInvest;";
            var command = new SQLiteCommand(query, this.maBDD.connexion);
            var noms = command.ExecuteReader();

            while (noms.Read())
            {
                if (noms.GetString(0) == modeleInvest.nom)
                {
                    MessageBox.Show("un modele du même nom existe déjà", "Erreur modele");
                    return false;
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

                /*-------------------------------
                   Ajout dans la base de données
                *-------------------------------*/
                try
                {
                    string insertionModele = "INSERT INTO ModeleInvest(nom,description) VALUES(@nom,@description);";
                    var commandInsertionModele = new SQLiteCommand(insertionModele, this.maBDD.connexion);
                    commandInsertionModele.Parameters.AddWithValue("@nom", modeleInvest.nom);
                    commandInsertionModele.Parameters.AddWithValue("@description", modeleInvest.description);
                    commandInsertionModele.ExecuteNonQuery();
                    commandInsertionModele.Dispose();

                    //this.insertionTransactionsNvModele(modeleInvest.nom); 
                    
                }
                catch (SQLiteException ex)
                {
                    MessageBox.Show(ex.Message, "Erreur insertion actif bdd");
                }

                return true;
            }
        }

        private void insertionTransactionsNvModele(string nom)
        {
            //crée une nouvelle classe TransactionModele et transactionModeleBDD ?
        }
    }
}
