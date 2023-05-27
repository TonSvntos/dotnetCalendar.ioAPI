Create procedure [dbo].[spSELClienteById]
@ClienteId int

as begin
select  * 
from dbo.Clientes P with (nolock)

where ClienteId = @ClienteId
end