CREATE PROCEDURE calcul_total2
(	@idabonne int,
	@numcompte varchar(10),
	@dateDe date,
	@dateA date,
	@val numeric(18,2) output
)
AS

declare @err int
set @err = 0

set @val = (select sum(prixservice) from Service, AbonneService 
where AbonneService.idservice = Service.idservice and 
idabonne = @idabonne and date_jour between @dateDe and @dateA and numcompte = @numcompte)


if @val is NULL
set @val = 0