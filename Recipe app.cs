using System;

namespace RecipeApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to RecipeApp!");

            Recipe recipe = new Recipe();

            bool running = true;

            while (running)
            {
                Console.WriteLine("\nEnter 1 to add a new recipe.");
                Console.WriteLine("Enter 2 to display the current recipe.");
                Console.WriteLine("Enter 3 to scale the current recipe.");
                Console.WriteLine("Enter 4 to reset the current recipe.");
                Console.WriteLine("Enter 5 to clear all data and start a new recipe.");
                Console.WriteLine("Enter 6 to exit the program.");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        recipe.AddRecipe();
                        break;
                    case "2":
                        recipe.DisplayRecipe();
                        break;
                    case "3":
                        recipe.ScaleRecipe();
                        break;
                    case "4":
                        recipe.ResetRecipe();
                        break;
                    case "5":
                        recipe.ClearRecipe();
                        break;
                    case "6":
                        running = false;
                        break;
                    default:
                        Console.WriteLine("\nInvalid input. Please try again.");
                        break;
                }
            }

            Console.WriteLine("\nThank you for using RecipeApp!");
        }
    }

    class Recipe
    {
        private int numIngredients;
        private Ingredient[] ingredients;
        private int numSteps;
        private string[] steps;

        public Recipe()
        {
            numIngredients = 0;
            ingredients = new Ingredient[10];
            numSteps = 0;
            steps = new string[10];
        }

        public void AddRecipe()
        {
            Console.WriteLine("\nEnter the number of ingredients:");

            numIngredients = int.Parse(Console.ReadLine());

            ingredients = new Ingredient[numIngredients];

            for (int i = 0; i < numIngredients; i++)
            {
                Console.WriteLine($"\nEnter the name of ingredient {i + 1}:");
                string name = Console.ReadLine();

                Console.WriteLine($"Enter the quantity of ingredient {i + 1}:");
                double quantity = double.Parse(Console.ReadLine());

                Console.WriteLine($"Enter the unit of measurement for ingredient {i + 1}:");
                string unit = Console.ReadLine();

                ingredients[i] = new Ingredient(name, quantity, unit);
            }

            Console.WriteLine("\nEnter the number of steps:");

            numSteps = int.Parse(Console.ReadLine());

            steps = new string[numSteps];

            for (int i = 0; i < numSteps; i++)
            {
                Console.WriteLine($"\nEnter step {i + 1}:");
                steps[i] = Console.ReadLine();
            }

            Console.WriteLine("\nRecipe added successfully!");
        }

        public void DisplayRecipe()
        {
            Console.WriteLine("\nRecipe:");

            for (int i = 0; i < numIngredients; i++)
            {
                Console.WriteLine($"{ingredients[i].Quantity} {ingredients[i].Unit} {ingredients[i].Name}");
            }

            Console.WriteLine("\nSteps:");

            for (int i = 0; i < numSteps; i++)
            {
                Console.WriteLine($"{i + 1}. {steps[i]}");
            }
        }

        public void ScaleRecipe()
        {
            Console.WriteLine("\nEnter the scaling factor (0.5, 2, or 3):");

            double factor = double.Parse(Console.ReadLine());

            for (int i = 0; i < numIngredients; i++)
            {
                ingredients[i].Quantity *= factor;
            }

            Console.WriteLine("\nRecipe scaled successfully!");
        }

        public void ResetRecipe()
        {
            for (int i = 0; i < ingredients.Length; i++)
            {
                ingredients[i].Name = null;
                ingredients[i].Quantity = 0;
                ingredients[i].UnitOfMeasurement = null;
            }
            for (int i = 0; i < steps.Length; i++)
            {
                steps[i] = null;
            }
            Console.WriteLine("Recipe has been reset.");
        }


        public void ClearRecipe()
        {
            for (int i = 0; i < ingredients.Length; i++)
            {
                ingredients[i] = null;
            }
            for (int i = 0; i < steps.Length; i++)
            {
                steps[i] = null;
            }
            Console.WriteLine("Recipe has been cleared.");
        }


    }
}
