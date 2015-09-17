using EricsAwesomeShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EricsAwesomeShop.Controllers
{
    [Route("api/cars/", Name = "CarApi")]
    public class CarController : ApiController
    {
        private IRepository _repo;

        public CarController(IRepository repo) {
            _repo = repo;
        }
        
        public IList<Car> Get() {
            return _repo.QueryCar().ToList();
        }

        public Car Get(int id) {
            return (from c in _repo.QueryCar()
                    where c.Id == id
                    select c).Single();
        }

        [Authorize]
        public HttpResponseMessage Post(Car car) {
            if (car.InternalCombustionCar != null) {
                car.InternalCombustionCar.Base = car;
                ModelState.Remove("car.InternalCombustionCar.Base");
            }
            if (car.ElectricCar != null) {
                car.ElectricCar.Base = car;
                ModelState.Remove("car.ElectricCar.Base");
            }
            if (ModelState.IsValid) {
                _repo.Add(car);
                _repo.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.OK, car);
            }
            return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
        }
    }
}
