using FruityViceDataContracts.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FruityviceServices.Contract
{
    public interface IFruityViceService
    {
        public string AddNewFruitService(FruitDto Fruit);
        public List<FruitDto> GetFruitsByOrderService(string order);
        public List<FruitDto> GetFruitsByGenusService(string genus);
        public List<FruitDto> GetFruitsByFamilyService(string family);
        public List<FruitDto> GetFruitsByNutritionService(string nutrient, double min, double max);
        public List<FruitDto> GetAllFruitsService();
    }
}
