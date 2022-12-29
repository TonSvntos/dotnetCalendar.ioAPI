Create procedure [dbo].[spLSTCategorias]

as begin 
set nocount on

select 
	CategoriaId
	, CategoriaNome

from dbo.categorias with (nolock)
order by CategoriaId
end