using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Investissement
{
    public class ModeleInvest
    {
        /*ATTRIBUTS*/
        //public int id { get; set; }
        public string nom { get; set; }
        public string description { get; set; }

        /*CONSTRUCTEUR*/
        public ModeleInvest( string nom, string description)
        {
            //this.id = id;
            this.nom = nom;
            this.description = description;
        }

        /*ENCAPUSULATION*/
        //aucune pour le moment
    }
}
