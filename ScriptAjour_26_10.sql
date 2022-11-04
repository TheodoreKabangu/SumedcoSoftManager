
--Sur la BD SSM_Malade

CREATE TABLE [dbo].[Rendezvous] (
    [idrendezvous]    INT          NOT NULL,
    [date_rendezvous] date NOT NULL,
    [heure]           time(4)  NOT NULL,
    [idconsultation]  INT          NOT NULL,
    PRIMARY KEY CLUSTERED ([idrendezvous] ASC),
    FOREIGN KEY ([idconsultation]) REFERENCES [dbo].[Consultation] ([idconsultation])
);

CREATE TABLE [dbo].[Prescription] (
    [idpresc]      INT           NOT NULL,
    [produit] VARCHAR (100) NOT NULL,
	[qteprescrite] SMALLINT NOT NULL,
    [detail] VARCHAR (100) NOT NULL,
    [idconsultation] INT NOT NULL,
    FOREIGN KEY ([idconsultation]) REFERENCES [dbo].[Consultation] ([idconsultation])
);