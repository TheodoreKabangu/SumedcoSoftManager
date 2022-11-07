CREATE TABLE [dbo].[TypePatient] (
    [idtype]  SMALLINT     NOT NULL,
    [nomtype] VARCHAR (20) NOT NULL,
    PRIMARY KEY CLUSTERED ([idtype] ASC)
);

CREATE TABLE [dbo].[Patient] (
    [idpatient]        INT           NOT NULL,
    [date_entree]      SMALLDATETIME NOT NULL,
    [noms]             VARCHAR (75)  NOT NULL,
    [sexe]             VARCHAR (1)   NOT NULL,
    [anneenaiss]       SMALLINT      NOT NULL,
    [adresse]          VARCHAR (75)  NOT NULL,
    [telephone]        VARCHAR (15)  NULL,
    [personnecontact]  VARCHAR (75)  NULL,
    [telephonecontact] VARCHAR (15)  NULL,
    [idtype]           SMALLINT      NOT NULL,
    PRIMARY KEY CLUSTERED ([idpatient] ASC),
    FOREIGN KEY ([idtype]) REFERENCES [dbo].[TypePatient] ([idtype])
);

CREATE TABLE [dbo].[Medecin] (
    [idmedecin]  SMALLINT     NOT NULL,
    [nommedecin] VARCHAR (75) NOT NULL,
    [numordre]   VARCHAR (15) NOT NULL,
    [telmedecin] VARCHAR (15) NOT NULL,
    PRIMARY KEY CLUSTERED ([idmedecin] ASC)
);

CREATE TABLE [dbo].[Consultation] (
    [idconsultation]    INT           NOT NULL,
    [date_consultation] SMALLDATETIME NOT NULL,
    [type]              VARCHAR (10)  NOT NULL,
    [idmedecin]         SMALLINT      NOT NULL,
    [idpatient]         INT           NOT NULL,
    [repondant]         VARCHAR (75)  NULL,
    [lienrepondnant]    VARCHAR (75)  NULL,
    PRIMARY KEY CLUSTERED ([idconsultation] ASC),
    FOREIGN KEY ([idmedecin]) REFERENCES [dbo].[Medecin] ([idmedecin]),
    FOREIGN KEY ([idpatient]) REFERENCES [dbo].[Patient] ([idpatient])
);

CREATE TABLE [dbo].[ResultatExamen] (
    [idresultat]     INT          NOT NULL,
    [idconsultation] INT          NOT NULL,
    [nomexamen]      VARCHAR (75) NOT NULL,
    [resultat]       VARCHAR (75) NOT NULL,
    FOREIGN KEY ([idconsultation]) REFERENCES [dbo].[Consultation] ([idconsultation])
);

CREATE TABLE [dbo].[Renseignement] (
    [id]             INT          NOT NULL,
    [label]          VARCHAR (15) NOT NULL,
    [idconsultation] INT          NOT NULL,
    [libelle]        VARCHAR (90) NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC),
    FOREIGN KEY ([idconsultation]) REFERENCES [dbo].[Consultation] ([idconsultation])
);

CREATE TABLE [dbo].[Prescription] (
    [idprescription]      INT          NOT NULL,
    [libelleprescription] VARCHAR (50) NOT NULL,
    [idconsultation]      INT          NOT NULL,
    FOREIGN KEY ([idconsultation]) REFERENCES [dbo].[Consultation] ([idconsultation])
);

CREATE TABLE [dbo].[SigneVital] (
    [idsigne]  SMALLINT     NOT NULL,
    [nomsigne] VARCHAR (30) NOT NULL,
    PRIMARY KEY CLUSTERED ([idsigne] ASC)
);

CREATE TABLE [dbo].[SigneVitalConsultation] (
    [id]             INT          NOT NULL,
    [idconsultation] INT          NOT NULL,
    [idsigne]        SMALLINT     NOT NULL,
    [valeur]         VARCHAR (20) NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC),
    FOREIGN KEY ([idconsultation]) REFERENCES [dbo].[Consultation] ([idconsultation]),
    FOREIGN KEY ([idsigne]) REFERENCES [dbo].[SigneVital] ([idsigne])
);

CREATE TABLE [dbo].[Rendezvous] (
    [idrendezvous]    INT          NOT NULL,
    [date_rendezvous] VARCHAR (10) NOT NULL,
    [heure]           VARCHAR (6)  NOT NULL,
    [idconsultation]  INT          NOT NULL,
    PRIMARY KEY CLUSTERED ([idrendezvous] ASC),
    FOREIGN KEY ([idconsultation]) REFERENCES [dbo].[Consultation] ([idconsultation])
);

CREATE TABLE [dbo].[MedecinMessage] (
    [idmessage]    BIGINT        NOT NULL,
    [expediteur]   SMALLINT      NOT NULL,
    [destinataire] SMALLINT      NOT NULL,
    [objet]        VARCHAR (100) NOT NULL,
    [msg]          VARCHAR (255) NOT NULL,
    [statutmsg]    VARCHAR (2)   NULL,
    PRIMARY KEY CLUSTERED ([idmessage] ASC),
    FOREIGN KEY ([expediteur]) REFERENCES [dbo].[Medecin] ([idmedecin]),
    FOREIGN KEY ([destinataire]) REFERENCES [dbo].[Medecin] ([idmedecin])
);

CREATE TABLE [dbo].[Maladie] (
    [idmaladie]  SMALLINT     NOT NULL,
    [nommaladie] VARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([idmaladie] ASC)
);

CREATE TABLE [dbo].[MaladieConsultation] (
    [id]             SMALLINT     NOT NULL,
    [idmaladie]      SMALLINT     NOT NULL,
    [idconsultation] INT          NOT NULL,
    [observation]    VARCHAR (50) NOT NULL,
    FOREIGN KEY ([idconsultation]) REFERENCES [dbo].[Consultation] ([idconsultation]),
    FOREIGN KEY ([idmaladie]) REFERENCES [dbo].[Maladie] ([idmaladie])
);

CREATE TABLE [dbo].[LigneAgendaPatient] (
    [id]           SMALLINT     NOT NULL,
    [cas]          VARCHAR (10) NOT NULL,
    [idpatient]    INT          NOT NULL,
    [idmedecin]    SMALLINT     NOT NULL,
    [caisse]       VARCHAR (2)  NULL,
    [signev]       VARCHAR (2)  NULL,
    [consultation] VARCHAR (2)  NULL,
    PRIMARY KEY CLUSTERED ([id] ASC),
    FOREIGN KEY ([idmedecin]) REFERENCES [dbo].[Medecin] ([idmedecin]),
    FOREIGN KEY ([idpatient]) REFERENCES [dbo].[Patient] ([idpatient])
);

CREATE TABLE [dbo].[LigneSigneVital] (
    [id]            SMALLINT     NOT NULL,
    [idligneagenda] SMALLINT     NOT NULL,
    [idsigne]       SMALLINT     NOT NULL,
    [valeur]        VARCHAR (20) NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC),
    FOREIGN KEY ([idsigne]) REFERENCES [dbo].[SigneVital] ([idsigne]),
    FOREIGN KEY ([idligneagenda]) REFERENCES [dbo].[LigneAgendaPatient] ([id])
);

