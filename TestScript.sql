ALTER TABLE Depense ADD raison_retrait VARCHAR(50)

--Du 04-04-2023

CREATE TABLE Exercice(
idexercice INT PRIMARY KEY,
exercice INT NOT NULL,
statut VARCHAR(7)
)

ALTER TABLE OperationCompte ADD libelle VARCHAR(100)

SELECT o.idoperation, o.libelle, numcompte, montantdebit, montantcredit
FROM Operation o
JOIN OperationCompte op ON o.idoperation = op.idoperation

ALTER TABLE Operation ADD idexercice INT

ALTER TABLE Operation 
ADD CONSTRAINT FK_Opera_Exercice 
FOREIGN KEY (idexercice) 
REFERENCES Exercice(idexercice) 
ON UPDATE CASCADE

ALTER TABLE Operation DROP COLUMN libelle
