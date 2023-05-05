using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Newtonsoft.Json;
using FruityViceDataContracts.Models;
using FruityViceDataContracts.URIHelpers;
using FruityviceServices.Contract;

namespace FruityviceServices.Implementation
{
    public class FruityViceService : IFruityViceService
    {
        private HttpClient _httpClient;
        private readonly IHttpClientFactory httpClientFactory;

        public FruityViceService(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
            _httpClient = this.httpClientFactory.CreateClient("fruityvice");
        }

        public string AddNewFruitService(FruitDto Fruit)
        {
            var data = JsonConvert.SerializeObject(Fruit);
            var content = new StringContent(data, UnicodeEncoding.UTF8, "application/json");
            var result = _httpClient.PutAsync(ApiUrlConstants.Fruit, content);
            var response = result.Result.Content.ReadAsStringAsync().Result;

            return response;
        }

        public List<FruitDto> GetAllFruitsService()
        {
            var data = _httpClient.GetAsync(ApiUrlConstants.AllFruits).Result;
            return JsonConvert.DeserializeObject<List<FruitDto>>(data.Content.ReadAsStringAsync().Result);
        }

        public List<FruitDto> GetFruitsByFamilyService(string family)
        {
            var data = _httpClient.GetAsync(ApiUrlConstants.FruitsByFamily + "/" + family).Result;
            var resposne = data.Content.ReadAsStringAsync().Result;

            if (!resposne.Contains("error"))
            {
                return JsonConvert.DeserializeObject<List<FruitDto>>(resposne);
            }
            else
            {
                return new List<FruitDto>()
                {
                    new FruitDto()
                    {
                        family= family,
                    }
                };
            }
        }

        public List<FruitDto> GetFruitsByGenusService(string genus)
        {
            var data = _httpClient.GetAsync(ApiUrlConstants.FruitsByGenus + "/" + genus).Result;
            var resposne = data.Content.ReadAsStringAsync().Result;

            if (!resposne.Contains("error"))
            {
                return JsonConvert.DeserializeObject<List<FruitDto>>(resposne);
            }
            else
            {
                return new List<FruitDto>()
                {
                    new FruitDto()
                    {
                        genus= genus,
                    }
                };
            }
        }

        public List<FruitDto> GetFruitsByNutritionService(string nutrient, double min, double max)
        {
            string requestURI = ApiUrlConstants.Fruit + "/" + nutrient + $"?min={min}&max={max}";
            var data = _httpClient.GetAsync(requestURI).Result;
            var resposne = data.Content.ReadAsStringAsync().Result;

            if (!resposne.Contains("error"))
            {
                return JsonConvert.DeserializeObject<List<FruitDto>>(resposne);
            }
            else
            {
                return new List<FruitDto>()
                {
                    new FruitDto()
                    {
                        nutritions=
                        {

                        }
                    }
                };
            }
        }

        public List<FruitDto> GetFruitsByOrderService(string order)
        {
            var data = _httpClient.GetAsync(ApiUrlConstants.FruitsByOrder + "/" + order).Result;
            var resposne = data.Content.ReadAsStringAsync().Result;

            if (!resposne.Contains("error"))
            {
                return JsonConvert.DeserializeObject<List<FruitDto>>(resposne);
            }
            else
            {
                return new List<FruitDto>()
                {
                    new FruitDto()
                    {
                        order= order,
                    }
                };
            }
        }
    }
}