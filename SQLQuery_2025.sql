SELECT o.idoperation, date_operation, numpiece, libelle, numcompte, montantdebit, montantcredit 
FROM Operation o
JOIN OperationCompte oc ON o.idoperation = oc.idoperation
JOIN Exercice ex ON ex.idexercice = o.idexercice
WHERE exercice = 2023 AND montantdebit != 0 OR idexercice = 2023 AND montantcredit != 0


DELETE FROM OperationCompte WHERE montantdebit != 0 OR montantcredit != 0

DELETE FROM Operation