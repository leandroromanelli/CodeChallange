using CodeChallange.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeChallange.Services
{
    public class CarService : ICarService
    {
        private List<Car> _cars;

        public CarService()
        {
            if (_cars == null || !_cars.Any())
            {
                _cars = new List<Car>() {
                    new Car { Id = 1, Make = "Audi", Model = "R8", Year = 2018, Doors = 2, Color = "Red", Price = 79995 },
                    new Car { Id = 2, Make = "Tesla", Model = "3", Year = 2018, Doors = 4, Color = "Black", Price = 54995 },
                    new Car { Id = 3, Make = "Porsche", Model = " 911 991", Year = 2020, Doors = 2, Color = "White", Price = 155000 },
                    new Car { Id = 4, Make = "Mercedes-Benz", Model = "GLE 63S", Year = 2021, Doors = 5, Color = "Blue", Price = 83995 },
                    new Car { Id = 5, Make = "BMW", Model = "X6 M", Year = 2020, Doors = 5, Color = "Silver", Price = 62995 },
                };
            }
        }

        public async Task AddCar(Car car)
        {
            _cars.Add(car);
        }

        public async Task DeleteCar(int id)
        {
            _cars.Remove(await GetCar(id));
        }

        public async Task<Car> GetCar(int id)
        {
            return _cars.FirstOrDefault(c => c.Id == id);
        }

        public async Task<List<Car>> GetCars()
        {
            return _cars;
        }

        public async Task UpdateCar(int id, Car car)
        {
            car.Id = id;
            _cars = _cars.Select(c => c.Id != id ? c : car).ToList();
        }
    }
}
