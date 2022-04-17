using houses.Core.Domain;
using houses.Core.Dtos;
using System;
using System.Threading.Tasks;

namespace houses.Core.ServiceInterface
{
    public interface IHousesService : IApplicationService
    {
        Task<Houses> Delete(Guid id);
        Task<Houses> Add(HousesDto dto);
        Task<Houses> Edit(Guid id);
        Task<Houses> Update(HousesDto dto);
    }
}
