using System.Collections.Generic; 
using System.Web.Mvc; 
using ProductCatalog.Models; 
namespace ProductCatalog.Controllers 
{ 
public class ProductController : Controller 
{ 
public ActionResult Index() 
{ 
List<Product> products = new List<Product>() 
{ 
new Product { Id = 1, Name = "Laptop", Price = 50000, Category = 
"Electronics" }, 
new Product { Id = 2, Name = "Mobile", Price = 20000, Category = 
"Electronics" }, 
new Product { Id = 3, Name = "Headphones", Price = 2000, Category 
= "Accessories" }, 
new Product { Id = 4, Name = "Keyboard", Price = 1500, Category = 
"Accessories" } 
}; 
return View(products); 
        } 
        public ActionResult Details(int id){ 
            Product product = new Product(); 
            if (id == 1) 
                product = new Product { Id = 1, Name = "Laptop", Price = 50000, 
Category = "Electronics" }; 
            else if (id == 2) 
                product = new Product { Id = 2, Name = "Mobile", Price = 20000, 
Category = "Electronics" }; 
            else if (id == 3) 
                product = new Product { Id = 3, Name = "Headphones", Price = 2000, 
Category = "Accessories" }; 
            else 
                product = new Product { Id = 4, Name = "Keyboard", Price = 1500, 
Category = "Accessories" }; 
            return View(product); 
        } 
    } 
} 
