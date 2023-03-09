CREATE DATABASE SSMDB;

USE SSMDB;

--CREATION DES TABLES


CREATE TABLE [dbo].[CommandePharma] (
    [idcommande]    INT      NOT NULL,
    [idstockpharma] INT      NOT NULL,
    [date_jour]     DATE     NOT NULL,
    [qtecommande]   SMALLINT NOT NULL,
    [qteservie]     SMALLINT NOT NULL,
    PRIMARY KEY CLUSTERED ([idcommande] ASC),
    FOREIGN KEY ([idstockpharma]) REFERENCES [dbo].[LigneStockPharma] ([idstockpharma])
);

CREATE TABLE [dbo].[Compte] (
    [numcompte]      VARCHAR (10)    NOT NULL,
    [libellecompte]  VARCHAR (120)   NOT NULL,
    [debit]          NUMERIC (18, 2) NOT NULL,
    [credit]         NUMERIC (18, 2) NOT NULL,
    [soldeanterieur] NUMERIC (18, 2) NULL,
    [ref]            VARCHAR (3)     NULL,
    [categorie]      VARCHAR (2)     NULL,
    PRIMARY KEY CLUSTERED ([numcompte] ASC)
);

CREATE TABLE [dbo].[Consultation] (
    [idconsultation]    INT          NOT NULL,
    [date_consultation] DATE         NOT NULL,
    [idmedecin]         SMALLINT     NOT NULL,
    [repondant]         VARCHAR (75) NULL,
    [lienrepondnant]    VARCHAR (75) NULL,
    [idprise]           INT          NOT NULL,
    PRIMARY KEY CLUSTERED ([idconsultation] ASC),
    FOREIGN KEY ([idmedecin]) REFERENCES [dbo].[Medecin] ([idmedecin]),
    FOREIGN KEY ([idpatient]) REFERENCES [dbo].[Patient] ([idpatient]),
    FOREIGN KEY ([idprise]) REFERENCES [dbo].[PriseSigneVitaux] ([idprise])
);

CREATE TABLE [dbo].[Date_operation] (
    [date_operation] DATE NOT NULL,
    [taux]           INT  NOT NULL,
    PRIMARY KEY CLUSTERED ([date_operation] ASC)
);

CREATE TABLE [dbo].[Depense] (
    [iddepense]      INT             NOT NULL,
    [numcompte]      VARCHAR (10)    NOT NULL,
    [date_operation] DATE            NOT NULL,
    [beneficiaire]   VARCHAR (75)    NOT NULL,
    [motifdepense]   VARCHAR (100)   NOT NULL,
    [montant]        NUMERIC (18, 2) NOT NULL,
    [monnaie]        VARCHAR (3)     NOT NULL,
    [refrequisition] VARCHAR (30)    NOT NULL,
    PRIMARY KEY CLUSTERED ([iddepense] ASC),
    FOREIGN KEY ([numcompte]) REFERENCES [dbo].[Compte] ([numcompte])
);

CREATE TABLE [dbo].[Entreprise] (
    [identreprise]  SMALLINT     NOT NULL,
    [nomentreprise] VARCHAR (30) NOT NULL,
    [contacts]      VARCHAR (75) NOT NULL,
    [numcompte]     VARCHAR (10) NOT NULL,
    PRIMARY KEY CLUSTERED ([identreprise] ASC),
    FOREIGN KEY ([numcompte]) REFERENCES [dbo].[Compte] ([numcompte])
);

CREATE TABLE [dbo].[EntrepriseTypeAbonne] (
    [idtypeabonne] SMALLINT NOT NULL,
    [identreprise] SMALLINT NOT NULL,
    FOREIGN KEY ([idtypeabonne]) REFERENCES [dbo].[TypeAbonne] ([idtypeabonne]) ON DELETE CASCADE,
    FOREIGN KEY ([identreprise]) REFERENCES [dbo].[Entreprise] ([identreprise]) ON DELETE CASCADE
);

CREATE TABLE [dbo].[ExamenPhysique] (
    [idexamen] INT          NOT NULL,
    [examen]   VARCHAR (15) NOT NULL,
    PRIMARY KEY CLUSTERED ([idexamen] ASC)
);

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
    [idappro]        INT             NOT NULL,
    [date_dem]       DATE            NOT NULL,
    [idautreproduit] SMALLINT        NOT NULL,
    [prix_achat]     NUMERIC (12, 2) NULL,
    [qtedem]         INT             NOT NULL,
    [qteappro]       INT             NOT NULL,
    [qteajoute]      INT             NOT NULL,
    PRIMARY KEY CLUSTERED ([idappro] ASC),
    FOREIGN KEY ([idautreproduit]) REFERENCES [dbo].[ProduitAutreStock] ([idautreproduit])
);

CREATE TABLE [dbo].[LigneStock] (
    [idstock]      INT             NOT NULL,
    [idproduit]    SMALLINT        NOT NULL,
    [forme]        VARCHAR (15)    NOT NULL,
    [dosage]       VARCHAR (20)    NOT NULL,
    [numlot]       VARCHAR (20)    NULL,
    [expiration]   VARCHAR (10)    NULL,
    [prixunitaire] NUMERIC (12, 2) NOT NULL,
    [prix_abonne]  NUMERIC (12, 2) NOT NULL,
    [qtestock]     INT             NOT NULL,
    [CMM]          INT             NOT NULL,
    PRIMARY KEY CLUSTERED ([idstock] ASC),
    FOREIGN KEY ([idproduit]) REFERENCES [dbo].[Produit] ([idproduit])
);

CREATE TABLE [dbo].[LigneStockPharma] (
    [idstockpharma]  INT      NOT NULL,
    [idpharma]       SMALLINT NOT NULL,
    [idstock]        INT      NOT NULL,
    [qtestockpharma] INT      NOT NULL,
    PRIMARY KEY CLUSTERED ([idstockpharma] ASC),
    FOREIGN KEY ([idpharma]) REFERENCES [dbo].[Pharmacie] ([idpharma]),
    FOREIGN KEY ([idstock]) REFERENCES [dbo].[LigneStock] ([idstock])
);

CREATE TABLE [dbo].[LigneUtilisation] (
    [idutilisation] INT         NOT NULL,
    [date_jour]     DATE        NOT NULL,
    [periode]       VARCHAR (5) NOT NULL,
    [idstockpharma] INT         NOT NULL,
    [stock]         SMALLINT    NOT NULL,
    [qteajoute]     SMALLINT    NOT NULL,
    [utilisation]   SMALLINT    NOT NULL,
    [perte]         SMALLINT    NOT NULL,
    PRIMARY KEY CLUSTERED ([idutilisation] ASC),
    FOREIGN KEY ([idstockpharma]) REFERENCES [dbo].[LigneStockPharma] ([idstockpharma])
);

CREATE TABLE [dbo].[Maladie] (
    [idmaladie]  SMALLINT     NOT NULL,
    [nommaladie] VARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([idmaladie] ASC)
);

CREATE TABLE [dbo].[MaladieConsultation] (
    [idmaladie]      SMALLINT     NOT NULL,
    [idconsultation] INT          NOT NULL,
    [observation]    VARCHAR (50) NOT NULL,
    FOREIGN KEY ([idconsultation]) REFERENCES [dbo].[Consultation] ([idconsultation]),
    FOREIGN KEY ([idmaladie]) REFERENCES [dbo].[Maladie] ([idmaladie])
);

CREATE TABLE [dbo].[Medecin] (
    [idmedecin]   SMALLINT     NOT NULL,
    [nommedecin]  VARCHAR (75) NOT NULL,
    [numordre]    VARCHAR (15) NOT NULL,
    [telmedecin]  VARCHAR (15) NOT NULL,
    [utilisateur] VARCHAR (10) NULL,
    PRIMARY KEY CLUSTERED ([idmedecin] ASC)
);

CREATE TABLE [dbo].[Message] (
    [idmessage]    BIGINT        NOT NULL,
    [expediteur]   SMALLINT      NOT NULL,
    [destinataire] SMALLINT      NOT NULL,
    [objet]        VARCHAR (100) NOT NULL,
    [msg]          VARCHAR (255) NOT NULL,
    [date_jour]    DATE          NOT NULL,
    [heure]        TIME (7)      NOT NULL,
    [statutmsg]    VARCHAR (8)   NOT NULL,
    PRIMARY KEY CLUSTERED ([idmessage] ASC),
    FOREIGN KEY ([expediteur]) REFERENCES [dbo].[Utilisateur] ([id]),
    FOREIGN KEY ([destinataire]) REFERENCES [dbo].[Utilisateur] ([id])
);


CREATE TABLE [dbo].[Operation] (
    [idoperation]    INT           NOT NULL,
    [date_operation] DATE          NOT NULL,
    [libelle]        VARCHAR (100) NOT NULL,
    [numpiece]       VARCHAR (30)  NOT NULL,
    [idtypejournal]  SMALLINT      NOT NULL,
    [idrecette]      INT           NULL,
    [iddepense]      INT           NULL,
    PRIMARY KEY CLUSTERED ([idoperation] ASC),
    FOREIGN KEY ([idtypejournal]) REFERENCES [dbo].[TypeJournal] ([idtypejournal]),
    FOREIGN KEY ([date_operation]) REFERENCES [dbo].[Date_operation] ([date_operation]),
    FOREIGN KEY ([idrecette]) REFERENCES [dbo].[Recette] ([idrecette]),
    FOREIGN KEY ([iddepense]) REFERENCES [dbo].[Depense] ([iddepense])
);

CREATE TABLE [dbo].[OperationCompte] (
    [id]            INT             NOT NULL,
    [idoperation]   INT             NOT NULL,
    [numcompte]     VARCHAR (10)    NOT NULL,
    [montantdebit]  NUMERIC (18, 2) NULL,
    [montantcredit] NUMERIC (18, 2) NULL,
    PRIMARY KEY CLUSTERED ([id] ASC),
    FOREIGN KEY ([numcompte]) REFERENCES [dbo].[Compte] ([numcompte]),
    FOREIGN KEY ([idoperation]) REFERENCES [dbo].[Operation] ([idoperation])
);

CREATE TABLE [dbo].[Patient] (
    [idpatient]    INT          NOT NULL,
    [noms]         VARCHAR (75) NOT NULL,
    [sexe]         VARCHAR (1)  NOT NULL,
    [age]          VARCHAR (20) NOT NULL,
    [adresse]      VARCHAR (75) NOT NULL,
    [situation]    VARCHAR (3)  NOT NULL,
    [telephone]    VARCHAR (15) NULL,
    [pers_contact] VARCHAR (75) NULL,
    [tel_contact]  VARCHAR (15) NULL,
    [idtype]       SMALLINT     NOT NULL,
    [idtypeabonne] SMALLINT     NULL,
    [identreprise] SMALLINT     NULL,
    [num_service]  VARCHAR (15) NULL,
    PRIMARY KEY CLUSTERED ([idpatient] ASC),
    FOREIGN KEY ([idtype]) REFERENCES [dbo].[TypePatient] ([idtype]),
    FOREIGN KEY ([idtypeabonne]) REFERENCES [dbo].[TypeAbonne] ([idtypeabonne]),
    FOREIGN KEY ([identreprise]) REFERENCES [dbo].[Entreprise] ([identreprise])
);

CREATE TABLE [dbo].[Payement] (
    [idpayement]     INT             NOT NULL,
    [montant]        NUMERIC (12, 2) NOT NULL,
    [date_operation] DATE            NOT NULL,
    [idpayeur]       INT             NOT NULL,
    [idrecette]      INT             NOT NULL,
    PRIMARY KEY CLUSTERED ([idpayement] ASC),
    FOREIGN KEY ([idrecette]) REFERENCES [dbo].[Recette] ([idrecette]),
    FOREIGN KEY ([idpayeur]) REFERENCES [dbo].[Payeur] ([idpayeur]),
    FOREIGN KEY ([date_operation]) REFERENCES [dbo].[Date_operation] ([date_operation])
);

CREATE TABLE [dbo].[Payeur] (
    [idpayeur]  INT          NOT NULL,
    [nompayeur] VARCHAR (75) NULL,
    [contacts]  VARCHAR (75) NULL,
    [idpatient] INT          NULL,
    PRIMARY KEY CLUSTERED ([idpayeur] ASC),
    FOREIGN KEY ([idpatient]) REFERENCES [dbo].[Patient] ([idpatient])
);

CREATE TABLE [dbo].[Pharmacie] (
    [idpharma]    SMALLINT NOT NULL,
    [designation] INT      NOT NULL,
    PRIMARY KEY CLUSTERED ([idpharma] ASC)
);

CREATE TABLE [dbo].[PrescriptionProduit] (
    [idconsultation] INT           NOT NULL,
    [idstock]        INT           NOT NULL,
    [posologie]      VARCHAR (30)  NOT NULL,
    [quantite]       SMALLINT      NOT NULL,
    [suspension]     VARCHAR (150) NULL,
    FOREIGN KEY ([idconsultation]) REFERENCES [dbo].[Consultation] ([idconsultation]),
    FOREIGN KEY ([idstock]) REFERENCES [dbo].[LigneStock] ([idstock])
);

CREATE TABLE [dbo].[PrescriptionService] (
    [idconsultation] INT           NOT NULL,
    [idservice]      SMALLINT      NOT NULL,
    [categorie]      VARCHAR (30)  NOT NULL,
    [observation]    VARCHAR (100) NULL,
    FOREIGN KEY ([idconsultation]) REFERENCES [dbo].[Consultation] ([idconsultation]),
    FOREIGN KEY ([idservice]) REFERENCES [dbo].[Service] ([idservice])
);

CREATE TABLE [dbo].[PriseSigneVitaux] (
    [idprise]    INT      NOT NULL,
    [date_prise] DATE     NOT NULL,
    [idpatient]  INT      NOT NULL,
    [idrecette]  INT      NOT NULL,
    [idmedecin]  SMALLINT NOT NULL,
    PRIMARY KEY CLUSTERED ([idprise] ASC),
    FOREIGN KEY ([idpatient]) REFERENCES [dbo].[Patient] ([idpatient]),
    FOREIGN KEY ([idrecette]) REFERENCES [dbo].[Recette] ([idrecette]),
    FOREIGN KEY ([idmedecin]) REFERENCES [dbo].[Medecin] ([idmedecin])
);

CREATE TABLE [dbo].[Produit] (
    [idproduit]  SMALLINT     NOT NULL,
    [nomproduit] VARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([idproduit] ASC)
);

CREATE TABLE [dbo].[ProduitAutreStock] (
    [idautreproduit]  SMALLINT     NOT NULL,
    [numcompte]       VARCHAR (10) NOT NULL,
    [nomautreproduit] VARCHAR (50) NOT NULL,
    [unite]           VARCHAR (10) NOT NULL,
    [qtestock]        INT          NOT NULL,
    [CMM]             INT          NOT NULL,
    [descriptif]      VARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([idautreproduit] ASC),
    FOREIGN KEY ([numcompte]) REFERENCES [dbo].[Compte] ([numcompte])
);

CREATE TABLE [dbo].[Recette] (
    [idrecette]      INT          NOT NULL,
    [statut_facture] VARCHAR (8)  NOT NULL,
    [date_operation] DATE         NOT NULL,
    [type_payeur]    VARCHAR (10) NULL,
    [idpayeur]       INT          NOT NULL,
    [categorie]      VARCHAR (8)  NOT NULL,
    [statut_caisse]  VARCHAR (2)  NULL,
    PRIMARY KEY CLUSTERED ([idrecette] ASC),
    FOREIGN KEY ([date_operation]) REFERENCES [dbo].[Date_operation] ([date_operation]),
    FOREIGN KEY ([idpayeur]) REFERENCES [dbo].[Payeur] ([idpayeur])
);

CREATE TABLE [dbo].[RecetteProduit] (
    [idrecette]     INT         NOT NULL,
    [idstock]       INT         NOT NULL,
    [qtevendue]     INT         NOT NULL,
    [servi]         VARCHAR (2) NULL,
    [idutilisateur] SMALLINT    NULL,
    CONSTRAINT [FK_R_RP] FOREIGN KEY ([idrecette]) REFERENCES [dbo].[Recette] ([idrecette]) ON DELETE CASCADE,
    FOREIGN KEY ([idstock]) REFERENCES [dbo].[LigneStock] ([idstock]),
    FOREIGN KEY ([idutilisateur]) REFERENCES [dbo].[Utilisateur] ([id])
);

CREATE TABLE [dbo].[RecetteService] (
    [idrecette]     INT         NOT NULL,
    [idservice]     SMALLINT    NOT NULL,
    [servi]         VARCHAR (2) NULL,
    [idutilisateur] SMALLINT    NULL,
    CONSTRAINT [FK_R_RS] FOREIGN KEY ([idrecette]) REFERENCES [dbo].[Recette] ([idrecette]) ON DELETE CASCADE,
    FOREIGN KEY ([idservice]) REFERENCES [dbo].[Service] ([idservice]),
    FOREIGN KEY ([idutilisateur]) REFERENCES [dbo].[Utilisateur] ([id])
);

CREATE TABLE [dbo].[Renseignement] (
    [id]             INT          NOT NULL,
    [label]          VARCHAR (15) NOT NULL,
    [idconsultation] INT          NOT NULL,
    [libelle]        VARCHAR (90) NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC),
    FOREIGN KEY ([idconsultation]) REFERENCES [dbo].[Consultation] ([idconsultation])
);

CREATE TABLE [dbo].[Service] (
    [idservice]     SMALLINT        NOT NULL,
    [nomservice]    VARCHAR (75)    NOT NULL,
    [prixservice]   NUMERIC (12, 2) NOT NULL,
    [prix_abonne]   NUMERIC (12, 2) NOT NULL,
    [numcompte]     VARCHAR (10)    NOT NULL,
    [specification] VARCHAR (70)    NULL,
    PRIMARY KEY CLUSTERED ([idservice] ASC),
    FOREIGN KEY ([numcompte]) REFERENCES [dbo].[Compte] ([numcompte])
);

CREATE TABLE [dbo].[ServiceDemandeur] (
    [idposte]  SMALLINT     NOT NULL,
    [nomposte] VARCHAR (30) NOT NULL,
    PRIMARY KEY CLUSTERED ([idposte] ASC)
);

CREATE TABLE [dbo].[SigneVital] (
    [idsigne]  SMALLINT     NOT NULL,
    [nomsigne] VARCHAR (30) NOT NULL,
	[unite] VARCHAR (20) NOT NULL,
    PRIMARY KEY CLUSTERED ([idsigne] ASC)
);

CREATE TABLE [dbo].[SortieAutreStock] (
    [idsortieautre]  INT           NOT NULL,
    [date_jour]      SMALLDATETIME NOT NULL,
    [idautreproduit] SMALLINT      NOT NULL,
    [quantite]       INT           NOT NULL,
    [idposte]        INT           NULL,
    PRIMARY KEY CLUSTERED ([idsortieautre] ASC),
    FOREIGN KEY ([idautreproduit]) REFERENCES [dbo].[ProduitAutreStock] ([idautreproduit])
);

CREATE TABLE [dbo].[SortiePharma] (
    [idsortie]      INT           NOT NULL,
    [date_jour]     SMALLDATETIME NOT NULL,
    [idstockpharma] INT           NOT NULL,
    [quantite]      INT           NOT NULL,
    [motif]         VARCHAR (30)  NOT NULL,
    [idposte]       SMALLINT      NULL,
    PRIMARY KEY CLUSTERED ([idsortie] ASC),
    FOREIGN KEY ([idstockpharma]) REFERENCES [dbo].[LigneStockPharma] ([idstockpharma])
);

CREATE TABLE [dbo].[TypeAbonne] (
    [idtypeabonne] SMALLINT     NOT NULL,
    [typeabonne]   VARCHAR (20) NOT NULL,
    PRIMARY KEY CLUSTERED ([idtypeabonne] ASC)
);

CREATE TABLE [dbo].[TypeJournal] (
    [idtypejournal] SMALLINT     NOT NULL,
    [typejournal]   VARCHAR (50) NOT NULL,
    [compte]        VARCHAR (10) NULL,
    PRIMARY KEY CLUSTERED ([idtypejournal] ASC)
);

CREATE TABLE [dbo].[TypePatient] (
    [idtype]  SMALLINT     NOT NULL,
    [nomtype] VARCHAR (20) NOT NULL,
    PRIMARY KEY CLUSTERED ([idtype] ASC)
);

CREATE TABLE [dbo].[Utilisateur] (
    [id]            SMALLINT     NOT NULL,
    [utilisateur]   VARCHAR (10) NOT NULL,
    [motdepasse]    VARCHAR (10) NOT NULL,
    [poste]         VARCHAR (10) NOT NULL,
    [specification] VARCHAR (10) NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
);

CREATE TABLE [dbo].[ValeurExamenPhysique] (
    [idconsultation] INT          NOT NULL,
    [idexamen]       INT          NOT NULL,
    [valeur]         VARCHAR (30) NOT NULL,
    FOREIGN KEY ([idconsultation]) REFERENCES [dbo].[Consultation] ([idconsultation]),
    FOREIGN KEY ([idexamen]) REFERENCES [dbo].[ExamenPhysique] ([idexamen])
);

CREATE TABLE [dbo].[ValeurSigneVitaux] (
    [idprise] INT          NOT NULL,
    [idsigne] SMALLINT     NOT NULL,
    [valeur]  VARCHAR (30) NOT NULL,
    FOREIGN KEY ([idsigne]) REFERENCES [dbo].[SigneVital] ([idsigne]),
    FOREIGN KEY ([idprise]) REFERENCES [dbo].[PriseSigneVitaux] ([idprise])
);