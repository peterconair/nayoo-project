using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Threading.Tasks;
using Nayoo.Business.Operations;
using Nayoo.Data;
using System.Web.Http.Description;

namespace Nayoo.APIs.Controllers
{
    /// <summary>
    /// Record Guest ApiController
    /// </summary>
    public class RecordGuestController : ApiController
    {

        /// <summary>
        /// Get All Guest Record 
        /// </summary>
        /// <returns>List of Gruest Record </returns>
        [HttpGet]
        [ResponseType(typeof(List<opt_guest_record>))]
        public async Task<IHttpActionResult> Get()
        {
            try
            {
                return Ok(await RecordGuest.Get());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Get Single Guest Record 
        /// </summary>
        /// <param name="id">RecordId</param>
        /// <param name="uniqueId">RecordUniqueId</param>
        /// <returns>Record Guest Object</returns>
        [HttpGet]
        [ResponseType(typeof(opt_guest_record))]
        public async Task<IHttpActionResult> Get(Int32 id, string uniqueId)
        {
            try
            {
                return Ok(await RecordGuest.Get(id, uniqueId));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        /// <summary>
        /// Add new Guest Record
        /// </summary>
        /// <param name="entity">New opt_guest_record Object</param>
        /// <returns>New opt_guest_record</returns>
        [HttpPost]
        [ResponseType(typeof(opt_guest_record))]
        public async Task<IHttpActionResult> Post(opt_guest_record entity)
        {
            try
            {
                return Ok(await RecordGuest.Add(entity));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// ModifyGuest Record 
        /// </summary>
        /// <param name="entity">opt_guest_record</param>
        /// <returns>True/False</returns>
        [HttpPut]
        [ResponseType(typeof(bool))]
        public async Task<IHttpActionResult> Put(opt_guest_record entity)
        {
            try
            {
                return Ok(await RecordGuest.Modify(entity));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
