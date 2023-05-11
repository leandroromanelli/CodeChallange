using CodeChallange.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CodeChallange.Services
{
    public interface ICarService
    {
        public Task<Car> GetCar(int id);
        public Task<List<Car>> GetCars();
        public Task UpdateCar(int id, Car car);
        public Task AddCar(Car car);
        public Task DeleteCar(int id);
    }
}
