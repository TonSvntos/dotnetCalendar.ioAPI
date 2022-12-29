using System.Collections.Generic;
using Domain.Models;
using Framework.Infra;
using Domain.Interfaces.Repository;

namespace Infra.Repository
{
    public class CategoriesRepository : ICategoriesRepository
    {
        const PEnvironment.PDB db = PEnvironment.PDB.ProjectsDatabase;

        public CategoriasDomain InsertCategories(CategoriasDomain insCategorias)
        {
            Helper helper = new Helper();

            helper.ExecuteNonQuery(db, "dbo.spINSCategories", new
            {

                insCategorias.CategoriaNome
            });

            return insCategorias;
        }

        public List<CategoriasDomain> ListCategoriesDomain()
        {
            Helper helper = new Helper();

            return helper.ExecuteList<CategoriasDomain>(db, "dbo.spLSTCategorias");
        }

    }
}
