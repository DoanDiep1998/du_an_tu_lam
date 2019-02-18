using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.Repository
{
    
    // lớp này là lớp xử lý dữ liệu
    public class Repository<Tentity> : IRepository<Tentity> where Tentity : class
    {
        MenShopDbContext db = new MenShopDbContext();
        protected MenShopDbContext _context;
        protected DbSet<Tentity> _table;
        public Repository()
        {
            //tạo kết nối
            _context = new MenShopDbContext();
            _table = _context.Set<Tentity>();
        }

        //Void chỉ định Phương thức không trả về giá trị
        public void Add(Tentity entity)
        {
            _table.Add(entity);
            Save();
        }
        
        public void Delete(string id)
        {
          Tentity data = _table.Find(id);
            if (data !=null)
            {
                _table.Remove(data);
                Save();
            }
            
        }

        public void Edit(Tentity entity)
        {
            // Entry  cung cấp quyền truy cập vào bên trong thực thể và khả năng thực hiện các hành động trong thực thể đó 
            _context.Entry(entity).State = EntityState.Modified;
            Save();
        }

        public Tentity Find(string id)
        {
            return _table.Find(id);
        }
        // IEnumerable trả về 1 danh sách
        public IEnumerable<Tentity> Getall()
        {
            return _table.ToList();
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        // truyền biểu thức Lamda
        public virtual IEnumerable<Tentity> Sort_Up(Expression<Func<Tentity, bool>> predicate)
        {
            return  _table.OrderBy(predicate).ToList();  

           
        }

        public IEnumerable<Tentity> Sort_Down(Expression<Func<Tentity, bool>> predicate)
        {
            return _table.OrderByDescending(predicate).ToList();
        }

        public Tentity SingleOf(Expression<Func<Tentity, bool>> predicate)
        {
            return _table.SingleOrDefault(predicate);
        }

        public Tentity FirstOf(Expression<Func<Tentity, bool>> predicate)
        {
            return _table.FirstOrDefault(predicate);
        }
    }
}
