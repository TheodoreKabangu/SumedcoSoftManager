update Compte

SET 
Compte.debit = c1.debit,
Compte.credit = c1.credit,
Compte.soldeanterieur = c1.soldeanterieur,
Compte.ref = c1.ref,
Compte.categorie = c1.categorie

FROM Compte c0 
JOIN Compte1 c1 ON c0.numcompte = c1.numcompte



