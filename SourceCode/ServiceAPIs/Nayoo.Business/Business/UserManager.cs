using Nayoo.Business.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nayoo.Business
{
    public class UserManager
    {
        #region [Public Method]
        public static async Task<bool> Login(string userName, string password)
        {
            try
            {

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static async Task<bool> ChangePassword(string userName, string currentPassword, string newPassword)
        {
            try
            {
                if (string.IsNullOrEmpty(userName))
                    throw new Exception("UserName is required");

                if (string.IsNullOrEmpty(currentPassword))
                    throw new Exception("Current Password is required");

                if (string.IsNullOrEmpty(newPassword))
                    throw new Exception("New Password is required");

                if (currentPassword != newPassword)
                    throw new Exception("Password is not mismatch");

                string newpass = Nayoo.Business.Helpers.Helper.Base64Decode(newPassword);
                string pass = PasswordHelper.Encryption(newpass);

                ///TODO : Wait for addto database.

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static async Task<bool> Register()
        {
            try
            {

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static async Task<bool> UpdateProfile()
        {
            try
            {

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        #endregion
    }
}
