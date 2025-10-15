using System.Collections.Generic;

namespace Investissement
{
    public class ModeleInvest
    {
        /*ATTRIBUTS*/
        public long id { get; set; }
        public string nom { get; set; }
        public string description { get; set; }

        public List<TransactionModele> lesTransactionsDunModele;

        /*CONSTRUCTEUR*/
        public ModeleInvest( string nom, string description)
        {
            this.nom = nom;
            this.description = description;
            lesTransactionsDunModele = new List<TransactionModele>();
        }
    }
}
