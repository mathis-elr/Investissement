using System.Collections.Generic;
using System.Threading.Tasks;
using System;

/*
 A FAIRE :
- manque de gestion d'erreur en general
 */

namespace Investissement
{
    public class TransactionController
    {
        /*ATTRIBUTS*/
        TransactionBDD transactionbdd;
        Dictionary<string, double> dictionnairePrixActif;

        /*CONSTRUCTEUR*/
        public TransactionController(BDD bdd)
        {
            this.transactionbdd = new TransactionBDD(bdd);
        }

        /*ENCAPSULATION*/
        public Dictionary<string, double> getValeurActuelleParActif()
        {
            Dictionary<string, double> dictionaireValeurActuelle = new Dictionary<string, double>();
            foreach (SyntheseDetentionActif syntheseDetentionActif in transactionbdd.getSynthesesDetentionActifs())
            {
                double prixActuelActif = this.dictionnairePrixActif[syntheseDetentionActif.symboleActif];
                double quantiteEUR = syntheseDetentionActif.quantiteTotaleDetenue * prixActuelActif;
                dictionaireValeurActuelle[syntheseDetentionActif.nomActif] = quantiteEUR;
            }
            return dictionaireValeurActuelle;
        }
        public Dictionary<string, double> getQuantiteInvestitParTypeActif()
        {
            Dictionary<string, double> dictionnaireQuantiteInvestitParTypeActif = new Dictionary<string, double>();
            foreach (SyntheseDetentionActif syntheseDetentionActif in transactionbdd.getSynthesesDetentionActifs())
            {
                double prixActuelActif = this.dictionnairePrixActif[syntheseDetentionActif.symboleActif];
                double quantiteEUR = syntheseDetentionActif.quantiteTotaleDetenue * prixActuelActif;
                if(dictionnaireQuantiteInvestitParTypeActif.ContainsKey(syntheseDetentionActif.typeActif))
                {
                    dictionnaireQuantiteInvestitParTypeActif[syntheseDetentionActif.typeActif] += quantiteEUR;
                }
                else
                {
                    dictionnaireQuantiteInvestitParTypeActif.Add(syntheseDetentionActif.typeActif, quantiteEUR);
                }

            }
            return dictionnaireQuantiteInvestitParTypeActif;
        }
        public Dictionary<DateTime, double> getQuantiteInvestitParDate()
        {
            return transactionbdd.getQuantiteInvestitParDate();
        }
        public Dictionary<DateTime, double> getMoyenneValeurPatrimoineParJour()
        {
            return transactionbdd.getMoyenneValeurPatrimoineParJour();
        }


        /*METHODES*/
        public void ajouterTransaction(Transaction nvlTransaction)
        {
            transactionbdd.ajouterTransaction(nvlTransaction);
        }
        public void ajouterInvestissementTotalDuJour()
        {
            //permet une harmonisation pour la visualisation du graphique,
            //comme ça la ligne d'investissement total est à jour des que l'on veut visualiser le graphique même si n'a pas investit ajd
            if (this.investissementEffectueAujourdhui()) { return; }
            transactionbdd.ajouterInvestissementTotal(DateTime.Today,0);
        }
        public void ajouterInvestissementTotal(DateTime date, double quantiteInvestit)
        {
            transactionbdd.ajouterInvestissementTotal(date, quantiteInvestit);
            this.verifierDateInvestissement(date, quantiteInvestit);
        }
        private void verifierDateInvestissement(DateTime date, double quantiteInvestit)
        {
            //cas ou on viens d'ajouter un investissement alors que des investissements plus recents on déjà été saisie
            //on modifie donc la quantite de toute les date superieur a la date d'investissement qui vient d'être effectué
            if (date.ToString("yyyy-MM-dd") != DateTime.Today.ToString("yyyy-MM-dd"))
            {
                transactionbdd.modifierInvestissementTotalApresDate(date, quantiteInvestit);
            }
        }
        public void modifierInvestissementTotal(DateTime date, double quantiteInvestit)
        {
            //le premier if pourrait être suprimé en soit mais je trouve plus clair ecrit comme ça
            if(date.ToString("yyyy-MM-dd") == DateTime.Today.ToString("yyyy-MM-dd") && transactionbdd.dateInvestissementExiste(date))
            {
                transactionbdd.modifierInvestissementTotal(DateTime.Today, quantiteInvestit);
            }
            else if(transactionbdd.dateInvestissementExiste(date))
            {
                transactionbdd.modifierInvestissementTotal(date, quantiteInvestit);
            }
            else
            {
                //- si la date d'investissement est ajd et que cette date n'existe pas encore dans la bdd
                //(donc en gros si a juste ouvert l'appli et qu'on a fait un investissement direct sans charger les données de "Patrimoine"
                //- si un investissement a une date quelquonque qui n'avais pas été ajouté a la bdd
                //(car pas de chargement des données de la page "Patrimoine à cette date là)
                this.ajouterInvestissementTotal(date, quantiteInvestit);
            }
        }
        public async Task recupererPrixActifsActuel()
        {
            List<string> listeSymboles = transactionbdd.getSymbolesActif();
            this.dictionnairePrixActif = await GestionnaireYahoo.GetPrixActifs(listeSymboles);
        }
        public double calculerEnregistrerValeurPatrimoineActuel(double ancienPrix)
        {
            double valeurPatrimoine = this.calculerValeurPatrimoineActuel();
            if(valeurPatrimoine == 0) { throw new Exception("Auncun investissement effectué"); }
            if (valeurPatrimoine != ancienPrix) 
            {
                transactionbdd.enregistrerValeurPatrimoineActuel(valeurPatrimoine);
            };
            return valeurPatrimoine;
        }
        private double calculerValeurPatrimoineActuel()
        {
            double valeurTotalePatrimoine = 0;
            foreach (KeyValuePair<string,string> symboleParActif in transactionbdd.getSymboleParActif())
            {
                double quantite = transactionbdd.getQuantiteTotaleDetenuDunActif(symboleParActif.Key);

                double prix = 0;
                if (this.dictionnairePrixActif.ContainsKey(symboleParActif.Value))
                {
                    prix = this.dictionnairePrixActif[symboleParActif.Value];
                }

                valeurTotalePatrimoine += quantite * prix;
            }
            return Math.Round(valeurTotalePatrimoine, 2);
        }
        public double calculerProportion(double part, double partTotale)
        {
            return Math.Round(part / partTotale * 100, 2);
        }
        private bool investissementEffectueAujourdhui()
        {
            return transactionbdd.getDateDernierInvest() == DateTime.Today;
        }
    }
}
