using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using DAL;

namespace Repository
{
    public interface IGenericRepo<TEntity> where TEntity: class
    {
        //get the table record(TEntity) by primary key ID
        TEntity GetByID(int id);
        IEnumerable<TEntity> GetAll();
        void Insert(TEntity entity);
        void Delete(TEntity entity);
        void Update(TEntity entity);
        
    }
    public class GenericRepo<TEntity>: IGenericRepo<TEntity> where TEntity:class 
    {
        internal TaskManagerEntities context;
        internal DbSet<TEntity> set;

        public GenericRepo(TaskManagerEntities context)
        {
            this.context = context;
            this.set = context.Set<TEntity>();
        }

       public TEntity GetByID(int id)
        {
            return this.set.Find(id);
                    
        }
       public IEnumerable<TEntity> GetAll() {
            return this.set.AsEnumerable<TEntity>();
        }
        public void Insert(TEntity entity)
        {
            this.set.Add(entity);
            this.context.SaveChanges();
        }
        public void Delete(TEntity entity)
        {   
            set.Remove(entity);
            context.SaveChanges();
        }

        
        public void Update(TEntity entity)
        {  
            set.Attach(entity);
            context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}
