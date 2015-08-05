using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using System.Threading.Tasks;

using Nayoo.Data.ClassHelper;
using Nayoo.Data;
using System.Data.Entity.Validation;
using Nayoo.Business.Helpers;
using Nayoo.Business.Security;
using System.Web.Http.Description;

namespace Nayoo.APIs.Controllers.Common
{
    public class CommonController : ApiController
    {
        [HttpGet]
        [ResponseType(typeof(List<UserRoles>))]
        public async Task<IHttpActionResult> GetUserRoles()
        {
            try
            {
                return Ok(await Business.Helpers.Helper.GetUserRoles());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
