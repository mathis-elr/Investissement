using System;
using System.Data.SQLite;
using System.Windows.Forms;

namespace Investissement
{
    public partial class AjoutModele : Form
    {
        /*ATTRIBUTS*/
        public Form1 form;

        /*CONSTRUCTEURS*/
        public AjoutModele(Form1 form)
        {
            this.form = form;
            InitializeComponent();

        }

        /*INITIALISATION*/
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
            //verifier si il n'existe pas déjà
            var query = "SELECT nom FROM ModeleInvest;";
            var command = new SQLiteCommand(query, form.maBDD.connexion);
            var noms = command.ExecuteReader();

            while(noms.Read())
            {
                if(noms.GetString(0) == nom)
                {
                    MessageBox.Show("un modele du même nom existe déjà", "Erreur modele");
                    return;
                }
            }


            if (nom != "" && description != "")
            {

                /*-------------------------------
                   Ajout dans la base de données
                *-------------------------------*/
                try
                {
                    string insertionModele = "INSERT INTO ModeleInvest(nom,description) VALUES(@nom,@description);";
                    var commandInsertionModele = new SQLiteCommand(insertionModele, form.maBDD.connexion);
                    commandInsertionModele.Parameters.AddWithValue("@nom", nom);
                    commandInsertionModele.Parameters.AddWithValue("@description", description);
                    commandInsertionModele.ExecuteNonQuery();
                    commandInsertionModele.Dispose();

                    this.form.insertionTransactionsNvModele(nom); //on recupère les infos du tableau appartenant à form1 donc methode de form1
                    
                }
                catch (SQLiteException ex)
                {
                    MessageBox.Show(ex.Message, "Erreur insertion actif bdd");
                }

                form.majModeles(); //mise a jour du combo box pour pouvoir utiliser le modele crée, methode dans form1 car le combobox appartient à l'interface de form1
                this.Close();
            }

            /*informer l'utilisateur de son erreur précise*/
            if(nom == "")
            {
                MessageBox.Show("chosissez un nom","Erreur nom");
            }

            if (description == "")
            {
                MessageBox.Show("decrivez votre modèle","Erreur desccription");
            }
        }
    }
}
