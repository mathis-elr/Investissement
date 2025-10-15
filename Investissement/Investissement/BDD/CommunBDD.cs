using System;
using System.Data.SQLite;
using System.Linq;
using System.Windows.Forms;

namespace Investissement
{
    public static class CommunBDD
    {
        public static bool existe(BDD bdd, string table, string attribut, string valeur)
        {
            string[] tablesAutorisees = { "Actif", "ModeleInvest" ,"TransactionsModele"};
            if (!tablesAutorisees.Contains(table))
            {
                MessageBox.Show("la table entrée n'est pas autorisé", "Erreur autorisation table");
                return false;
            }

            string[] colonnesAutorisees = { "nom", "idModele"};
            if (!colonnesAutorisees.Contains(attribut))
            {
                MessageBox.Show("l'attribut entré n'est pas autorisé", "Erreur autorisation attribut");
                return false;
            }

            try
            {
                var selectionNoms = $"SELECT COUNT(*) FROM {table} WHERE {attribut}={valeur};"; //retourne 0 si il n'existe pas sinon n
                using (var commandSelectionNoms = new SQLiteCommand(selectionNoms, bdd.connexion))
                {
                    long existe = Convert.ToInt64(commandSelectionNoms.ExecuteScalar());
                    if (existe > 0)
                    {
                        MessageBox.Show("un actif du même nom existe déjà", "Erreur actif");
                        return true;
                    }
                }
            }
            catch (SQLiteException ex)
            {
                MessageBox.Show(ex.Message, $"Erreur verification d'existance dans la table {table}");
            }
            return false;
        }
    }
}
