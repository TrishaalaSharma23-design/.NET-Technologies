using System;

class ExpenseTracker
{
    static void Main()
    {
        try
        {
            // Ask the user to enter the expense amount
            Console.Write("Enter expense amount: ");
            double amount = Convert.ToDouble(Console.ReadLine());

            // Check whether the amount is valid
            if (amount <= 0)
                throw new Exception("Amount must be greater than 0.");

            // Ask the user to enter the expense category
            Console.Write("Enter expense category: ");
            string category = Console.ReadLine();

            // Display the expense details
            Console.WriteLine("\n--- Expense Details ---");
            Console.WriteLine("Category: " + category);
            Console.WriteLine("Amount: ₹" + amount);
        }
        catch (FormatException)
        {
            // Handles invalid input such as letters instead of numbers
            Console.WriteLine("Error: Please enter a valid amount.");
        }
        catch (Exception ex)
        {
            // Handles other exceptions
            Console.WriteLine("Error: " + ex.Message);
        }
        finally
        {
            // This block always executes
            Console.WriteLine("Expense tracking completed.");
        }
    }
}
