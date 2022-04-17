using houses.Core.Domain;
using houses.Core.Dtos;
using houses.Core.ServiceInterface;
using houses.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace houses.ApplicationServices.Services
{
    public class HousesServices : IHousesService
    {
        private readonly housesDbContext _context;
        public HousesServices
            (
                housesDbContext context
            )
        {
            _context = context;
        }
        public async Task<Houses> Delete(Guid id)
        {
            var housesId = await _context.Houses
                .FirstOrDefaultAsync(x => x.Id == id);

            _context.Houses.Remove(housesId);
            await _context.SaveChangesAsync();

            return housesId;
        }
        public async Task<Houses> Add(HousesDto dto)
        {
            Houses houses = new Houses();

            houses.Id = Guid.NewGuid();
            houses.Description = dto.Description;
            houses.Name = dto.Name;
            houses.Model = dto.Model;
            houses.Designer = dto.Designer;
            houses.Amount = dto.Amount;
            houses.Price = dto.Price;
            houses.ModifiedAt = DateTime.Now;
            houses.CreatedAt = DateTime.Now;

            await _context.Houses.AddAsync(houses);
            await _context.SaveChangesAsync();

            return houses;
        }
        public async Task<Houses> Edit(Guid id)
        {
            var result = await _context.Houses
                .FirstOrDefaultAsync(x => x.Id == id);

            return result;

        }
        public async Task<Houses> Update(HousesDto dto)
        {
            Houses houses = new Houses();

            houses.Id = dto.Id;
            houses.Description = dto.Description;
            houses.Name = dto.Name;
            houses.Model = dto.Model;
            houses.Designer = dto.Designer;
            houses.Amount = dto.Amount;
            houses.Price = dto.Price;
            houses.ModifiedAt = dto.ModifiedAt;
            houses.CreatedAt = dto.CreatedAt;

            _context.Houses.Update(houses);
            await _context.SaveChangesAsync();

            return houses;
        }
    }
}
