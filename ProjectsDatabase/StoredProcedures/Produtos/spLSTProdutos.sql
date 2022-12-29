create procedure [dbo].[spLSTProdutos]
@Term varchar(60) = null
,@Page int = 1
, @PageSize int = 10

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

where 
ProdutoNome like Concat('%',@term,'%') or CategoriaNome like Concat('%',@term,'%')
order by ProdutoId
OFFSET (@Page - 1) * @PageSize rows fetch next @PageSize rows only


end