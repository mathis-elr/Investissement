using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Investissement
{
    public class Transaction
    {        
        /*ATTRIBUTS*/
        public long id { get; set; }
        public DateTime date { get; set; }
        public string actif { get; set; }
        public string type { get; set; }
        public long quantite { get; set; }
        public long prix { get; set; }



        /*CONSTRUCTEUR*/
        public Transaction(DateTime date, string actif, string type, long quantite, long prix)
        {
            this.date = date;
            this.actif = actif;
            this.type = type;
            this.quantite = quantite;
            this.prix = prix;
        }

        /*ENCAPUSULATION*/
        //aucune pour le moment
    }
}
