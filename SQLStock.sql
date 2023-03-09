DROP TABLE LigneAppro;
DROP TABLE LigneApproAutreStock;
DROP TABLE ProduitAutreStock;
DROP TABLE LigneUtilisation;
DROP TABLE SortieAutreStock;
DROP TABLE SortiePharma;

--Créer
CREATE TABLE [dbo].[LigneCommande] (
    [idcom]    INT             NOT NULL,
    [date_com]   DATE            NOT NULL,
    [idstock]    INT             NOT NULL,
    [qtedem]     SMALLINT        NOT NULL,
    PRIMARY KEY CLUSTERED ([idcom] ASC),
    FOREIGN KEY ([idstock]) REFERENCES [dbo].[LigneStock] ([idstock])
);

CREATE TABLE [dbo].[CategorieProduit] (
    [idcat]    SMALLINT             NOT NULL,
    [categorie]   VARCHAR(30)       NOT NULL,
    PRIMARY KEY CLUSTERED ([idcat] ASC),
);

--Recréer

CREATE TABLE [dbo].[Pharmacie] (
    [idpharma]    SMALLINT NOT NULL,
    [designation] VARCHAR(30)      NOT NULL,
    PRIMARY KEY CLUSTERED ([idpharma] ASC)
);

CREATE TABLE [dbo].[LigneStock] (
    [idstock]      INT             NOT NULL,
    [idproduit]    SMALLINT        NOT NULL,
	[qtestock]     INT             NOT NULL,
    [CMM]          INT             NOT NULL,
    [forme]        VARCHAR (15)    NOT NULL,
    [dosage]       VARCHAR (20)    NULL,
    [numlot]       VARCHAR (20)    NULL,
    [expiration]   VARCHAR (10)    NULL,
    [prixunitaire] NUMERIC (12, 2) NULL,
    [prix_abonne]  NUMERIC (12, 2) NULL,
    PRIMARY KEY CLUSTERED ([idstock] ASC),
    FOREIGN KEY ([idproduit]) REFERENCES [dbo].[Produit] ([idproduit])
);

CREATE TABLE [dbo].[Produit] (
    [idproduit]  SMALLINT     NOT NULL,
    [nomproduit] VARCHAR (50) NOT NULL,
	[idcat]    SMALLINT       NOT NULL,
    PRIMARY KEY CLUSTERED ([idproduit] ASC)
	FOREIGN KEY ([idcat]) REFERENCES [dbo].[CategorieProduit] ([idcat])
);

CREATE TABLE [dbo].[LigneStockPharma] (
    [idstockph] INT      NOT NULL,
    [idpharma]  SMALLINT NOT NULL,
    [idstock]   INT      NOT NULL,
    [qtestock]  INT      NOT NULL,
    PRIMARY KEY CLUSTERED ([idstockph] ASC),
    FOREIGN KEY ([idstock]) REFERENCES [dbo].[LigneStock] ([idstock]),
    FOREIGN KEY ([idpharma]) REFERENCES [dbo].[Pharmacie] ([idpharma])
);

CREATE TABLE [dbo].[LigneAppro] (
    [idappro]    INT             NOT NULL,
    [date_appro]   DATE            NOT NULL,
    [idcom]    INT             NOT NULL,
    [qteappro]   SMALLINT        NOT NULL,
    [qteajoute]  SMALLINT        NOT NULL,
	[prix_achat] NUMERIC (12, 2) NULL,
    [taux]       NUMERIC (5, 2)  NULL,
	[observation]       varchar (100)  NULL,
    PRIMARY KEY CLUSTERED ([idappro] ASC),
    FOREIGN KEY ([idcom]) REFERENCES [dbo].[LigneCommande] ([idcom])
);

--Recréer

CREATE TABLE [dbo].[CommandePharma] (
    [idcomph]    INT      NOT NULL,
    [idstockph] INT      NOT NULL,
    [date_com]     DATE     NOT NULL,
    [qtecom]   SMALLINT NOT NULL,
    PRIMARY KEY CLUSTERED ([idcomph] ASC),
    FOREIGN KEY ([idstockph]) REFERENCES [dbo].[LigneStockPharma] ([idstockph])
);

CREATE TABLE [dbo].[ApproPharma] (
    [idapproph]    INT      NOT NULL,
	[date_appro]     DATE     NOT NULL,
    [idcomph] INT      NOT NULL,
    [qteservie]     SMALLINT NOT NULL,
    PRIMARY KEY CLUSTERED ([idapproph] ASC),
    FOREIGN KEY ([idcomph]) REFERENCES [dbo].[CommandePharma] ([idcomph])
);

CREATE TABLE [dbo].[SortiePharma] (
    [idsortie]      INT           NOT NULL,
    [date_jour]     SMALLDATETIME NOT NULL,
    [idstockph] INT           NOT NULL,
	[qte_dem]      SMALLINT           NOT NULL,
    [qteservie]      SMALLINT         NOT NULL,
    [motif]         VARCHAR (30) NOT NULL,
    [idposte]       SMALLINT     NULL,
    PRIMARY KEY CLUSTERED ([idsortie] ASC),
    FOREIGN KEY ([idstockph]) REFERENCES [dbo].[LigneStockPharma] ([idstockph])
);
--créer
CREATE TABLE [dbo].[SortieStock] (
    [idsortie]      INT           NOT NULL,
    [date_jour]    SMALLDATETIME NOT NULL,
    [idstock]      INT           NOT NULL,
	[qte_dem]      SMALLINT           NOT NULL,
    [qteservie]    SMALLINT         NOT NULL,
    [motif]         VARCHAR (30) NOT NULL,
    [idposte]       SMALLINT     NULL,
    PRIMARY KEY CLUSTERED ([idsortie] ASC),
    FOREIGN KEY ([idstock]) REFERENCES [dbo].[LigneStock] ([idstock])
);