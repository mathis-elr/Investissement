using System.Collections.Generic;
using System;


namespace Investissement
{
    public class InvestissementTotalController
    {
        /*ATTRIBUTS*/
        private readonly InvestissementTotalBDD investissementTotalBDD;

        /*CONSTRUCTEUR*/
        public InvestissementTotalController(BDD bdd)
        {
            this.investissementTotalBDD = new InvestissementTotalBDD(bdd);
        }

        /*ENCAPSULATION*/
        public Dictionary<DateTime, double> getQuantiteInvestitParDate()
        {
            return investissementTotalBDD.getQuantiteInvestitParDate();
        }

        /*methodes*/
        public void ajouterInvestissementsTotauxManquant()
        {
            //si il n'y a pas encore eu d'investissement
            var dateDernierInvest = investissementTotalBDD.getDateDernierInvest();
            if(dateDernierInvest == null)
            {
                this.ajouterInvestissementTotal(DateTime.Today.AddDays(-1), 0);
                return;
            }

            DateTime dateDuJour = DateTime.Today;
            if (dateDernierInvest != dateDuJour)
            {
                DateTime dateCourante = Convert.ToDateTime(dateDernierInvest);
                
                while (dateCourante < dateDuJour)
                {
                    dateCourante = dateCourante.AddDays(1);
                    this.ajouterInvestissementTotal(dateCourante, 0);
                }
            }   
        }
        public void ajouterInvestissementTotal(DateTime date, double quantiteInvestit)
        {
            investissementTotalBDD.ajouterInvestissementTotal(date, quantiteInvestit);
            this.verifierDateInvestissement(date, quantiteInvestit);
        }
        private void verifierDateInvestissement(DateTime date, double quantiteInvestit)
        {
            //cas ou on viens d'ajouter un investissement alors que des investissements plus recents on déjà été saisie
            //on modifie donc la quantite de toute les date superieur a la date d'investissement qui vient d'être effectué
            if (date != DateTime.Today)
            {
                investissementTotalBDD.modifierInvestissementTotalApresDate(date, quantiteInvestit);
                //Dictionary<string,double> dictionnairePrixMoyenParActif = await GestionnaireYahoo.GetMoyennePrixParDate(transactionbdd.getSymbolesActif(), date);
                //double valeurPatrimoine = this.calculerValeurPatrimoineActuel(dictionnairePrixMoyenParActif);
                //transactionbdd.enregistrerValeurPatrimoineActuel(valeurPatrimoine, date);
            }
        }
        public void modifierInvestissementTotal(DateTime date, double quantiteInvestit)
        {
            investissementTotalBDD.modifierInvestissementTotal(date, quantiteInvestit);
        }
    }
}
