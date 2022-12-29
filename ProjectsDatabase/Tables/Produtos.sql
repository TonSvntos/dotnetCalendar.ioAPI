CREATE TABLE [dbo].[Produtos](
	[ProdutoId] [int] IDENTITY(1,1) Primary key NOT NULL,
	[ProdutoNome] [varchar](60) NOT NULL,
	[PrecoUnitario] [decimal](18, 2) NULL,
	[QuantidadeEstoque] [int] NULL,
	[Status] [bit] NULL,
	[CategoriaId] [int] NULL
	)

go
CREATE UNIQUE INDEX UQ_ProdutoNome  
ON dbo.produtos(ProdutoNome);
go
