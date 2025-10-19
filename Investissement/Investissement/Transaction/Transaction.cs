using System;


namespace Investissement
{
    public class Transaction
    {        
        /*ATTRIBUTS*/
        public long id { get; set; }
        public DateTime date { get; set; }
        public string actif { get; set; }
        public long quantite { get; set; }
        public long prix { get; set; }



        /*CONSTRUCTEUR*/
        public Transaction(DateTime date, string actif, long quantite, long prix)
        {
            this.date = date;
            this.actif = actif;
            this.quantite = quantite;
            this.prix = prix;
        }

        /*ENCAPUSULATION*/
        //aucune pour le moment
    }
}
