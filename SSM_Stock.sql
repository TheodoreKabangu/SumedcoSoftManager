--SSM_Stock

CREATE TABLE [dbo].[LigneAppro] (
    [idappro]    INT             NOT NULL,
    [date_dem]   DATE            NOT NULL,
    [idstock]    INT             NOT NULL,
    [prix_achat] NUMERIC (12, 2) NULL,
    [taux]       NUMERIC (5, 2)  NULL,
    [qtedem]     SMALLINT        NOT NULL,
    [qteappro]   SMALLINT        NOT NULL,
    [qteajoute]  SMALLINT        NOT NULL,
    PRIMARY KEY CLUSTERED ([idappro] ASC),
    FOREIGN KEY ([idstock]) REFERENCES [dbo].[LigneStock] ([idstock])
);

CREATE TABLE [dbo].[LigneApproAutreStock] (
    [idappro]    INT             NOT NULL,
    [date_dem]   DATE            NOT NULL,
    [idproduit]  SMALLINT        NOT NULL,
    [prix_achat] NUMERIC (12, 2) NULL,
    [qtedem]     INT             NOT NULL,
    [qteappro]   INT             NOT NULL,
    [qteajoute]  INT             NOT NULL,
    PRIMARY KEY CLUSTERED ([idappro] ASC),
    FOREIGN KEY ([idproduit]) REFERENCES [dbo].[ProduitAutreStock] ([idproduit])
);

CREATE TABLE [dbo].[LigneCommande] (
    [idcommande]  INT      NOT NULL,
    [date_jour]   DATE     NOT NULL,
    [idstock]     INT      NOT NULL,
    [qtecommande] SMALLINT NOT NULL,
    [qteservie]   SMALLINT NOT NULL,
    PRIMARY KEY CLUSTERED ([idcommande] ASC),
    FOREIGN KEY ([idstock]) REFERENCES [dbo].[LigneStock] ([idstock])
);

CREATE TABLE [dbo].[LigneRequisition] (
    [idrequisition] INT      NOT NULL,
    [date_jour]     DATE     NOT NULL,
    [idstock]       INT      NOT NULL,
    [qterequise]    SMALLINT NOT NULL,
    [qteaccordee]   SMALLINT NOT NULL,
    PRIMARY KEY CLUSTERED ([idrequisition] ASC),
    FOREIGN KEY ([idstock]) REFERENCES [dbo].[LigneStock] ([idstock])
);

CREATE TABLE [dbo].[LigneRequisitionAutre] (
    [idrequisition] INT      NOT NULL,
    [date_jour]     DATE     NOT NULL,
    [idproduit]     SMALLINT NOT NULL,
    [qterequise]    SMALLINT NOT NULL,
    [qteaccordee]   SMALLINT NOT NULL,
    PRIMARY KEY CLUSTERED ([idrequisition] ASC),
    FOREIGN KEY ([idproduit]) REFERENCES [dbo].[ProduitAutreStock] ([idproduit])
);

CREATE TABLE [dbo].[LigneStock] (
    [idstock]         INT             NOT NULL,
    [idproduit]       SMALLINT        NOT NULL,
    [conditionnement] VARCHAR (15)    NOT NULL,
    [dosage]          VARCHAR (20)    NOT NULL,
    [forme]           VARCHAR (15)    NOT NULL,
    [numlot]          VARCHAR (20)    NOT NULL,
    [prixunitaire]    NUMERIC (12, 2) NULL,
    [qtestock]        INT             NOT NULL,
    [CMM]             INT             NOT NULL,
    PRIMARY KEY CLUSTERED ([idstock] ASC),
    FOREIGN KEY ([idproduit]) REFERENCES [dbo].[Produit] ([idproduit])
);

CREATE TABLE [dbo].[LigneStockPharma] (
    [idstockpharma]  INT NOT NULL,
    [idstock]        INT NOT NULL,
    [qtestockpharma] INT NOT NULL,
    PRIMARY KEY CLUSTERED ([idstockpharma] ASC),
    FOREIGN KEY ([idstock]) REFERENCES [dbo].[LigneStock] ([idstock])
);

CREATE TABLE [dbo].[LigneUtilisation] (
    [idutilisation] INT         NOT NULL,
    [date_jour]     DATE        NOT NULL,
    [periode]       VARCHAR (5) NOT NULL,
    [idstock]       INT         NOT NULL,
    [stock]         SMALLINT    NOT NULL,
    [qteajoute]     SMALLINT    NOT NULL,
    [utilisation]   SMALLINT    NOT NULL,
    [perte]         SMALLINT    NOT NULL,
    PRIMARY KEY CLUSTERED ([idutilisation] ASC),
    FOREIGN KEY ([idstock]) REFERENCES [dbo].[LigneStock] ([idstock])
);

CREATE TABLE [dbo].[Lot] (
    [numlot]          VARCHAR (20) NOT NULL,
    [date_expiration] VARCHAR (10) NOT NULL,
    [idproduit]       SMALLINT     NOT NULL,
    PRIMARY KEY CLUSTERED ([numlot] ASC),
    FOREIGN KEY ([idproduit]) REFERENCES [dbo].[Produit] ([idproduit])
);

CREATE TABLE [dbo].[Mouvement] (
    [idmouvement] INT           NOT NULL,
    [date_jour]   SMALLDATETIME NOT NULL,
    [operation]   VARCHAR (6)   NOT NULL,
    [idstock]     INT           NOT NULL,
    [quantite]    INT           NOT NULL,
    PRIMARY KEY CLUSTERED ([idmouvement] ASC),
    FOREIGN KEY ([idstock]) REFERENCES [dbo].[LigneStock] ([idstock])
);

CREATE TABLE [dbo].[MouvementAutreStock] (
    [idmvt]       INT          NOT NULL,
    [date_jour]   DATE         NOT NULL,
    [operation]   VARCHAR (6)  NOT NULL,
    [idproduit]   SMALLINT     NOT NULL,
    [quantite]    INT          NOT NULL,
    [destination] VARCHAR (50) NULL,
    PRIMARY KEY CLUSTERED ([idmvt] ASC),
    FOREIGN KEY ([idproduit]) REFERENCES [dbo].[ProduitAutreStock] ([idproduit])
);

CREATE TABLE [dbo].[MouvementPharma] (
    [idmvtpharma]   INT           NOT NULL,
    [date_jour]     SMALLDATETIME NOT NULL,
    [operation]     VARCHAR (6)   NOT NULL,
    [idstockpharma] INT           NOT NULL,
    [quantite]      INT           NOT NULL,
    [destination]   VARCHAR (50)  NULL,
    PRIMARY KEY CLUSTERED ([idmvtpharma] ASC),
    FOREIGN KEY ([idstockpharma]) REFERENCES [dbo].[LigneStockPharma] ([idstockpharma])
);

CREATE TABLE [dbo].[Produit] (
    [idproduit]  SMALLINT     NOT NULL,
    [nomproduit] VARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([idproduit] ASC)
);

CREATE TABLE [dbo].[ProduitAutreStock] (
    [idproduit]  SMALLINT     NOT NULL,
    [numcompte]  VARCHAR (10) NOT NULL,
    [nomproduit] VARCHAR (50) NOT NULL,
    [unite]      VARCHAR (10) NOT NULL,
    [qtestock]   INT          NOT NULL,
    [CMM]        INT          NOT NULL,
    [descriptif] VARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([idproduit] ASC)
);

CREATE TABLE [dbo].[Utilisateur] (
    [id]            SMALLINT     NOT NULL,
    [utilisateur]   VARCHAR (10) NOT NULL,
    [motdepasse]    VARCHAR (10) NOT NULL,
    [poste]         VARCHAR (10) NOT NULL,
    [specification] VARCHAR (10) NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
);
