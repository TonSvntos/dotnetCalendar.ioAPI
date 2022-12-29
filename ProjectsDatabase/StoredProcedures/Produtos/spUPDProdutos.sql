Create PROCEDURE [dbo].[spUPDProdutos]
	@ProdutoNome varchar(60) = null
   ,@ProdutoId int
   ,@PrecoUnitario decimal(18,2) = null
   ,@QuantidadeEstoque int  = null


AS
BEGIN

    SET NOCOUNT ON;
    
    UPDATE dbo.Produtos
        SET 
            ProdutoNome = @ProdutoNome,
            PrecoUnitario = @PrecoUnitario,
            QuantidadeEstoque= @QuantidadeEstoque

    WHERE ProdutoId = @ProdutoId

END

