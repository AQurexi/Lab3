using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace RepsitoryPattern.Data
{
    public class Product
    {
        public int ProductId { get; set; } 

        public string ProuctName { get; set; }
    
        public string Category { get; set; }

        public Admin admin { get; set; }
        [ForeignKey("Id")]
        public Guid AdminId { get; set; }
        [ForeignKey("Id")]
        public int manufacturerId { get; internal set; }
        public Manufacturer manufacturer { get; set; }

    }
}