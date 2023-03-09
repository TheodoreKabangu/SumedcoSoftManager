CREATE TABLE [dbo].[LigneApproAutre] (
    [idappro]     INT             NOT NULL,
    [date_appro]  DATE            NOT NULL,
    [idstock]       INT             NOT NULL,
    [qteappro]    SMALLINT        NOT NULL,
    [qteajoute]   SMALLINT        NOT NULL,
    [prix_achat]  NUMERIC (12, 2) NULL,
    [taux]        NUMERIC (5, 2)  NULL,
    [observation] VARCHAR (100)   NULL,
    PRIMARY KEY CLUSTERED ([idappro] ASC),
    FOREIGN KEY ([idstock]) REFERENCES [dbo].[LigneStock] ([idstock])
);

SELECT o.numcompte, c.libellecompte, SUM(montantdebit), SUM(montantcredit) FROM OperationCompte o JOIN Compte c ON o.numcompte = c.numcompte WHERE idoperation IN (SELECT DISTINCT idoperation FROM Operation WHERE iddepense is NOT NULL) GROUP BY o.numcompte, c.libellecompte

