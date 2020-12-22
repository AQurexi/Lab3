using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RepsitoryPattern.Data;
using RepsitoryPattern.Models;

namespace RepsitoryPattern.Controllers
{
    public class HomeController : Controller
    {
        public ApplicationDbContext context;

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext Context)
        {
            context = Context;
            
            _logger = logger;
        }

        public IActionResult Index()
        {
            var books = from products in context.products join admins in context.admins 
                         on products.AdminId equals admins.AdminId
                        join manufacturer in context.manufacturers on products.manufacturerId equals manufacturer.Id select products;

            foreach (var item in books)
            {
                ProductViewModel model = new ProductViewModel()
                {
                    ProductName = item.ProuctName,
                    ManufacturerName = item.manufacturer.ManufacturerName,
                    AdminName = item.admin.AdminName,
                };
            }
            
            return View(books);
        }

        public IActionResult AddProduct([FromBody] ProductViewModel product)

        {
            
                var admin = new Admin()
                {
                    AdminName = product.AdminName
                };
            context.Add(admin);
            context.SaveChanges();
                Product book1 = new Product
                {
                    AdminId = admin.AdminId,
                    ProuctName = product.ProductName,
                    Category = product.Categroy
                };
            context.Add(book1);
            context.SaveChanges();


            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
