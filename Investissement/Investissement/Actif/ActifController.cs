using MetroFramework.Controls;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;
using System.Windows.Input;

namespace Investissement
{
    public class ActifController
    {
        /*ATTRIBUTS*/
        public ActifBDD actifbdd;

        /*CONSTRUCTEUR*/
        public ActifController(BDD bdd)
        {
            this.actifbdd = new ActifBDD(bdd);
        }


        /**************
         ***METHODES***
         **************/
        public List<string> getListeActifs()
        {
            return actifbdd.getListeActifs();
        }

        public DataTable getActifs()
        {
            return actifbdd.getActifsDataTable();
        }

        public bool ajoutActif(Actif nvActif)
        {
            if (actifbdd.ajouterActif(nvActif))
            {
                return true;
            }
            return false;
        }

        public bool supprActif(string nom)
        {
            return actifbdd.supprActif(nom);
        }
    }
}
