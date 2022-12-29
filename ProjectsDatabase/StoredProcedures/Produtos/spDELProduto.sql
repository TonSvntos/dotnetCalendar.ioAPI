create PROCEDURE [dbo].[spDELProduto]
@ProdutoId int
           
AS
    SET NOCOUNT ON

    Delete dbo.Produtos 
    where ProdutoId = @ProdutoId