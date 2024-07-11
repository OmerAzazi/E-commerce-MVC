using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce.DataAccess.Repository.IRepository
{
    public interface IRepository<T> where T : class //Bz we have multiple class and we don't want to call specific one so we identify T as a multiple class variable so we just call the class 
    {
        // Next we will think what will be all the method inside this class
        // So first T -> Category
        IEnumerable<T> GetAll(); // To Get all Data
        T Get(Expression<Func<T,bool>> filter); // This one to get one data depend on parameter, why we didn't use find ? Bz find only work on ID
        void Add(T entity); // Add new one
        void Remove(T entity); // Delete One
        void RemoveRage(IEnumerable<T> entity); // Delete all or the selected one
    }
}
