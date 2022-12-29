Create PROCEDURE [dbo].[spINSProduct] 
   
  @ProdutoNome varchar(60)
  , @PrecoUnitario decimal(18,2)
  , @QuantidadeEstoque int 
  , @CategoriaId int = null


AS
BEGIN

SET NOCOUNT ON;

 INSERT INTO dbo.Produtos
               (
					ProdutoNome
					,PrecoUnitario
					, QuantidadeEstoque
					, CategoriaId
				)
         VALUES
               (
			   
					@ProdutoNome
					, @PrecoUnitario
					, @QuantidadeEstoque
					, @CategoriaId
			   )
    END