/*Modifier la langue par défaut du mon login
pour que le format de la date soit comme en français
*/
alter LOGIN [THEO_PC\AUDIO-VISUEL] WITH DEFAULT_LANGUAGE= Français


alter LOGIN sa WITH DEFAULT_LANGUAGE= Français

/*
Renommer une colonne sous SQL Serveur
Il faut utiliser la procédure stockée sp_name
syntaxe : 
exec sp_name 'Nom_table.Ancien_Nom_colonne', 'Nouveau_Nom_colonne'
*/
exec sp_rename 'Patient.age', 'age2'
--Pour renommer une table
exec sp_rename 'StockProduit', 'ProduitStock'
/*
Modifier la structure d'une colonne: type, taille, null ou not null
syntaxe: alter table Nom_table alter column nom_colonne type[taille] null/not null
*/
alter table Compte alter column soldeanterieur numeric(18,2)
alter table AgendaCaisse alter column montantpaye numeric(18,2)
alter table AgendaCaisse alter column montanttotal numeric(18,2)
alter table Service alter column prixservice numeric(12,2)

select * from LigneAppro




