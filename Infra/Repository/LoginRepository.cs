using System;
using System.Collections.Generic;
using System.Text;
using Domain.Models;
using Framework.Infra;
using Infra;
using Domain.Interfaces.Repository;
using System.Data;


namespace Infra.Repository
{
    public class LoginRepository : ILoginRepository
    {
        const PEnvironment.PDB db = PEnvironment.PDB.ProjectsDatabase;
        public UsuariosDomain Login(LoginDomain login)
        {
            Helper helper = new Helper();
            DataTable dt = helper.ExecuteTable(db, "dbo.doLogin", new { login.Email, login.Senha });

            if (dt != null && dt.Rows.Count != 0)
            {
                return helper.ConvertDataTable<UsuariosDomain>(dt);
            }
            else
            {
                return null;
            }
        }
    }
}
