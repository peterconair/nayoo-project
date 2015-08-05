using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Transactions;

using Nayoo.Data.ClassHelper;
using Nayoo.Data;
using System.Data.Entity.Validation;
using Nayoo.Business.Helpers;
using Nayoo.Business.Security;

namespace Nayoo.Business.Authorize
{
    public class Authentication
    {

        public static async Task<Users> Login(string UserName, string Password)
        {
            try
            {
                string _passswordEncrypt = PasswordHelper.Encryption(Password);
                using (NayooDbEntities e = new NayooDbEntities())
                {
                    var user = e.mst_user.Where(x => x.username.Equals(UserName) && x.password.Equals(_passswordEncrypt)).FirstOrDefault();
                    if (user == null)
                        throw new Exception("Not found user Account.");

                    if (user.isActive == false)
                        throw new Exception("User is inactive.");

                    return AutoMap<mst_user, Users>.Map(user);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
