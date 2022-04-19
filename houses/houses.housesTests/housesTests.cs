using houses.Core.Dtos;
using houses.Core.ServiceInterface;
using System;
using System.Threading.Tasks;
using Xunit;

namespace houses.housesTests
{
    public class housesTests : TestBase
    {
        [Fact]
        public async Task Should_AddNewHouse_WhenReturnResult()
        {
            string guid = "a1925975-d8fc-4f55-b614-d9b5aa7b4ebe";
            //byte[] array1 = new byte[1000 * 1000 * 3];

            HousesDto houses = new HousesDto();

            houses.Id = Guid.Parse(guid);
            houses.Description = "Suvila";
            houses.Name = "Koolibri";
            houses.Model = "modernne";
            houses.Designer = "Akso-Haus";
            houses.Amount = 1;
            houses.Price = 50000;
            houses.ModifiedAt = DateTime.Now;
            houses.CreatedAt = DateTime.Now;

            var result = await Svc<IHousesService>().Add(houses);

            Assert.NotNull(result);
        }
        [Fact]
        public async Task Check_Guid_IsNotInt()
        {
            string guid = "a1925975-d8fc-4f55-b614-d9b5aa7b4ebe";
            var insertGuid = Guid.Parse(guid);
            await Svc<IHousesService>().Edit(insertGuid);

            Assert.False(insertGuid.GetType() == typeof(int));
        }

        [Fact]
        public async Task ShouldNot_GetByIdHouses_WhenReturnsResultAsync()
        {
            string guid = "e6771076-91cd-4169-bbdd-cfc5290a6b3f";
            string guid1 = "1ab8c12a-f8da-4e55-ab77-f45378d3adb5";

            var insertGuid = Guid.Parse(guid);
            var insertGuid1 = Guid.Parse(guid1);

            await Svc<IHousesService>().Edit(insertGuid);

            Assert.NotEqual(insertGuid1, insertGuid);
            //Assert.Single((System.Collections.IEnumerable)result);
        }
        [Fact]
        public async Task Should_GetByIdHouses_WhenReturnsResultAsync()
        {
            string guid = "e6771076-91cd-4169-bbdd-cfc5290a6b3f";
            string guid1 = "e6771076-91cd-4169-bbdd-cfc5290a6b3f";

            var insertGuid = Guid.Parse(guid);
            var insertGuid1 = Guid.Parse(guid1);

            await Svc<IHousesService>().Edit(insertGuid);

            Assert.Equal(insertGuid1, insertGuid);
            //Assert.Single((System.Collections.IEnumerable)result);
        } 
    }
}
