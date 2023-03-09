
SELECT SUM(prix_abonne)
FROM Service, RecetteService, Recette, Payeur, Patient, Entreprise
WHERE Service.idservice = RecetteService.idservice and
RecetteService.idrecette = Recette.idrecette and
type_payeur = 'patient' and
statut_caisse = 'OK' and 
Recette.idpayeur = Payeur.idpayeur and
Payeur.idpatient = Patient.idpatient and 
Patient.identreprise = Entreprise.identreprise and nomentreprise  = 'SACIM'
and Service.numcompte = '706113'

SELECT SUM(qtevendue * prixunitaire)
FROM LigneStock, RecetteProduit, Recette, Payeur, Patient, Entreprise
WHERE LigneStock.idstock = RecetteProduit.idstock and
RecetteProduit.idrecette = Recette.idrecette and
type_payeur = 'patient' and
statut_caisse = 'OK' and 
Recette.idpayeur = Payeur.idpayeur and
Payeur.idpatient = Patient.idpatient and 
Patient.identreprise = Entreprise.identreprise and nomentreprise  = 'SACIM'