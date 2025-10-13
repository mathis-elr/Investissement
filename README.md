<h1>Suivi d'investissment</h1>
<p>but : Suivre et enregistrer ses transactions dans une base de données ainsi que visualiser ses investissements et son patrimoine</p>

<h2>Ce que l'application propose :</h2>
  <pre>
  Page investir :
    • Ajouter/Supprimer des actifs (crypto, ETF, actions ...)
    • Visualiser les actifs enregistrées dans la base de données 
    • Ajouter un investissement (= une ou plusieurs transactions) en indiquant pour chaque actif le prix d'achat, la quantité et la date
    • Création/Suppression de modèles d'investissements pour faciliter l'investissement DCA avec l'ajout/suppresion de transactions (nom actif, leur type, la quantité)
    • Appliquer un modele d'investissement
  </pre>


<h2>Ce que l'application proposera :</h2>
  <pre>
      Page patrimoine :
        - valeur du Patrimoine tout actifs confondues
        - afficher la liste des transactions effectuées et pouvoir filtrer en fonction du type/nom/date <br>
  </pre>
  <pre>
      Page graphiques :
        - 2 courbe dans un graphique (somme en fonction de la date) : 
          -> l'une formera le montant total investit en donction de la date (depuis le premier investissement jusqu'au dernier)
          -> l'autre indiquement la valeur du patrimoine actuel en recupérant les valeur des actifs via une API 
        - 2 pie (diagrammes camambert => visualisation en % par rapport à la valeur total du portefeuille) : 
          -> répartition du patrimoine en fonction du type (crypto, ETF ...) 
          -> répartition du patrimoine en fonction des actifs <br>
  </pre>
  <pre>
      Page bourse :
        - affichage des actifs investit avec leur prix en direct (via API) <br>
  </pre>
  <pre>
      Page Investir :
        - pouvoir programmer ses investissement tous les x jours en ajoutant dans un agenda (google calendar API)
        - envoyer des notifications (connecté a l'agenda) si on doit rajouter de l'argent sur l'appli <br>
        - modifier un modele (nom, description et transactions)
        - modifier un actif 
        - maj ajouter un modele d'investissement, ça vide le tableau actuel, on peut choisir les actifs que l'ont souhaite via un combo box dans la tableau, pour le nom et la description ce sera directement dans l'interface de base sous forme d'input et donc rajouter un bouton ajouter le modele 
        - maj ajouter actif, ça vide le tableau et affiche les colonnes correspondantes aux paramètre d'un actif, plus d'interface, tout ce fait dans l'interface principale
  </pre>

