CREATE PROCEDURE calcul_total
(	@idemploye int = 0,
	@numcompte varchar(10),
	@val numeric(18,2) output
)
AS

declare @err int
set @err = 0

set @val = (select sum(prixservice) from Service, EmployeService 
where EmployeService.idservice = Service.idservice and 
idemploye = @idemploye and numcompte = @numcompte)


if @val is NULL
set @val = 0
