using Nayoo.Data.ClassHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nayoo.Business.Helpers
{
    public class Helper
    {
        public static async Task<List<Role>>GetUserRoles()
        {
            UserRoles u = new UserRoles();
            return u.Roles;
        }

        public static string NewUniqueId
        {
            get
            {
                return Guid.NewGuid().ToString("N").Substring(1,30);
            }
        }

        public static string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }

        public static string Base64Decode(string base64EncodedData)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }

    }
}
