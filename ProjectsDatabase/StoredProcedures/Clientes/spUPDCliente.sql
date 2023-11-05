USE [ProjectsDatabase]
GO
/****** Object:  StoredProcedure [dbo].[spUPDCliente]    Script Date: 05/11/2023 18:56:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[spUPDCliente]

	@ClienteId  int					  
 , @NomeCliente		varchar(50)       
 , @TelefoneCliente	int				  
 , @ClienteEndereco	varchar(100)	  
 , @DataDoAtendimento date			  
 , @ClienteBairro		varchar(50)	  
 , @TipoDeServico     varchar(30)	,
 @Cep				int ,
	@numero				int ,
	@complemento		varchar(50),
	@cidade				varchar(50) 


AS
BEGIN

    SET NOCOUNT ON;
    
    UPDATE dbo.Clientes
        SET 
            
			NomeCliente				= @NomeCliente		
			,TelefoneCliente		= @TelefoneCliente	
			,ClienteEndereco		= @ClienteEndereco	
			,DataDoAtendimento		= @DataDoAtendimento
			,ClienteBairro			= @ClienteBairro
			,TipoDeServico			= @TipoDeServico   
			,Cep					=  @Cep			
			, numero				=  @numero		
			, Complemento			=  @complemento
			,	Cidade				=  @cidade		

    WHERE ClienteId = @ClienteId

END
