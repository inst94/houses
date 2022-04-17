using houses.Core.Dtos;
using houses.Core.ServiceInterface;
using houses.Data;
using houses.Models.Houses;
using houses.Views.Houses;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace houses.Controllers
{
    public class HousesController : Controller
    {
        private readonly housesDbContext _context;
        private readonly IHousesService _housesService;
        public HousesController
            (
                housesDbContext context,
                IHousesService housesService

            )
        {
            _context = context;
            _housesService = housesService;
        }
        public IActionResult Index()
        {
            var result = _context.Houses
                .Select(x => new HousesListViewModel {
                    Id = x.Id,
                    Name = x.Name,
                    Price = x.Price,
                    Amount = x.Amount,
                    Description = x.Description,
                    Model = x.Model,
                    Designer = x.Designer
                });
            return View(result);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(Guid id)
        {
            var houses = await _housesService.Delete(id);

            if (houses == null) {
                RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult Add()

        {
            HousesViewModel mod = new HousesViewModel();
            return View("Edit", mod);
        }
        [HttpPost]
        public async Task<IActionResult> Add(HousesViewModel mod)
        {
            var dto = new HousesDto() {
                Id = mod.Id,
                Description = mod.Description,
                Name = mod.Name,
                Model = mod.Model,
                Designer = mod.Designer,
                Amount = mod.Amount,
                Price = mod.Price,
                ModifiedAt = mod.ModifiedAt,
                CreatedAt = mod.CreatedAt
            };
            var result = await _housesService.Add(dto);
            if (result == null) {
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var houses = await _housesService.Edit(id);
            if (houses == null) {
                return NotFound();
            }

            var model = new HousesViewModel();

            model.Id = houses.Id;
            model.Description = houses.Description;
            model.Name = houses.Name;
            model.Model = houses.Model;
            model.Designer = houses.Designer;
            model.Amount = houses.Amount;
            model.Price = houses.Price;
            model.ModifiedAt = houses.ModifiedAt;
            model.CreatedAt = houses.CreatedAt;

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Update(HousesViewModel mod)
        {
            var dto = new HousesDto() {
                Id = mod.Id,
                Description = mod.Description,
                Name = mod.Name,
                Model = mod.Model,
                Designer = mod.Designer,
                Amount = mod.Amount,
                Price = mod.Price,
                ModifiedAt = mod.ModifiedAt,
                CreatedAt = mod.CreatedAt
            };

            var result = await _housesService.Update(dto);

            if (result == null) {
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index), mod);
        }
    }
}
