using System;
using System.Collections.Generic;
using System.Text;

namespace FruityViceDataContracts.Models
{
    public class NutritionsDto
    {
        public int calories { get; set; }
        public double fat { get; set; }
        public double sugar { get; set; }
        public double carbohydrates { get; set; }
        public double protein { get; set; }
    }
}
