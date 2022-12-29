create PROCEDURE [dbo].[spINSCategories] 
   
  @CategoriaNome varchar(60)

AS
BEGIN

SET NOCOUNT ON;

 INSERT INTO dbo.Categorias
               (CategoriaNome)
         VALUES
               (@CategoriaNome)
end