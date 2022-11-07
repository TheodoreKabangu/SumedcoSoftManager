CREATE TABLE [dbo].[Entreprise] (
    [identreprise]  SMALLINT     NOT NULL,
    [nomentreprise] VARCHAR (30) NOT NULL,
    [contacts]      VARCHAR (75) NOT NULL,
    PRIMARY KEY CLUSTERED ([identreprise] ASC)
);

CREATE TABLE [dbo].[TypeAbonne] (
    [idtypeabonne] SMALLINT     NOT NULL,
    [typeabonne]   VARCHAR (20) NOT NULL,
    PRIMARY KEY CLUSTERED ([idtypeabonne] ASC)
);

CREATE TABLE [dbo].[EntrepriseTypeAbonne] (
    [id]           SMALLINT NOT NULL,
    [identreprise] SMALLINT NOT NULL,
    [idtypeabonne] SMALLINT NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC),
    FOREIGN KEY ([identreprise]) REFERENCES [dbo].[Entreprise] ([identreprise]),
    FOREIGN KEY ([idtypeabonne]) REFERENCES [dbo].[TypeAbonne] ([idtypeabonne])
);

CREATE TABLE [dbo].[Abonne] (
    [idabonne]     INT          NOT NULL,
    [identreprise] SMALLINT     NOT NULL,
    [idtypeabonne] SMALLINT     NOT NULL,
    [refabonne]    VARCHAR (10) NOT NULL,
    [nomabonne]    VARCHAR (75) NOT NULL,
    [sexe]         VARCHAR (1)  NOT NULL,
    [anneenaiss]   SMALLINT     NOT NULL,
    PRIMARY KEY CLUSTERED ([idabonne] ASC),
    FOREIGN KEY ([idtypeabonne]) REFERENCES [dbo].[TypeAbonne] ([idtypeabonne]),
    FOREIGN KEY ([identreprise]) REFERENCES [dbo].[Entreprise] ([identreprise])
);

CREATE TABLE [dbo].[Compte] (
    [numcompte]      VARCHAR (10)    NOT NULL,
    [libellecompte]  VARCHAR (100)   NOT NULL,
    [debit]          NUMERIC (18, 2) NOT NULL,
    [credit]         NUMERIC (18, 2) NOT NULL,
    [soldeanterieur] REAL            NOT NULL,
    [ref]            VARCHAR (3)     NULL,
    PRIMARY KEY CLUSTERED ([numcompte] ASC)
);

CREATE TABLE [dbo].[Service] (
    [idservice]   SMALLINT     NOT NULL,
    [nomservice]  VARCHAR (75) NOT NULL,
    [prixservice] INT          NOT NULL,
    [numcompte]   VARCHAR (10) NULL,
    PRIMARY KEY CLUSTERED ([idservice] ASC),
    FOREIGN KEY ([numcompte]) REFERENCES [dbo].[Compte] ([numcompte])
);

CREATE TABLE [dbo].[AbonneProduit] (
    [id]        INT      NOT NULL,
    [date_jour] DATE     NOT NULL,
    [idabonne]  INT      NOT NULL,
    [idstock]   INT      NOT NULL,
    [qteprise]  SMALLINT NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC),
    FOREIGN KEY ([idabonne]) REFERENCES [dbo].[Abonne] ([idabonne])
);

CREATE TABLE [dbo].[AbonneService] (
    [id]        INT      NOT NULL,
    [date_jour] DATE     NOT NULL,
    [idabonne]  INT      NOT NULL,
    [idservice] SMALLINT NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC),
    FOREIGN KEY ([idservice]) REFERENCES [dbo].[Service] ([idservice]),
    FOREIGN KEY ([idabonne]) REFERENCES [dbo].[Abonne] ([idabonne])
);

CREATE TABLE [dbo].[Date_operation] (
    [date_operation] DATE NOT NULL,
    [taux]           INT  NOT NULL,
    PRIMARY KEY CLUSTERED ([date_operation] ASC)
);

CREATE TABLE [dbo].[BonDepense] (
    [numbon]         INT          NOT NULL,
    [date_operation] DATE         NOT NULL,
    [beneficiaire]   VARCHAR (75) NOT NULL,
    [idabonne]       INT          NULL,
    [raisonretrait]  VARCHAR (30) NULL,
    PRIMARY KEY CLUSTERED ([numbon] ASC),
    FOREIGN KEY ([date_operation]) REFERENCES [dbo].[Date_operation] ([date_operation]),
    FOREIGN KEY ([idabonne]) REFERENCES [dbo].[Abonne] ([idabonne])
);

CREATE TABLE [dbo].[Depense] (
    [iddepense]      INT           NOT NULL,
    [numbon]         INT           NOT NULL,
    [numcompte]      VARCHAR (10)  NOT NULL,
    [motifdepense]   VARCHAR (100) NOT NULL,
    [montant]        REAL          NOT NULL,
    [monnaie]        VARCHAR (3)   NOT NULL,
    [refrequisition] VARCHAR (30)  NOT NULL,
    PRIMARY KEY CLUSTERED ([iddepense] ASC),
    FOREIGN KEY ([numcompte]) REFERENCES [dbo].[Compte] ([numcompte]),
    FOREIGN KEY ([numbon]) REFERENCES [dbo].[BonDepense] ([numbon])
);

CREATE TABLE [dbo].[BonRecette] (
    [numbon]         INT          NOT NULL,
    [statut]         VARCHAR (8)  NOT NULL,
    [date_operation] DATE         NOT NULL,
    [payeur]         VARCHAR (75) NOT NULL,
    [idpatient]      INT          NOT NULL,
    [categorie]      VARCHAR (8)  NOT NULL,
    [raisonretrait]  VARCHAR (30) NULL,
    PRIMARY KEY CLUSTERED ([numbon] ASC),
    FOREIGN KEY ([date_operation]) REFERENCES [dbo].[Date_operation] ([date_operation])
);

CREATE TABLE [dbo].[BonRecetteProduit] (
    [numbonP]       INT          NOT NULL,
    [numbon]        INT          NOT NULL,
    [idstock]       INT          NOT NULL,
    [qtevendue]     SMALLINT     NOT NULL,
    [statut]        VARCHAR (8)  NOT NULL,
    [raisonretrait] VARCHAR (30) NULL,
    PRIMARY KEY CLUSTERED ([numbonP] ASC),
    FOREIGN KEY ([numbon]) REFERENCES [dbo].[BonRecette] ([numbon])
);

CREATE TABLE [dbo].[BonRecetteService] (
    [numbonS]       INT          NOT NULL,
    [numbon]        INT          NOT NULL,
    [idservice]     SMALLINT     NOT NULL,
    [qtevendue]     SMALLINT     NOT NULL,
    [statut]        VARCHAR (8)  NOT NULL,
    [raisonretrait] VARCHAR (30) NULL,
    PRIMARY KEY CLUSTERED ([numbonS] ASC),
    FOREIGN KEY ([numbon]) REFERENCES [dbo].[BonRecette] ([numbon]),
    FOREIGN KEY ([idservice]) REFERENCES [dbo].[Service] ([idservice])
);

CREATE TABLE [dbo].[TypeJournal] (
    [idtypejournal] SMALLINT     NOT NULL,
    [typejournal]   VARCHAR (50) NOT NULL,
    [compte]        VARCHAR (10) NULL,
    PRIMARY KEY CLUSTERED ([idtypejournal] ASC)
);

CREATE TABLE [dbo].[Operation] (
    [idoperation]    INT           NOT NULL,
    [date_operation] DATE          NOT NULL,
    [libelle]        VARCHAR (100) NOT NULL,
    [numpiece]       VARCHAR (30)  NOT NULL,
    [idtypejournal]  SMALLINT      NOT NULL,
    PRIMARY KEY CLUSTERED ([idoperation] ASC),
    FOREIGN KEY ([idtypejournal]) REFERENCES [dbo].[TypeJournal] ([idtypejournal]),
    FOREIGN KEY ([date_operation]) REFERENCES [dbo].[Date_operation] ([date_operation])
);

CREATE TABLE [dbo].[OperationCompte] (
    [id]            INT          NOT NULL,
    [idoperation]   INT          NOT NULL,
    [numcompte]     VARCHAR (10) NOT NULL,
    [montantdebit]  REAL         NOT NULL,
    [montantcredit] REAL         NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC),
    FOREIGN KEY ([numcompte]) REFERENCES [dbo].[Compte] ([numcompte]),
    FOREIGN KEY ([idoperation]) REFERENCES [dbo].[Operation] ([idoperation])
);

CREATE TABLE [dbo].[RecetteProduit] (
    [idrecette]      INT      NOT NULL,
    [date_operation] DATE     NOT NULL,
    [idstock]        INT      NOT NULL,
    [qtevendue]      SMALLINT NOT NULL,
    [numbon]         INT      NOT NULL,
    PRIMARY KEY CLUSTERED ([idrecette] ASC),
    FOREIGN KEY ([numbon]) REFERENCES [dbo].[BonRecette] ([numbon]),
    FOREIGN KEY ([date_operation]) REFERENCES [dbo].[Date_operation] ([date_operation])
);

CREATE TABLE [dbo].[RecetteService] (
    [idrecette]      INT      NOT NULL,
    [date_operation] DATE     NOT NULL,
    [idservice]      SMALLINT NOT NULL,
    [qtevendue]      SMALLINT NOT NULL,
    [numbon]         INT      NOT NULL,
    PRIMARY KEY CLUSTERED ([idrecette] ASC),
    FOREIGN KEY ([date_operation]) REFERENCES [dbo].[Date_operation] ([date_operation]),
    FOREIGN KEY ([idservice]) REFERENCES [dbo].[Service] ([idservice]),
    FOREIGN KEY ([numbon]) REFERENCES [dbo].[BonRecette] ([numbon])
);
