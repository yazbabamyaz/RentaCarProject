using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity, TContext>
        where TEntity : class, IEntity, new()
        where TContext:DbContext,new()
    {
        public void Add(TEntity entity)
        {

            using (TContext context=new TContext())
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(TEntity entity)
        {
            using (TContext context = new TContext())//işi bitince bellekten at.
            {
                //IDispossable pattern implementation of c#:using bakabilirsin
                var deletedEntity = context.Entry(entity);//
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();

            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            //tek data geetiren bölüm bu yüzden null yok.
            using (TContext context = new TContext())
            {
                //önce dbset lerimden producta bağlanıyorum.
                return context.Set<TEntity>().SingleOrDefault(filter);
                //tek bir product döndürecek.
                //customer da product yerine customer yazarsın standart hale geldi
                //ileride standart olan yerleri generic BASE HALE getircez TEKRAR ETMEMEK için

            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext context = new TContext())
            {//filtre yoksa tüm datayı getir diyelim
             //dbset teki product tablosuna yerleş.Listeye çevir bana ver.select * gibi

                return filter == null ? context.Set<TEntity>().ToList()
                    : context.Set<TEntity>().Where(filter).ToList();

                //Böyle de olur.
                //return filter == null ? context.Products.ToList()
                //    : context.Set<Product>().Where(filter).ToList();
            }
        }

        public void Update(TEntity entity)
        {
            using (TContext context = new TContext())//işi bitince bellekten at.
            {
                //IDispossable pattern implementation of c#:using bakabilirsin
                var updatedEntity = context.Entry(entity);//
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();


            }
        }
    }
}
