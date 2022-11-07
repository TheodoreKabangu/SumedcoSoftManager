create procedure insert_service_recette
(
@idrecette int,
@idservice int,
@statut varchar(2)
)
as 
insert into ServiceRecette values (@idrecette, @idservice, @statut);

-----------------------------------------------------------------
create procedure insert_recette
(
@idrecette int,
@idpatient int,
@daterecette varchar(10)
)
as
insert into Recette values (@idrecette, @idpatient, @daterecette);

--------------------------------------------------------------------------
create procedure delete_recette
(
@idrecette int,
@ok int output
)
as 
declare @err int
set @err = 0
begin transaction
if not exists (select idrecette from ServiceRecette where idrecette = @idrecette)
begin
set @err = 1
end
else
begin
delete from ServiceRecette where idrecette = @idrecette
delete from Recette where idrecette = @idrecette

set @err = @err + @@ERROR
end
if @err = 0
commit transaction
else
rollback transaction
if @err = 0
set @ok = 1
else
set @ok = 0
;