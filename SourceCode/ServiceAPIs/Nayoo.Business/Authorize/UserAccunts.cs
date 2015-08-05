using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

using Nayoo.Data.ClassHelper;
using Nayoo.Data;
using System.Data.Entity.Validation;
using Nayoo.Business.Helpers;
using Nayoo.Business.Security;

namespace Nayoo.Business.Authorize
{
    public class UserAccunts
    {
        public static async Task<Users> Add(Users user)
        {
            try
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    using (NayooDbEntities e = new NayooDbEntities())
                    {
                        var entity = AutoMap<Users, mst_user>.Map(user);

                        string _uniqueId = Helper.NewUniqueId;
                        string _password = PasswordHelper.Encryption(entity.password);

                        entity.memberUniqueId = _uniqueId;
                        entity.password = _password;
                        entity.createdDate = DateTime.Now;
                        entity.updatedDate = DateTime.Now;
                        entity.isActive = true;
                        e.mst_user.Add(entity);

                        var result = await e.SaveChangesAsync();
                        if (result <= 0)
                            throw new DbEntityValidationException("Add new user account not complete.");

                        scope.Complete();
                        return AutoMap<mst_user, Users>.Map(entity);
                    }
                }
            }
            catch (DbEntityValidationException ex)
            {
                throw new Exception(ExceptionHelper.ExceptionMessage(ex));
            }
        }

        public static async Task<bool> Modify(Users user)
        {
            try
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    using (NayooDbEntities e = new NayooDbEntities())
                    {
                        var entity = AutoMap<Users, mst_user>.Map(user);
                        
                        entity.updatedDate = DateTime.Now;

                        var _user = e.mst_user.Where(x => x.memberId == entity.memberId &&
                                                          x.memberUniqueId.Equals(entity.memberUniqueId)).FirstOrDefault();

                        e.Entry(entity).CurrentValues.SetValues(_user);
                        var result = await e.SaveChangesAsync();
                        if (result <= 0)
                            throw new DbEntityValidationException("Modify user account not complete.");

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

        public static async Task<bool> ChangePassword(mst_user entity)
        {
            try
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    using (NayooDbEntities e = new NayooDbEntities())
                    {
                        string _password = PasswordHelper.Encryption(entity.password);
                        entity.updatedDate = DateTime.Now;
                        entity.password = _password;

                        var _user = e.mst_user.Where(x => x.memberId == entity.memberId &&
                                                          x.memberUniqueId.Equals(entity.memberUniqueId)).FirstOrDefault();

                        e.Entry(entity).CurrentValues.SetValues(_user);
                        var result = await e.SaveChangesAsync();
                        if (result <= 0)
                            throw new DbEntityValidationException("Change password not complete.");

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

        public static async Task<Users> Get(int id, string memberUniqueId)
        {
            try
            {
                using (NayooDbEntities e = new NayooDbEntities())
                {
                    var _user = e.mst_user.Where(x => x.memberId == id && x.memberUniqueId.Equals(memberUniqueId)).FirstOrDefault();
                    if (_user == null)
                        throw new Exception("Not found User Account.");
                    Users user = AutoMap<mst_user, Users>.Map(_user);
                    user.images.AddRange(e.med_image.Where(x => x.imageMappedId.Equals(memberUniqueId)).ToList());
                    return user;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ExceptionHelper.ExceptionMessage(ex));
            }
        }

        public static async Task<List<Users>> Get(string role, string keysearch)
        {
            try
            {
                using (NayooDbEntities e = new NayooDbEntities())
                {
                    var _user = e.mst_user.Where(x => x.userRole.Contains(role) &&
                                                      x.username.Contains(keysearch) ||
                                                      x.firstName_Th.Contains(keysearch) ||
                                                      x.firstName_En.Contains(keysearch) ||
                                                      x.lastName_Th.Contains(keysearch) ||
                                                      x.lastName_En.Contains(keysearch)).ToList();
                    if (_user.Count == 0)
                        return new List<Users>();

                    List<Users> user = AutoMap<mst_user, Users>.Map(_user);
                    user.ForEach(x =>
                                   x.images.AddRange(e.med_image.Where(z => z.imageMappedId.Equals(x.memberUniqueId)).ToList()));
                    return user;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ExceptionHelper.ExceptionMessage(ex));
            }
        }

    }
}
