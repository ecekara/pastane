using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class RawMaterial
    {
        public int RawMaterialId { get; set; }
        public string RawMaterialName { get; set; }
        public double Price { get; set; }
        public double Calorie { get; set; }
        public string MeasurementUnit { get; set; }
    }
}
