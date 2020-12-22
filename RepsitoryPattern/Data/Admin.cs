using System;
using System.ComponentModel.DataAnnotations;

namespace RepsitoryPattern.Data
{
    public class Admin
    {
        [Key]
        public Guid AdminId { get; set; }

        public string AdminName { get; set; }
        public string Reputation { get; set; }
    }
}