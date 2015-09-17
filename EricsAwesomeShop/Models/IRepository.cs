using System;
using System.Linq;

namespace EricsAwesomeShop.Models {
    public interface IRepository : IDisposable {
        void Add<T>(T entityToCreate) where T : class;
        void Delete<T>(params object[] keyValues) where T : class;
        T Find<T>(params object[] keyValues) where T : class;
        IQueryable<Car> QueryCar();
        IQueryable<T> QueryICar<T>() where T : class, ICar;
        void SaveChanges();
    }
}