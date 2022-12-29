Create procedure dbo.spLogin
@email varchar(60)
,@senha varchar(60)


as begin 
set nocount on

select 
	UsuarioId
	, UsuarioNome
	, Email
	, Senha 

from dbo.Usuarios u with (nolock)
where @email = u.Email and @senha = u.Senha
end
