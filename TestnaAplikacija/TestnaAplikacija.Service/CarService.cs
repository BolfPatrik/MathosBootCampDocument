using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestnaAplikacija.Model;
using TestnaAplikacija.Repository;
using TestnaAplikacija.Service.Common;

namespace TestnaAplikacija.Service
{
    public class CarService : ICarService
    {
        public List<Car> GetAllCars()
        {
            CarRepository carRep = new CarRepository();

            return carRep.GetAllCars();
        }


        public Car PostCar(Car car)
        {
            CarRepository carRep = new CarRepository();

            return carRep.PostCar(car);
        }


        public Car PutCarById(Car car)
        {
            CarRepository carRep = new CarRepository();

            return carRep.PutCar(car);
        }


        public Car DeleteCarById(int id)
        {
            CarRepository carRep = new CarRepository();

            return carRep.DeleteCarById(id);
        }
    }
}
