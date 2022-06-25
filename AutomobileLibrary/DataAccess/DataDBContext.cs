using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutomobileLibrary.BussinessObject;

namespace AutomobileLibrary.DataAccess
{
    public class DataDBContext
    {
        private List<Car> CarList = new List<Car>
        {
            new Car {CarID = 1, CarName = "CRV", Manufacturer = " Honda", Price = 30000, ReleasedYear = 2021},
            new Car {CarID = 2, CarName = "Ford Focus", Manufacturer = "Ford", Price = 15000, ReleasedYear = 2020},
        };
        private static DataDBContext instance = null;
        public static readonly object instanceLock = new object();
        private DataDBContext() { }
        public static DataDBContext Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DataDBContext();
                }
                return instance;
            }
        }

        public List<Car> GetCarList => CarList;

        public Car GetCarByID(int CarID)
        {
            Car? car = CarList.SingleOrDefault(car => car.CarID == CarID);
            return car;
        }

        public void AddNew(Car car)
        {
            Car pro = GetCarByID(car.CarID);
            if (pro == null)
            {
                CarList.Add(car);
            }
            else
            {
                throw new Exception("Car is already existed.");
            }
        }

        public void Remove(int carId)
        {
            Car car = GetCarByID(carId);
            if (car != null)
            {
                CarList.Remove(car);
            }
            else
            {
                throw new Exception("Car does not already existed.");
            }
        }

        public void Update(Car car)
        {
            Car pro = GetCarByID(car.CarID);
            if (pro != null)
            {
                int index = CarList.IndexOf(pro);
                CarList[index] = car;
            }
            else
            {
                throw new Exception("Car does not already existed.");
            }
        }
    }
}
