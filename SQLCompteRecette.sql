
SELECT SUM(prixservice), numcompte 
FROM Recette, Service,RecetteService
WHERE date_operation = '18/01/2023' AND
statut_facture = 'immédiat' AND 
Recette.idrecette = RecetteService.idrecette AND
RecetteService.idservice = Service.idservice AND RecetteService.idrecette = 393
GROUP BY numcompte