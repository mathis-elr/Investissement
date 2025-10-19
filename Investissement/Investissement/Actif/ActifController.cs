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


         /*METHODES*/
        public List<string> getListeActifs()
        {
            return actifbdd.getListeActifs();
        }

        public DataTable getActifs()
        {
            return actifbdd.getActifsDataTable();
        }

        public void ajoutActif(Actif nvActif)
        {
            if (nvActif == null) { throw new ArgumentNullException(nameof(nvActif), "L'actif ne peut pas être null."); }
            if (string.IsNullOrEmpty(nvActif.nom)) { throw new ArgumentException("Le nom de l'actif est obligatoire."); }
            if (string.IsNullOrEmpty(nvActif.type)) { throw new ArgumentException("Le type de l'actif est obligatoire."); }
            if (!string.IsNullOrEmpty(nvActif.isin) && nvActif.isin.Length != 12) { throw new ArgumentException("Si votre actif a un code ISIN, il doit comporter 12 caractères."); }

           actifbdd.ajouterActif(nvActif);
        }

        public void supprActif(string nom)
        {
            if (nom == null) { throw new ArgumentNullException(nameof(nom), "L'actif ne peut pas être null."); }

            actifbdd.supprActif(nom);
        }
    }
}
