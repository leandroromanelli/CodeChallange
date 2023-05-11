using CodeChallange.Models;
using CodeChallange.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace CodeChallange.Controllers
{
    public class CarsController : Controller
    {
        private readonly ICarService _service;

        public CarsController(ICarService service)
        {
            _service = service;
        }

        // GET: Cars
        public async Task<IActionResult> Index()
        {
              return View(await _service.GetCars());
        }

        // GET: Cars/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || await _service.GetCars() == null)
            {
                return NotFound();
            }

            var car = await _service.GetCar(id.Value);
            if (car == null)
            {
                return NotFound();
            }

            return View(car);
        }

        // GET: Cars/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cars/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Make,Model,Year,Doors,Color,Price")] Car car)
        {
            if (ModelState.IsValid)
            {
                await _service.AddCar(car);
                return RedirectToAction(nameof(Index));
            }
            return View(car);
        }

        // GET: Cars/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null ||  await _service.GetCars() == null)
            {
                return NotFound();
            }

            var car = await _service.GetCar(id.Value);
            if (car == null)
            {
                return NotFound();
            }
            return View(car);
        }

        // POST: Cars/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Make,Model,Year,Doors,Color,Price")] Car car)
        {
            if (id != car.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _service.UpdateCar(id, car);
                }
                catch (Exception)
                {
                    if (!await CarExists(car.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(car);
        }

        // GET: Cars/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || await _service.GetCars() == null)
            {
                return NotFound();
            }

            var car = await _service.GetCar(id.Value);
            if (car == null)
            {
                return NotFound();
            }

            return View(car);
        }

        // POST: Cars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (await _service.GetCars() == null)
            {
                return Problem("Entity set 'CodeChallangeContext.Car'  is null.");
            }
            var car = await _service.GetCar(id);
            if (car != null)
            {
                _service.DeleteCar(id);
            }
            
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> CarExists(int id)
        {
          return (await _service.GetCar(id) != null);
        }
    }
}
