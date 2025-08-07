CREATE TABLE [dbo].[Operationprojet] (
    [idoperation]    INT      NOT NULL,
    [date_operation] DATE     NOT NULL,
    [idtypejournal]  SMALLINT NULL,
    [idexercice]     INT      NULL,
    PRIMARY KEY CLUSTERED ([idoperation] ASC),
    FOREIGN KEY ([idtypejournal]) REFERENCES [dbo].[TypeJournal] ([idtypejournal]),
    FOREIGN KEY ([date_operation]) REFERENCES [dbo].[Date_operation] ([date_operation]),
    CONSTRAINT [FK_OperaExercice] FOREIGN KEY ([idexercice]) REFERENCES [dbo].[Exercice] ([idexercice]) ON UPDATE CASCADE
);

CREATE TABLE [dbo].[OperationCompteprojet] (
    [id]              INT             NOT NULL,
    [idoperation]     INT             NOT NULL,
    [numpiece]        VARCHAR (20)    NULL,
    [montantdebit]    NUMERIC (18, 2) NULL,
    [montantcredit]   NUMERIC (18, 2) NULL,
    [libelle]         VARCHAR (250)   NULL,
    [soldeouvedebit]  NUMERIC (18, 2) NULL,
    [soldeouvecredit] NUMERIC (18, 2) NULL,
    [numcompte]       VARCHAR (10)    NULL,
    PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [FK_Opera] FOREIGN KEY ([idoperation]) REFERENCES [dbo].[Operationprojet] ([idoperation]) ON UPDATE CASCADE,
    CONSTRAINT [FK_Compte] FOREIGN KEY ([numcompte]) REFERENCES [dbo].[Compteprojet] ([numcompte]) ON UPDATE CASCADE
);




EXEC ConsommationAbonne 
    @StartDate = '01-01-2022', 
    @EndDate = '31-12-2023', 
    @EntrepriseId = 4;

SELECT * FROM Compte WHERE numcompte LIKE '705%'


SELECT 
    p.idpatient,
    p.noms,
    p.age,
    p.sexe,
    p.num_service,
    SUM(r.qtedem * r.prix) AS total_montant
FROM Recette_ r
INNER JOIN Patient p ON r.idpatient = p.idpatient
INNER JOIN Entreprise e ON p.identreprise = e.identreprise
WHERE 
    r.date_operation >= '2023-01-01' AND r.date_operation <= '2023-12-31'
GROUP BY 
    p.idpatient, p.noms, p.age, p.sexe, p.num_service
ORDER BY 
    total_montant DESC;