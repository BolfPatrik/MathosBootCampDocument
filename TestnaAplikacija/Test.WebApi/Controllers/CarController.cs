using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Test.WebApi.Models;

namespace Test.WebApi.Controllers
{

    public class CarsController : ApiController
    {
        static IList<Car> cars = new List<Car>()
        {
          new Car()
        {
            Id = 1, Name = "Renault",  Manufacturer = "Clio"
        },
        new Car(){
            Id = 2, Name = "Avalon", Manufacturer = "Toyota"
         },
        new Car(){
            Id = 3, Name = "Rolls Royce", Manufacturer = "BMW"
         },
        new Car(){
            Id = 4, Name = "C-Zero", Manufacturer = "Citroen"
         },
        new Car(){
            Id = 5, Name = "California T", Manufacturer = "Ferrari"
         },
        new Car(){
            Id = 6, Name = "EcoSport", Manufacturer = "Ford"
         },
        };
        [HttpGet]
        [Route("api/cars")]
        public HttpResponseMessage GetAllCars()
        {
            IList<Car> carsPresent = new List<Car>();
            foreach (Car car in cars)
            {
                carsPresent.Add(car);
            }
            return Request.CreateResponse(HttpStatusCode.OK, cars);
        }
        [HttpGet]
        [Route("api/cars/getspecific")]
        public HttpResponseMessage GetACar(int id)
        {
            var car = cars.FirstOrDefault(c => c.Id == id);
            if (car == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Car not found");
            }
            return Request.CreateResponse(HttpStatusCode.OK, car);
        }
        [HttpPost]
        [Route("api/cars/post")]
        public HttpResponseMessage PostNewCar(Car car)
        {

            cars.Add(new Car()
            {
                Id = car.Id,
                Name = car.Name,
                Manufacturer = car.Manufacturer
            });
            if (car == null)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Bad request");
            }
            return Request.CreateResponse(HttpStatusCode.OK, car);
        }
        [HttpPut]
        [Route("api/cars/put")]
        public HttpResponseMessage Put(Car car)
        {
            var existingCar = cars.Where(c => c.Id == car.Id).FirstOrDefault<Car>();
            if (existingCar != null)
            {
                existingCar.Name = car.Name;
                existingCar.Manufacturer = car.Manufacturer;
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Bad request");
            }
            return Request.CreateResponse(HttpStatusCode.OK, car);
        }
        [HttpDelete]
        [Route("api/cars/delete")]
        public HttpResponseMessage Delete(int id)
        {
            if (id <= 0)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Bad request");
            }
            else
            {
                cars.RemoveAt(id);
            }
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }


}