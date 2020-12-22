using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace RepsitoryPattern.Data
{
    public class ProductViewModel
    {
        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public string AdminName{ get; set; }
        public string ManufacturerName{ get; set; }
        public string Categroy { get; internal set; }
    }
}