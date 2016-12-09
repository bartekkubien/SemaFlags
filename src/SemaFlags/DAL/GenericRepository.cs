using Microsoft.EntityFrameworkCore;
using SemaFlags.DAL;
using SemaFlags.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SemaFlags.DAL
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class, IEntity
    {
        DbSet<TEntity> context;
        public GenericRepository(DbSet<TEntity> ctx) {
            context = ctx;
        }

        public IQueryable<TEntity> Elements => context;

        public void Clear()
        {
            context.RemoveRange(context);
        }

        public TEntity RemoveElement(int id)
        {
            TEntity dbEntry = context.FirstOrDefault(e => e.Id == id);
            if (dbEntry != null)
            {
                context.Remove(dbEntry);
                //context.SaveChanges();
            }
            return dbEntry;
        }

        public TEntity SaveElement(TEntity element)
        {
            if (element.Id == 0)
            {

                context.Add(element);
                return element;
            }
            else
            {
                TEntity dbEntry = context.FirstOrDefault(e => e.Id == element.Id);
                if (dbEntry != null)
                {
                    IBaseCopier< IEntity> copier = CopierFactory.CreateCopier(dbEntry.GetType());
                    copier.CopyProperties(dbEntry, element);
                    return dbEntry;
                }

            }
            return null;      
        }
    }
}
