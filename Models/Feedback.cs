using System.ComponentModel.DataAnnotations; 
namespace FeedbackManagement.Models 
{ 
public class Feedback 
{ 
[Required(ErrorMessage = "Please enter your name")] 
public string Name { get; set; } 
[Required(ErrorMessage = "Please enter your email")] 
[EmailAddress(ErrorMessage = "Enter a valid email address")] 
public string Email { get; set; } 
[Required(ErrorMessage = "Please select a category")] 
public string Category { get; set; } 
[Range(1, 5, ErrorMessage = "Rating must be between 1 and 5")] 
public int Rating { get; set; } 
[Required(ErrorMessage = "Please enter your comments")] 
[StringLength(300, ErrorMessage = "Maximum 300 characters allowed")] 
public string Comments { get; set; } 
} 
} 
