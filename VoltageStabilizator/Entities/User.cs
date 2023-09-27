

using System;

namespace Voltage_Stablizer.Entities
{
    public class User 
    {
        public int Id { get; set; }
        public int Voltage { get; set; }
        public double cos { get; set; }
        public string Name { get; set; }
        public double Power { get; set; }
        public int Quantity { get; set; }
        public DateTime Create { get; set; }
    }

}
