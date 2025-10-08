using DocumentFormat.OpenXml.Wordprocessing;
using MetroFramework.Animation;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        /**************
         ***METHODES***
         **************/

        public void ajouterTransaction(Transaction transaction)
        {
            string query = "INSERT INTO [Transaction] (date,actif,type,quantite,prix) VALUES (@date,@actif,@type,@quantite,@prix);"; //entre crochets car Transaction est un mot réservé en sql
            var command = new SQLiteCommand(query, this.maBDD.connexion);

            command.Parameters.AddWithValue("@date", transaction.date.ToString("yyyy-MM-dd"));
            command.Parameters.AddWithValue("@actif", transaction.actif);
            command.Parameters.AddWithValue("@type", transaction.type);
            command.Parameters.AddWithValue("@quantite", transaction.quantite);
            command.Parameters.AddWithValue("@prix", transaction.prix);

            command.ExecuteNonQuery(); //commande d'executuion poour INSERT, UPDATE, DELETE
            command.Dispose();
        }
    }
}
