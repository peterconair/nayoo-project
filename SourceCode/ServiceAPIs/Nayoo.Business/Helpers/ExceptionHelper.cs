using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nayoo.Business.Helpers
{
    public class ExceptionHelper
    {

        public static string ExceptionMessage(DbEntityValidationException ex)
        {
            var errorMessage = ex.EntityValidationErrors.SelectMany(x => x.ValidationErrors).Select(x => x.ErrorMessage);
            var fullErrorMessage = String.Join("; ", errorMessage);
            var exceptionMessage = string.Concat(ex.Message, " The validation errors are: ", fullErrorMessage);
            DbEntityValidationException e = new DbEntityValidationException(exceptionMessage, ex.EntityValidationErrors);
            return e.Message;
        }

        public static string ExceptionMessage(Exception ex)
        {
            if (ex.InnerException == null)
                return ex.Message;

            return ex.InnerException.Message;
        }
    }
}
