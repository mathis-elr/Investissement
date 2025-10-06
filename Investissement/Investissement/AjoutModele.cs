using DocumentFormat.OpenXml.Wordprocessing;
using MetroFramework.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Investissement
{
    public partial class AjoutModele : Form
    {
        public Form1 form;
        public AjoutModele(Form1 form)
        {
            this.form = form;
            InitializeComponent();

        }

        private void AjoutModele_Load(object sender, EventArgs e)
        {
            this.labelImportant.Text += " les actifs de ce modèle \nseront le contenu actuel du tableau \nde la page 'Investir'";
            this.btnAjouterModele.Click += (s, _) =>  AjouterModele(this.inputNom.Text, this.inputDescription.Text);
        }



        /**************
         ***METHODES***
         **************/
        private void AjouterModele(string nom, string description)
        {

            if (nom != "" && description != "")
            {

                /*-------------------------------
                   Ajout dans la base de données
                *-------------------------------*/
                try
                {
                    string insertionModele = "INSERT INTO ModeleInvest(nom,description) VALUES(@nom,@description);";
                    var commandInsertionModele = new SQLiteCommand(insertionModele, form.bdd);
                    commandInsertionModele.Parameters.AddWithValue("@nom", nom);
                    commandInsertionModele.Parameters.AddWithValue("@description", description);
                    commandInsertionModele.ExecuteNonQuery();
                    commandInsertionModele.Dispose();

                    this.form.majGridModele(nom);
                    
                }
                catch (SQLiteException ex)
                {
                    MessageBox.Show(ex.Message, "erreur insertion actif bdd");
                }

                //mise a jour des choix possibles puisqu'on vient d'en ajouter un
                form.majModeles();
                this.Close();
            }
            else
            {
                MessageBox.Show("abscence nom/description");
            }
        }
    }
}
