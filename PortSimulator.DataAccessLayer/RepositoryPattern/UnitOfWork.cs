using System;
using System.Collections.Generic;
using PortSimulator.Core.Entities;

namespace PortSimulator.DataAccessLayer.RepositoryPattern
{
    public class UnitOfWork : IDisposable
    {
        private readonly PortSimulatorContext _context;
        private bool _disposed;
        private Dictionary<string, object> _repositories;

        public UnitOfWork(PortSimulatorContext context)
        {
            _context = context;
        }

        public UnitOfWork()
        {
            _context = new PortSimulatorContext();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
                if(disposing)
                    _context.Dispose();

            _disposed = true;
        }

        public Repository<T> Repository<T>() where T : BaseEntity
        {
            if (_repositories == null)
            {
                _repositories = new Dictionary<string, object>();
            }

            var typeName = typeof (T).Name;
            if (!_repositories.ContainsKey(typeName))
            {
                var repositoryType = typeof (Repository<>);
                var repositoryInstance = Activator.CreateInstance(
                    repositoryType.MakeGenericType(typeof (T)), _context);

                _repositories.Add(typeName, repositoryInstance);
            }

            return (Repository<T>) _repositories[typeName];
        }
    }
}
