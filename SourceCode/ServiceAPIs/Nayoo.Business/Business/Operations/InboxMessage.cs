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
    public class InboxMessage
    {
        public static async Task<opt_inbox_message> Add(opt_inbox_message entity)
        {
            try
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    using (NayooDbEntities e = new NayooDbEntities())
                    {
                        e.opt_inbox_message.Add(entity);
                        var result = await e.SaveChangesAsync();
                        if (result <= 0)
                            throw new Exception("Save Inbox Message not complete !");

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

        public static async Task<bool> Modify(opt_inbox_message entity)
        {
            try
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    using (NayooDbEntities e = new NayooDbEntities())
                    {
                        e.opt_inbox_message.Add(entity);
                        var result = await e.SaveChangesAsync();
                        if (result <= 0)
                            throw new Exception("Save Inbox Message not complete !");

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

        public static async Task<List<opt_inbox_message>> Get()
        {
            try
            {
                using(NayooDbEntities e= new NayooDbEntities())
                {
                    return e.opt_inbox_message.ToList(); 
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ExceptionHelper.ExceptionMessage(ex));
            }
        }

        public static async Task<opt_inbox_message> Get(Int32 id)
        {
            try
            {
                using (NayooDbEntities e = new NayooDbEntities())
                {
                    return e.opt_inbox_message.Where(x => x.messageId == id).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ExceptionHelper.ExceptionMessage(ex));
            }
        }
    }
}
