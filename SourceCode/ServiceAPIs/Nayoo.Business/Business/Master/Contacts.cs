using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nayoo.Data;
using System.Transactions;
using System.Data.Entity.Validation;
using Nayoo.Business.Helpers;

namespace Nayoo.Business.Business.Master
{
    public class Contacts
    {
        public static async Task<mst_contact> Post(mst_contact entity)
        {
            try
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    using (NayooDbEntities e = new NayooDbEntities())
                    {
                        e.mst_contact.Add(entity);
                        var result = await e.SaveChangesAsync();
                        if (result <= 0)
                            throw new Exception("Save contact not complete !");

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
        
    }
}
