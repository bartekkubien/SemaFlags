using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SemaFlags.Models;

namespace SemaFlags.DAL
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        IQueryable<TEntity> Elements { get; }
        void SaveElement(TEntity element);
        TEntity RemoveElement(int id);
    }
}
