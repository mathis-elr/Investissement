using System;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Investissement
{
    public class BDD
    {
        /*ATTRIBUTS*/
        public string connexionString;
        public SQLiteConnection connexion;

        /*CONSTRUCTEUR*/
        public BDD(string connexion)
        {
            this.connexionString = connexion;
            this.connexion = new SQLiteConnection(connexion);
        }

        public bool ouvrirBDD()
        {
            try
            {
                this.connexion.Open();
                return true;
            }
            catch (SQLiteException ex)
            {
                throw new Exception("Erreur lors de l'ouverture de la BDD : " + ex.Message);
            }
        }

        public bool fermerBDD()
        {
            try
            {
                this.connexion.Close();
                this.connexion.Dispose();
                return true;
            }
            catch (SQLiteException ex)
            {
                throw new Exception("Erreur lors de la fermeture de la BDD : " + ex.Message);
            }
        }
    }
}
