using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nayoo.Data.ClassHelper
{
    public class Users : mst_user
    {
        enum Role
        {
            ADMIN, MEMBER, SECURITY, COMMITTEE, STAFF
        }

        public List<med_image> images { get; set; }    

        public Users()
        {
            images = new List<med_image>();
        }
    }
}
