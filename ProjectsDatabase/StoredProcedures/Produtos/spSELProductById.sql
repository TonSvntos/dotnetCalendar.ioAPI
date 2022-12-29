create procedure dbo.spSELProductById
@ProdutoId int

as begin
select 
	
      P.ProdutoId
	, P.ProdutoNome
	, P.PrecoUnitario
	, P.QuantidadeEstoque
	, P.Status
	, P.CategoriaId
	, C.CategoriaNome
	
from dbo.Produtos P with (nolock)
left join dbo.Categorias C on C.CategoriaId = P.CategoriaId

where P.ProdutoId = @ProdutoId
end