CREATE TABLE BonDepense(
numbon int primary key,
date_operation DATE NOT NULL,
beneficiaire VARCHAR(75) NOT NULL,
refrequisition VARCHAR(30) NOT NULL
)

ALTER TABLE BonDepense 
ADD CONSTRAINT FK_DateBonDepense
FOREIGN KEY (date_operation) REFERENCES Date_operation(date_operation) ON UPDATE CASCADE

ALTER TABLE Depense 
ADD numbon INT NULL

ALTER TABLE Depense 
ADD CONSTRAINT FK_Bon 
FOREIGN KEY (numbon) 
REFERENCES BonDepense(numbon) ON UPDATE CASCADE

ALTER TABLE Depense ADD CONSTRAINT FK_Date_ FOREIGN KEY ([date_operation]) REFERENCES [dbo].[Date_operation] ([date_operation])

ALTER TABLE Depense ADD CONSTRAINT FK_Compte FOREIGN KEY ([numcompte]) REFERENCES [dbo].[Compte] ([numcompte])

ALTER TABLE Depense DROP COLUMN date_operation, beneficiaire, refrequisition

CREATE TABLE [dbo].[Operation] (
    [idoperation]    INT           NOT NULL,
    [date_operation] DATE          NOT NULL,
    [libelle]        VARCHAR (250) NOT NULL,
    [numpiece]       VARCHAR (30)  NOT NULL,
    [idtypejournal]  SMALLINT      NOT NULL,
    [idrecette]      INT           NULL,
	[numbon] INT NULL,
    PRIMARY KEY CLUSTERED ([idoperation] ASC),
    FOREIGN KEY ([idtypejournal]) REFERENCES [dbo].[TypeJournal] ([idtypejournal]),
    FOREIGN KEY ([date_operation]) REFERENCES [dbo].[Date_operation] ([date_operation]),
    FOREIGN KEY ([idrecette]) REFERENCES [dbo].[Recette] ([idrecette]) ON UPDATE CASCADE,
	CONSTRAINT FK_depense FOREIGN KEY ([numbon]) REFERENCES [dbo].[BonDepense] ([numbon]) ON UPDATE CASCADE,
);
