using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace EricsAwesomeShop.Models {
    public class Repository : IRepository {

        private ApplicationDbContext _db;

        public Repository(ApplicationDbContext db) {
            _db = db;
        }

        public IQueryable<Car> QueryCar() {
            return _db.Set<Car>().AsQueryable().Include(c => c.ElectricCar).Include(c => c.InternalCombustionCar);
        }

        public IQueryable<T> QueryICar<T>() where T : class, ICar {
            return _db.Set<T>().AsQueryable().Include(c => c.Base);
        }

        public T Find<T>(params object[] keyValues) where T : class {
            return _db.Set<T>().Find(keyValues);
        }

        public void Add<T>(T entityToCreate) where T : class {
            _db.Set<T>().Add(entityToCreate);
        }

        public void Delete<T>(params object[] keyValues) where T : class {
            _db.Set<T>().Remove(Find<T>(keyValues));
        }

        public void SaveChanges() {
            try {
                _db.SaveChanges();
            }
            catch (DbEntityValidationException error) {
                var firstError = error.EntityValidationErrors.First().ValidationErrors.First().ErrorMessage;
                throw new ValidationException(firstError);
            }
        }

        public void Dispose() {
            _db.Dispose();
        }
    }

    public static class GenericRepositoryExtensions {
        public static IQueryable<T> Include<T, TProperty>(this IQueryable<T> queryable,
            Expression<Func<T, TProperty>> relatedEntity) where T : class {
            return System.Data.Entity.QueryableExtensions.Include<T, TProperty>(queryable,
                relatedEntity);
        }
    }
}