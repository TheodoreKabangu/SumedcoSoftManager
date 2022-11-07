CREATE TABLE [dbo].[LotProduit] (
    [numlot]  VARCHAR (30) NOT NULL,
    [dateExp] VARCHAR (10) NOT NULL,
	[idproduit] INT NOT NULL foreign key(idproduit) references Produit(idproduit)
);

create table Produit(idproduit int primary key, nomproduit varchar(30) not null, dosage varchar(30) not null, 
prixunitaire int not null, stockdispo bigint not null, CMM bigint not null);

CREATE TABLE [dbo].[Condition] (
    [idcondition]      INT          NOT NULL,
    [libellecondition] VARCHAR (30) NOT NULL,
    PRIMARY KEY CLUSTERED ([idcondition] ASC)
);

CREATE TABLE [dbo].[Forme] (
    [idforme]      INT          NOT NULL,
    [libelleforme] VARCHAR (30) NOT NULL,
    PRIMARY KEY CLUSTERED ([idforme] ASC)
);

create table ProduitFormeCondition(idproduit int not null foreign key(idproduit) references Produit(idproduit),
 idforme int not null foreign key(idforme) references Forme(idforme),
  idcondition int not null foreign key(idcondition) references Condition(idcondition), stockdispo bigint not null);

create table Consommation(dateconsom varchar(10) primary key);

create table UtilisationProduit(idproduit int not null foreign key(idproduit) references Produit(idproduit),
dateconsom varchar(10) not null foreign key(dateconsom) references Consommation(dateconsom),
solde1 int not null, qtelivre1 int not null, valeur1 bigint not null, observation1 varchar(30) not null,
solde2 int not null, qtelivre2 int not null, valeur2 bigint not null, observation2 varchar(30) not null);

create table Appro(idappro int primary key, dateconsom varchar(10) not null);

create table ApproProduit(idappro int not null foreign key(idappro) references Appro(idappro),
idproduit int not null foreign key(idproduit) references Produit(idproduit),
qteappro int not null, observationappro varchar(30) not null);

create table Requisition(idrequisition int primary key, daterequisition varchar(10) not null);

create table Commande(idcommande int primary key, datecommande varchar(10) not null);

create table RequisitionProduit(idrequisition int not null foreign key(idrequisition) references Requisition(idrequisition),
idproduit int not null foreign key(idproduit) references Produit(idproduit),
qterequise int not null);

create table CommandeProduit(idcommande int not null foreign key(idcommande) references Commande(idcommande),
idproduit int not null foreign key(idproduit) references Produit(idproduit),
qtecommande int not null, observationcommade varchar(30) not null);

create table Abonne(idabonne int primary key, nomabonne varchar(30) not null, adresse varchar(50) not null, 
dateabonnement varchar(10));

create table Patient(idpatient int primary key, noms varchar(50) not null, sexe varchar(1) not null, 
anneenaiss int not null, adresse varchar(50) not null, telephone varchar(15), personnecontact varchar(50), 
telephonecontact varchar(15), idabonne int foreign key(idabonne) references Abonne(idabonne));

create table ServiceDemande(idservice int primary key, mnemoservice varchar(10), nomservice varchar(50) not null,
prixservice int not null);

create table Medecin(idmedecin int primary key, nomsmedecin varchar(50) not null);

create table ServicePatient(id int not null, idpatient int not null foreign key(idpatient) references Patient(idpatient),
idservice int not null foreign key(idservice) references ServiceDemande(idservice));

create table Consultation(idconsultation int primary key, idpatient int not null foreign key(idpatient) references Patient(idpatient),
idmedecin int not null foreign key(idmedecin) references Medecin(idmedecin),dateconsultation varchar(10) not null,
tensionA int not null, poids int not null, temperature varchar(10) not null, pression varchar(10) not null, 
respiration varchar(10) not null);

create table LignePlainte(idplainte int primary key, signe varchar(50) not null, duree varchar(50) not null, intensite varchar(50) not null,
idconsultation int not null foreign key(idconsultation) references Consultation(idconsultation));

create table LignePrescription(idprescription int primary key, libelleprescription varchar(50) not null,
idconsultation int not null foreign key(idconsultation) references Consultation(idconsultation));