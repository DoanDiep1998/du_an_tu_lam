using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.Repository
{
    public interface IRepository<Tentity> where Tentity:class
    {
        IEnumerable<Tentity> Getall();
       
       //Tentity Detail( Expression<Func<Tentity, bool>> predicate);
        Tentity Find(string id);
        void Add(Tentity entity);
        void Edit(Tentity entity);
        void Delete(string id);
        void Save();
        IEnumerable<Tentity> Sort_Up(Expression<Func<Tentity, bool>> predicate);
        IEnumerable<Tentity> Sort_Down(Expression<Func<Tentity, bool>> predicate);
        Tentity SingleOf(Expression<Func<Tentity, bool>> predicate);
        Tentity FirstOf(Expression<Func<Tentity, bool>> predicate);
    }
}
