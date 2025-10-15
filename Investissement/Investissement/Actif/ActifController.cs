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
        public Form1 form;

        /*CONSTRUCTEUR*/
        public ActifController(Form1 form, BDD bdd)
        {
            this.form = form;
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

        public bool ajoutActif(string nom, string type, string isin, string risque)
        {
            Actif actif = new Actif(nom,type,isin,risque);
            if (actifbdd.ajouterActif(actif))
            {
                form.afficherActifs(); //mise a jour en direct du tableau avec le nv actif
                return true;
            }
            return false;
        }

        public bool supprActif()
        {
            if (form.getGridViewActifs().SelectedRows.Count > 0)
            {
                DataGridViewRow row = form.getGridViewActifs().SelectedRows[0];
                string nom = row.Cells["Nom"].Value.ToString();
                DialogResult result = MessageBox.Show(
                    "Voulez-vous vraiment supprimer cet actif ?",
                    "Confirmation",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (result == DialogResult.Yes)
                {
                    if (actifbdd.supprActif(nom))
                    {
                        form.afficherActifs();
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
