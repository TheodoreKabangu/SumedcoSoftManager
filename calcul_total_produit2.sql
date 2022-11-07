CREATE PROCEDURE calcul_total_produit2
(	@idabonne int,
	@dateDe date,
	@dateA date,
	@val numeric(18,2) output
)
AS

declare @err int
set @err = 0

set @val = (select qteprise * prixstock From AbonneProduit where idabonne = @idabonne and date_jour between @dateDe and @dateA)


if @val is NULL
set @val = 0