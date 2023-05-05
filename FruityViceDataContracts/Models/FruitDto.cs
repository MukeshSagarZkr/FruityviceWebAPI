using System;

namespace FruityViceDataContracts.Models
{
    public class FruitDto
    {
        public string name { get; set; }
        public int id { get; set; }
        public string family { get; set; }
        public string order { get; set; }
        public string genus { get; set; }
        public NutritionsDto nutritions { get; set; }
    }    
}
