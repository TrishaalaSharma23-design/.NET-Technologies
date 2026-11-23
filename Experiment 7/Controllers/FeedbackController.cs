using System.Collections.Generic; 
using System.Web.Mvc; 
using FeedbackManagement.Models; 
namespace FeedbackManagement.Controllers 
{ 
public class FeedbackController : Controller 
{ 
private void LoadCategories() 
{ 
   ViewBag.Categories = new List<SelectListItem> 
{ 
new SelectListItem { Text = "Website", Value = "Website" }, 
new SelectListItem { Text = "Teaching", Value = "Teaching" }, 
new SelectListItem { Text = "Services", Value = "Services" }, 
new SelectListItem { Text = "Other", Value = "Other" } 
}; 
} 
public ActionResult Index() 
{ 
LoadCategories(); 
return View(new Feedback()); 
} 
[HttpPost] 
[ValidateAntiForgeryToken] 
public ActionResult Index(Feedback feedback) 
{ 
if (ModelState.IsValid) 
{ 
return View("Result", feedback); 
} 
LoadCategories(); 
return View(feedback); 
} 
} 
} 
