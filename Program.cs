using ModelValidation;
using System.ComponentModel.DataAnnotations;

namespace UserModelValidation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            User model = new User();

            Console.WriteLine("Please enter the following details:");

            Console.Write("Id: ");
            model.Id = int.Parse(Console.ReadLine());

            Console.Write("Name: ");
            model.Name = Console.ReadLine();

            Console.Write("Email: ");
            model.Email = Console.ReadLine();

            Console.Write("Password: ");
            model.Password = Console.ReadLine();

            Console.Write("Confirm Password: ");
            model.ConfirmPassword = Console.ReadLine();

            Console.Write("Salary: ");
            model.Salary = decimal.Parse(Console.ReadLine());

            Console.Write("Phone Number: ");
            model.PhoneNumber = Console.ReadLine();

            Console.Write("Website: ");
            model.Website = Console.ReadLine();

            // Validate the model using data annotations
            var context = new ValidationContext(model, serviceProvider: null, items: null);
            var results = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(model, context, results, validateAllProperties: true);

            // Display the validation results
            if (isValid)
            {
                Console.WriteLine("Model is valid. Proceed with the application logic.");
            }
            else
            {
                foreach (var validationResult in results)
                {
                    Console.WriteLine(validationResult.ErrorMessage);
                }
            }
        }
    }
}