<h1>Suivi d'investissment</h1>
<p>but : Suivre et enregistrer ses transactions dans une base de données ainsi que visualiser ses investissements et son patrimoine</p>

<h2>Ce que l'application propose :</h2>
  <pre>
  Page investir :
    • Ajouter/Supprimer des actifs (crypto, ETF, actions ...)
    • Visualiser les actifs enregistrées dans la base de données 
    • Ajouter un investissement (= une ou plusieurs transactions) en indiquant pour chaque actif le prix d'achat, la quantité et la date
    • Création/Suppression/modification de modèles d'investissements pour faciliter l'investissement DCA avec l'ajout/suppresion/modification de transactions (nom actif et quantité)
    • Appliquer un modele d'investissement
  Page Patrimoine :
    • valeur du Patrimoine tout actifs confondues
    • 2 courbe dans un graphique (somme en fonction de la date) : 
      -> l'une formele montant total investit en fonction de la date (depuis le premier investissement jusqu'au dernier)
      -> l'autre indique la valeur du patrimoine actuel en recupérant les valeur des actifs via une API 
    • 2 pie (diagrammes camambert => visualisation en % par rapport à la valeur total du portefeuille) : 
      -> répartition du patrimoine en fonction du type (crypto, ETF ...) 
      -> répartition du patrimoine en fonction des actifs <br>
  </pre>

<h2>Ce que l'application proposera :</h2>
  <pre>
      Page patrimoine :
        - afficher la liste des transactions effectuées et pouvoir filtrer en fonction du type/nom/date <br>
  </pre>
  <pre>
      Page bourse :
        - affichage des actifs investit avec leur prix en direct (via Scraping Yahoo) <br>
  </pre>
        - pouvoir programmer ses investissement tous les x jours en ajoutant dans un agenda (google calendar API)
        - envoyer des notifications (connecté a l'agenda) si on doit rajouter de l'argent sur l'appli
        - modifier un actif 
  </pre>

