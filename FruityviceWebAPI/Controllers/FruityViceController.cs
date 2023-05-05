using FruityViceDataContracts.Models;
using FruityviceServices.Contract;
using Microsoft.AspNetCore.Mvc;

namespace FruityviceWebAPI.Controllers
{
    [Route("/api")]
    public class FruityViceController : System.Web.Http.ApiController
    {
        IFruityViceService fruityViceService;
        public FruityViceController(IFruityViceService fruityViceService)
        {
            this.fruityViceService = fruityViceService;
        }

        #region "GET Calls"
        [HttpGet]
        [Route("GetAll")]
        public IActionResult GetAll() =>
            (IActionResult)Ok(this.fruityViceService.GetAllFruitsService());

        [HttpGet]
        [Route("GetFruitsByNutrition/{nutrient}")]
        public IActionResult GetFruitsByNutrition(string nutrient, double min, double max) =>
            (IActionResult)Ok(this.fruityViceService.GetFruitsByNutritionService(nutrient, min, max));

        [HttpGet]
        [Route("GetFruitsByFamily/{family}")]
        public IActionResult GetFruitsByFamily(string family) =>
            (IActionResult)Ok(this.fruityViceService.GetFruitsByFamilyService(family));

        [HttpGet]
        [Route("GetFruitsByGenus/{genus}")]
        public IActionResult GetFruitsByGenus(string genus) =>
            (IActionResult)Ok(this.fruityViceService.GetFruitsByGenusService(genus));

        [HttpGet]
        [Route("GetFruitsByOrder/{order}")]
        public IActionResult GetFruitsByOrder(string order) =>
            (IActionResult)Ok(this.fruityViceService.GetFruitsByOrderService(order));

        #endregion

        #region "PUT Calls"
        [HttpPut]
        [Route("AddNewFruit")]
        public IActionResult AddNewFruit([FromBody] FruitDto fruit)
        {
            var result = this.fruityViceService.AddNewFruitService(fruit);
            if (result.Contains("error"))
                return (IActionResult)BadRequest(result);
            else
                return (IActionResult)Ok(result);
        }
        #endregion
    }
}
