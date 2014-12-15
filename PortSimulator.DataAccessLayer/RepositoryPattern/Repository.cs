using System;
using System.Data.Entity;
using System.Linq;
using PortSimulator.Core.Entities;

namespace PortSimulator.DataAccessLayer.RepositoryPattern
{
    public class Repository<T> where T : BaseEntity
    {
        private readonly PortSimulatorContext _context;
        private IDbSet<T> _entities;

        public Repository(PortSimulatorContext context)
        {
            _context = context;
        }

        public Repository()
        {
            _context = new PortSimulatorContext();
        }

        private IDbSet<T> Entities
        {
            get
            {
                if (_entities == null)
                {
                    _entities = _context.Set<T>();
                }
                return _entities;
            }
        }

        #region CRUD
        public virtual IQueryable<T> Table
        {
            get
            {
                return Entities;
            }
        }

        public T GetById(int id)
        {
            return Entities.Find(id);
        }

        public void Insert(T entity)
        {
            try
            {
                if (entity == null)
                    throw  new ArgumentNullException("entity");

                Entities.Add(entity);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void Update(T entity)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentNullException("entity");

                _context.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void Delete(T entity)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentNullException("entity");

                Entities.Remove(entity);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        #endregion
    }
}
