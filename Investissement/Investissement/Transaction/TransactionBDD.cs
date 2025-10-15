using System.Data.SQLite;

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
            string query = "INSERT INTO [Transaction] (date,actif,quantite,prix) VALUES (@date,@actif,@quantite,@prix);"; //entre crochets car Transaction est un mot réservé en sql
            using (var command = new SQLiteCommand(query, this.maBDD.connexion))
            {
                command.Parameters.AddWithValue("@date", transaction.date.ToString("yyyy-MM-dd"));
                command.Parameters.AddWithValue("@actif", transaction.actif);
                command.Parameters.AddWithValue("@quantite", transaction.quantite);
                command.Parameters.AddWithValue("@prix", transaction.prix);

                command.ExecuteNonQuery(); //commande d'executuion poour INSERT, UPDATE, DELETE
            }
        }
    }
}
