SELECT idpayement, DATEDIFF(day,date_operation, '22/01/2023') as NbJours FROM Payement 

CREATE TABLE [dbo].[Traitement] (
    [idtraitement]      INT      NOT NULL,
	[idhospi]      INT      NOT NULL,
    [idconsultation] INT           NOT NULL,
	[date_debut] DATE           NOT NULL,
	[date_sortie] DATE          NULL,   
    [observation]    VARCHAR (200) NULL,
	PRIMARY KEY ([idhospi] ASC),
    FOREIGN KEY ([idconsultation]) REFERENCES [dbo].[Consultation] ([idconsultation])
);
