using DataAccessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
namespace DataAccessLayer.Concrete.Repositories
{
    public class GenericRepository<T> : IRepository<T> where T:class
    {
        Context C = new Context();
        DbSet<T> _object;
        public GenericRepository()
        {
            _object = C.Set<T>();
        }
        public void Delete(T p)
        {
            _object.Remove(p);
            C.SaveChanges();
        }

        public void Insert(T p)
        {
            _object.Add(p);
            C.SaveChanges();
            throw new NotImplementedException();
        }

        public List<T> List()
        {
            return _object.ToList();
        }

        public List<T> List(Expression<Func<T, bool>> filter)
        {
            return _object.Where(filter).ToList();
        }

        public void Update(T p)
        {

            C.SaveChanges();
        }
    }

}
