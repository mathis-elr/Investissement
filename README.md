<h1>Suivi d'investissment</h1>
<p>but : Suivre et enregistrer ses transactions dans une base de données ainsi que visualiser ses investissements et son patrimoine</p>

<h2>Ce que l'application propose :</h2>
  <pre>
    • Ajouter des actifs (crypto, ETF, actions ...) <br>
    • Visualiser les actifs enregistrées dans la base de données <br>
    • Ajouter un investissement (= une ou plusieurs transactions) en indiquant simplement le prix d'achat, la quantité et la date <br>
    • Recuperer l'investissements précedent pour pouvoir reinvestir la même chose ou simplement pour visualiser
  </pre>


<h2>Ce que l'application proposera :</h2>
  <pre>
    • Nouvelles pages (patrimoines, graphiques, bourse) :
      - 2 courbe dans un graphique (somme en fonction de la date) : 
        -> l'une formera le montant total investit en donction de la date (depuis le premier investissement jusqu'au dernier)
        -> l'autre indiquement la valeur du patrimoine actuel en recupérant les valeur des actifs via une API 
      - 2 pie (diagrammes camambert => visualisation en % par rapport à la valeur total du portefeuille) : 
        -> répartition du patrimoine en fonction du type (crypto, ETF ...) 
        -> répartition du patrimoine en fonction des actifs 
      - afficher la liste des transactions effectuées et pouvoir filtrer en fonction du type/nom/date 
      - affichage des actifs investit avec leur prix en direct (via API) <br>
    • Interface principale  -> Plus de possibilitées sur l'investissement en DCA (tout en gardant la fonctionnalité de recuperer le dernier investissement) : 
      - pouvoir crée des investissements préconfigurés (plus simple si on investit la même chose et la même quantité tout les n jours) 
      - pouvoir programmer ses investissement tous les x jours en ajoutant dans un agenda (google calendar API)
      - envoyer des notifications (connecté a l'agenda) si on doit rajouter de l'argent sur l'appli <br>
  </pre>
