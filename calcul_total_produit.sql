CREATE PROCEDURE calcul_total_produit
(	@idemploye int,
	@val numeric(18,2) output
)
AS

declare @err int
set @err = 0

set @val = (select qteprise * prixstock From EmployeProduit where idemploye = @idemploye)


if @val is NULL
set @val = 0