using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using Nayoo.Data;
using System.Data.Entity.Validation;
using Nayoo.Business.Helpers;

namespace Nayoo.Business.Operations
{
    public class RecordGuest
    {

        public static async Task<opt_guest_record> Add(opt_guest_record entity)
        {
            try
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    using (NayooDbEntities e = new NayooDbEntities())
                    {
                    A: string _guidId = Helper.NewUniqueId;

                        bool Ok = e.opt_guest_record.Any(x => x.recordUniqueId.Equals(_guidId));
                        if (Ok)
                            goto A;

                        entity.recordUniqueId = _guidId;
                        e.opt_guest_record.Add(entity);
                        var result = await e.SaveChangesAsync();
                        if (result <= 0)
                            throw new Exception("Record guest not complete !");

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

        public static async Task<bool> Modify(opt_guest_record entity)
        {
            try
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    using (NayooDbEntities e = new NayooDbEntities())
                    {
                        var current = e.opt_guest_record.Where(x => x.recordId == entity.recordId &&
                                                                    x.recordUniqueId.Equals(entity.recordUniqueId)).FirstOrDefault();
                        if (current == null)
                            throw new Exception("Not found this object !");

                        e.Entry(entity).CurrentValues.SetValues(current);
                        var result = await e.SaveChangesAsync();
                        if (result <= 0)
                            throw new Exception("Record guest not complete !");

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

        public static async Task<List<opt_guest_record>> Get()
        {
            try
            {
                using (NayooDbEntities e = new NayooDbEntities())
                {
                    return e.opt_guest_record.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ExceptionHelper.ExceptionMessage(ex));
            }
        }

        public static async Task<opt_guest_record> Get(Int32 id , string uniqueId)
        {
            try
            {
                using (NayooDbEntities e = new NayooDbEntities())
                {
                    return e.opt_guest_record.Where(x => x.recordId == id && x.recordUniqueId.Equals(uniqueId)).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ExceptionHelper.ExceptionMessage(ex));
            }
        }


    }
}
