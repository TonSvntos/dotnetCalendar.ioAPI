Create PROCEDURE [dbo].[spINSCliente] 
   	
  @NomeCliente		varchar(50) 
 , @TelefoneCliente	int			
 , @ClienteEndereco	varchar(100)	
 , @DataDoAtendimento date		
 , @ClienteBairro		varchar(50)	
 , @TipoDeServico     varchar(30)

 as begin

 INSERT INTO dbo.Clientes
               (
					[NomeCliente]		
					, TelefoneCliente	
					, ClienteEndereco		
					, DataDoAtendimento 
					, ClienteBairro	
					, TipoDeServico
				)
         VALUES
               (
			   
			   @NomeCliente		
			   , @TelefoneCliente	
			   , @ClienteEndereco	
			   , @DataDoAtendimento
			   , @ClienteBairro	
			   , @TipoDeServico

			   )
    END