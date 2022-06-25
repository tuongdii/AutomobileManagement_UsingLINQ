using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutomobileLibrary.BussinessObject;
using AutomobileLibrary.DataAccess;

namespace AutomobileLibrary.Repository
{
    public class CarRepository : ICarRepository
    {
        public void AddNew(Car car) => DataDBContext.Instance.AddNew(car);

        public void Delete(int carId) => DataDBContext.Instance.Remove(carId);

        public IEnumerable<Car> GetAll() => DataDBContext.Instance.GetCarList;

        public Car getCarByID(int carId) => DataDBContext.Instance.GetCarByID(carId);

        public void Update(Car car) => DataDBContext.Instance.Update(car);
    }
}
