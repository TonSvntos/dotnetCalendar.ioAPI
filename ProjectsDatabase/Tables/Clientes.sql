USE [ProjectsDatabase]
GO

/****** Object:  Table [dbo].[Clientes]    Script Date: 05/11/2023 18:58:23 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Clientes](
	[ClienteId] [int] IDENTITY(1,1) NOT NULL,
	[NomeCliente] [varchar](50) NOT NULL,
	[TelefoneCliente] [int] NOT NULL,
	[TipoDeServico] [varchar](30) NOT NULL,
	[ClienteEndereco] [varchar](100) NOT NULL,
	[DataDoChamado] [date] NULL,
	[DataDoAtendimento] [date] NULL,
	[ClienteBairro] [varchar](50) NOT NULL,
	[Complemento] [varchar](255) NULL,
	[Cidade] [varchar](255) NULL,
	[Cep] [int] NULL,
	[numero] [int] NULL
) ON [PRIMARY]
GO


