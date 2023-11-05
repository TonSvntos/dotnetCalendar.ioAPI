USE [ProjectsDatabase]
GO
/****** Object:  StoredProcedure [dbo].[spLSTClientes]    Script Date: 05/11/2023 18:57:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
  
ALTER procedure [dbo].[spLSTClientes]  
  
  
--declare  
	@NomeCliente		varchar(50)     = ''  
  , @TelefoneCliente	int				= null  
  , @ClienteEndereco	varchar(100)    = null  
  , @DataDoChamado		date			= null  
  , @DataDoAtendimento	date			= null  
  , @ClienteBairro		varchar(50)		= null  
  , @TipoDeServico		varchar(30)		= null  
  
  
  
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
 ,Cep
 ,numero
 ,Complemento
 ,Cidade
   
   
  
  
from dbo.Clientes P with (nolock)  
where   
  NomeCliente like Concat('%',@NomeCliente,'%')   
  and ClienteEndereco like Concat('%',@ClienteEndereco,'%')  
  and ClienteBairro like Concat('%',ClienteBairro,'%')  
  
  and (  @TelefoneCliente = TelefoneCliente or @TelefoneCliente is null)  
  and (  @DataDoAtendimento = DataDoAtendimento or @DataDoAtendimento is null)  
  --and (  @ClienteBairro = ClienteBairro or @ClienteBairro is null)  
  and (  @TipoDeServico = TipoDeServico or @TipoDeServico is null)  
  
  
   
  
  
end