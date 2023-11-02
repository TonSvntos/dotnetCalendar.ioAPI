create procedure [dbo].[spLSTAllClients]


as begin 
set nocount on

select 
	ClienteId
	, NomeCliente			
    ,TelefoneCliente	
	,ClienteEndereco	
	,DataDoAtendimento	
	,ClienteBairro		
	,TipoDeServico		
	

from dbo.Clientes P with (nolock)

end