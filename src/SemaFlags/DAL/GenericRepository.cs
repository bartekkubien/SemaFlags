using Microsoft.EntityFrameworkCore;
using SemaFlags.DAL;
using SemaFlags.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SemaFlags.DAL
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : Base
    {
        DbSet<TEntity> context;
        public GenericRepository(DbSet<TEntity> ctx) {
            context = ctx;
        }

        public IQueryable<TEntity> Elements => context;

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

        public void SaveElement(TEntity element)
        {
            if (element.Id == 0)

                context.Add(element);
            else
            {
                TEntity dbEntry = context.FirstOrDefault(e => e.Id == element.Id);
                if (dbEntry != null)
                {
                    dbEntry.Name = element.Name;
                    dbEntry.Description = element.Name;
                    dbEntry.Color = element.Color;
                    dbEntry.SequenceNumber = element.SequenceNumber;
                }
            }         
        }
    }
}
