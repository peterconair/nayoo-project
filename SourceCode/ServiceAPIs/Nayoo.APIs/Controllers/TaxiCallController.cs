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
    public class TaxiCallController : ApiController
    {
        [HttpGet]
        [ResponseType(typeof(List<opt_taxi_call>))]
        public async Task<IHttpActionResult> Get()
        {
            try
            {
                return Ok(await TaxiCaller.Get());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [ResponseType(typeof(List<opt_taxi_call>))]
        public async Task<IHttpActionResult> Get(Int32 id, string uniqueId)
        {
            try
            {
                return Ok(await TaxiCaller.Get(id, uniqueId));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [ResponseType(typeof(opt_taxi_call))]
        public async Task<IHttpActionResult> Post(opt_taxi_call entity)
        {
            try
            {
                return Ok(await TaxiCaller.Add(entity));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [ResponseType(typeof(bool))]
        public async Task<IHttpActionResult> Put(opt_taxi_call entity)
        {
            try
            {
                return Ok(await TaxiCaller.Modify(entity));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }

}
