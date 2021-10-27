using Core.Entities;
using DataAccess.EntityFramework.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccess.EntityFramework
{
    public class UserDal
    {
        public List<User> GetList(Expression<Func<User, bool>> filter = null)
        {
            using (ApplicationContext context = new ApplicationContext())
            {
                return filter == null ?
                    context.Set<User>().Where(x=>x.IsActive==true).ToList() :
                    context.Set<User>().Where(x => x.IsActive == true).Where(filter).ToList();
            }
        }

        public List<User> GetListWithoutCondition(Expression<Func<User, bool>> filter = null)
        {
            using (ApplicationContext context = new ApplicationContext())
            {
                return filter == null ?
                    context.Set<User>().ToList() :
                    context.Set<User>().Where(filter).ToList();
            }
        }

        public User Get(Expression<Func<User, bool>> filter)
        {
            using (ApplicationContext context = new ApplicationContext())
            {
                return context.Set<User>().Where(x=>x.IsActive==true).FirstOrDefault(filter);
            }
        }

        public User GetWithoutCondition(Expression<Func<User, bool>> filter)
        {
            using (ApplicationContext context = new ApplicationContext())
            {
                return context.Set<User>().FirstOrDefault(filter);
            }
        }

        public int Add(User user)
        {
            using (ApplicationContext context = new ApplicationContext())
            {
                try
                {
                    context.Set<User>().Add(user);
                    return context.SaveChanges();
                }
                catch (Exception ex)
                {
                    return 0;
                }
            }
        }

        public int Update(User user)
        {
            try
            {
                using (ApplicationContext context = new ApplicationContext())
                {
                    context.Set<User>().Update(user);
                    return context.SaveChanges();
                }
            }
            catch (Exception)
            {
                return 0;
            }
            
        }

        public int DeletePermanently(int id)
        {
            using (ApplicationContext context = new ApplicationContext())
            {
                try
                {
                    var user = context.Set<User>().FirstOrDefault(x => x.Id == id);
                    context.Set<User>().Remove(user);
                    return context.SaveChanges();
                }
                catch (Exception)
                {

                    return 0;
                }
                
            }
        }

        public int DeleteWithStatus(int id)
        {
            using (ApplicationContext context = new ApplicationContext())
            {
                var user = context.Set<User>().FirstOrDefault(x => x.Id == id);
                if (user != null)
                {
                    user.IsActive = false;
                    context.Set<User>().Update(user);
                    return context.SaveChanges();
                }
                return 0;
            }
        }
    }
}
