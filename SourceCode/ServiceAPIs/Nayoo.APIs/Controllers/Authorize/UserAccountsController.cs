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

namespace Nayoo.APIs.Controllers.Authorize
{
    public class UserAccountsController : ApiController
    {
        [HttpGet]
        [ResponseType(typeof(List<Users>))]
        public async Task<IHttpActionResult> Get(string role, string key)
        {
            try
            {
                return Ok(await Nayoo.Business.Authorize.UserAccunts.Get(role, key));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [ResponseType(typeof(List<Users>))]
        public async Task<IHttpActionResult> Get(int memberId, string memberUniqueId)
        {
            try
            {
                return Ok(await Nayoo.Business.Authorize.UserAccunts.Get(memberId, memberUniqueId));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [ResponseType(typeof(Users))]
        public async Task<IHttpActionResult> Post(Users userObj)
        {
            try
            {
                return Ok(await Nayoo.Business.Authorize.UserAccunts.Add(userObj));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [ResponseType(typeof(bool))]
        public async Task<IHttpActionResult> Put(Users userObj)
        {
            try
            {
                return Ok(await Nayoo.Business.Authorize.UserAccunts.Modify(userObj)); 
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
