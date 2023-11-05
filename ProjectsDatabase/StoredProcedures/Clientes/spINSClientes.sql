USE [ProjectsDatabase]
GO
/****** Object:  StoredProcedure [dbo].[spINSCliente]    Script Date: 05/11/2023 18:56:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[spINSCliente] 
   	
  @NomeCliente			varchar(50) 
 , @TelefoneCliente		int			
 , @ClienteEndereco		varchar(100)	
 , @DataDoAtendimento	date		
 , @ClienteBairro		varchar(50)	
 , @TipoDeServico		varchar(30),
	@Cep				int ,
	@numero				int ,
	@complemento		varchar(50),
	@cidade				varchar(50) 

 as begin

 INSERT INTO dbo.Clientes
               (
					[NomeCliente]		
					, TelefoneCliente	
					, ClienteEndereco	
					, DataDoAtendimento 
					, ClienteBairro	
					, TipoDeServico
					, Cep
					,numero
					,Complemento
					,Cidade
				)
         VALUES
               (
			   
			   @NomeCliente		
			   , @TelefoneCliente	
			   , @ClienteEndereco	
			   , @DataDoAtendimento
			   , @ClienteBairro	
			   , @TipoDeServico
			   , @Cep			
			   , @numero			
			   , @complemento	
			   , @cidade			
			   )
    END