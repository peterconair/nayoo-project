using Nayoo.Business.Helpers;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nayoo.Business.Models
{
    public class Guest
    {
        public static bool Add()
        {
            try
            {

                return true;
            }
            catch (DbEntityValidationException ex)
            {
                throw new Exception(ExceptionHelper.ExceptionMessage(ex));
            }
        }

        public static bool Modify()
        {
            try
            {

                return true;
            }
            catch (DbEntityValidationException ex)
            {
                throw new Exception(ExceptionHelper.ExceptionMessage(ex));
            }
        }

        public static bool Remove()
        {
            try
            {

                return true;
            }
            catch (DbEntityValidationException ex)
            {
                throw new Exception(ExceptionHelper.ExceptionMessage(ex));
            }
        }

        public static bool RemoveRange()
        {
            try
            {

                return true;
            }
            catch (DbEntityValidationException ex)
            {
                throw new Exception(ExceptionHelper.ExceptionMessage(ex));
            }
        }

        public static object GetAll()
        {
            try
            {

                return true;
            }
            catch (DbEntityValidationException ex)
            {
                throw new Exception(ExceptionHelper.ExceptionMessage(ex));
            }
        }

        public static object GetByUserName(string userName)
        {
            try
            {
                return true;
            }
            catch (DbEntityValidationException ex)
            {
                throw new Exception(ExceptionHelper.ExceptionMessage(ex));
            }
        }

        public static object GetByEmail(string email)
        {
            try
            {
                return true;
            }
            catch (DbEntityValidationException ex)
            {
                throw new Exception(ExceptionHelper.ExceptionMessage(ex));
            }
        }

        public static object GetByFirstNameOrLastName(string name)
        {
            try
            {

                return true;
            }
            catch (DbEntityValidationException ex)
            {
                throw new Exception(ExceptionHelper.ExceptionMessage(ex));
            }
        }

        public static object GetByIDCard(string idCard)
        {
            try
            {
                return true;
            }
            catch (DbEntityValidationException ex)
            {
                throw new Exception(ExceptionHelper.ExceptionMessage(ex));
            }
        }
    }
}
