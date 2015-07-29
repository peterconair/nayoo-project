using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nayoo.Data;
using System.Data.Entity.Validation;
using Nayoo.Business.Helpers;
using System.Transactions;

namespace Nayoo.Business.Operations
{
    public class TaxiCaller
    {
        public static async Task<opt_taxi_call> Add(opt_taxi_call entity)
        {
            try
            {
                using(TransactionScope scope=  new  TransactionScope())
                {
                    using(NayooDbEntities e =new NayooDbEntities())
                    {
                      A:  string _uniqueId = Helper.NewUniqueId;
                        bool Ok = e.opt_taxi_call.Any(x => x.callUniqueId.Equals(_uniqueId));
                        if (Ok)
                            goto A;
                        entity.callUniqueId = _uniqueId;
                        e.opt_taxi_call.Add(entity);
                        var result = await e.SaveChangesAsync();
                        if (result <= 0)
                            throw new Exception("Save Taxi call not complete !");

                        scope.Complete();
                        return entity; 
                    }
                }
            }
            catch (DbEntityValidationException ex)
            {
                throw new Exception(ExceptionHelper.ExceptionMessage(ex));
            }
        }

        public static async Task<bool> Modify(opt_taxi_call entity)
        {
            try
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    using (NayooDbEntities e = new NayooDbEntities())
                    {
                        var _taxiCall = e.opt_taxi_call.Where(x => x.callId == entity.callId && x.callUniqueId.Equals(entity.callUniqueId)).FirstOrDefault();
                        e.Entry(entity).CurrentValues.SetValues(_taxiCall);
                        var result = await e.SaveChangesAsync();
                        if (result <= 0)
                            throw new Exception("Taxi call not complete !");

                        scope.Complete();
                        return true;
                    }
                }
            } 
            catch (DbEntityValidationException ex)
            {
                throw new Exception(ExceptionHelper.ExceptionMessage(ex));
            }
        }

        public static async Task<List<opt_taxi_call>>Get()
        {
            try
            {
                using(NayooDbEntities e= new NayooDbEntities())
                {
                    return e.opt_taxi_call.ToList();
                }
            }
            catch (Exception ex)
            {    
                throw new Exception(ExceptionHelper.ExceptionMessage(ex));
            }
        }

        public static async Task<opt_taxi_call> Get(Int32 id, string uniqueId)
        {
            try
            {
                using(NayooDbEntities e= new NayooDbEntities())
                {
                    return e.opt_taxi_call.Where(x => x.callId == id && x.callUniqueId.Equals(uniqueId)).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {    
                throw new Exception(ExceptionHelper.ExceptionMessage(ex));
            }
        }
    }
}
