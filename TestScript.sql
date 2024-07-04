--Du 23/11/2023


USE master;  
GO  
ALTER DATABASE SSMDB SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
GO
ALTER DATABASE SSMDB MODIFY NAME = SSMDBNEW;
GO  
ALTER DATABASE SSMDBNEW SET MULTI_USER;
GO


--=============================================================




--SELECT SUM(qteajoute)
--FROM LigneAppro a
--JOIN LigneCommande c ON a.idcom = c.idcom
--JOIN LigneStock s ON c.idstock = s.idstock
--WHERE s.idstock = 56

--SELECT SUM(qteservie)
--FROM SortieStock s
--JOIN LigneStock sp ON s.idstock = sp.idstock
--WHERE sp.idstock = 225

--SELECT SUM(qteservie)
--FROM ApproPharma a
--JOIN CommandePharma c ON a.idcomph = c.idcomph
--JOIN LigneStockPharma sp ON c.idstockph = sp.idstockph
--WHERE sp.idpharma = 1 AND sp.idstockph = 1

--SELECT SUM(qteservie)
--FROM SortiePharma s
--JOIN LigneStockPharma sp ON s.idstockph = sp.idstockph
--WHERE sp.idpharma = 1 AND sp.idstockph = 1



--Du 05/05/2023
ALTER TABLE Utilisateur ALTER COLUMN specification VARCHAR(75)
ALTER TABLE Medecin DROP COLUMN utilisateur
--Après ces deux comandes prendre les noms de médecins et 
--les placer comme spécifications dans la table Utilisateur
--faire de même pour les noms de pharmacies



--Ajouter aussi les sorties qui sont dans SortieStock
--pour les additionner aux sorties qui engagent les pharmacies
--ajouter dans la boucle de TrouverQteStock


--Pour trouver le résultat net de l'exercice
--Somme de produits vendus  - somme de charges
-- Ou affecter la différence entre total actif et total passif au compte 13


--XD+TK+RM+RS = TA + TB + TC + TD + TE + TF + TG + TH + TI + TK + RA + RB + RC + RD + RE + RF + RG + RH + RI + RJ + RK + RM + RS
--XD = XC + RK
--XC = (XB + RA + RB) + Somme(TE à RJ)
--XB = TA + TB + TC + TD
--Somme(TE à RJ) = TE + TF + TG + TH + TI + RC + RD + RE + RF + RG + RH + RI + RJ
