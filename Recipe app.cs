using System;
using System.Collections.Generic;

namespace RecipeScaler
{
    // Class to hold recipe details
    class Recipe
    {
        public string Name { get; set; }
        public int NumIngredients { get; set; }
        public int NumSteps { get; set; }
       // public List<string> Ingredients = new List<string>();
       //  public List<string> Steps = new List<string>();
        public string[] Ingredients; 
    }


    // Main program class
    class Program
    {
        static void Main(string[] args)
        {
            Recipe recipe = new Recipe(); // Create new recipe object

            // Get recipe details from user
            Console.WriteLine("*** Enter recipe details ***");

            Console.Write("Enter the name of the recipe: ");

            recipe.Name = Console.ReadLine();

            Console.Write("Number of ingredients: ");

            recipe.NumIngredients = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < recipe.NumIngredients; i++)
            {
                Console.WriteLine("Ingredient " + (i + 1) + ":");

                Console.Write("Name: ");
                string ingredientName = Console.ReadLine();

                Console.Write("Quantity: ");
                string ingredientQuantity = Console.ReadLine();

                Console.Write("Unit of measurement: ");
                string ingredientUnit = Console.ReadLine();

                recipe.Ingredients.Add(ingredientName + " - " + ingredientQuantity + " " + ingredientUnit);
            }

            Console.Write("Number of steps: ");
            recipe.NumSteps = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < recipe.NumSteps; i++)
            {
                Console.WriteLine("Step " + (i + 1) + ":");
                Console.Write("Description: ");
                string stepDescription = Console.ReadLine();
                recipe.Steps.Add(stepDescription);
            }

            Console.WriteLine();

            // Display recipe
            Console.WriteLine("*** Recipe ***");
            Console.WriteLine();
            DisplayRecipe(recipe);
            //Console.WriteLine();
            Console.WriteLine("**************");

            // Handle user input for scaling and resetting recipe quantities
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine();

                Console.WriteLine("*** Select one of the different options ***");

                Console.WriteLine();

                Console.WriteLine("1. Scale the recipe");
                Console.WriteLine("2. Reset quantities");
                Console.WriteLine("3. Enter a new recipe");
                Console.WriteLine("4. Exit");

                Console.WriteLine();

                string input = Console.ReadLine();

                Console.WriteLine();

                switch (input)
                {
                    case "1":
                        Console.WriteLine();
                        Console.Write("*** Enter scaling factor ***");
                        Console.WriteLine();

                        Console.WriteLine("1. Scaling by 0.5");
                        Console.WriteLine("2. Scaling by 2");
                        Console.WriteLine("3. Scaling bby 3");
                        Console.WriteLine();

                        double scale = Convert.ToDouble(Console.ReadLine());
                        ScaleRecipe(recipe, scale);
                        DisplayRecipe(recipe);
                        break;

                    case "2":
                        ResetQuantities(recipe);
                        DisplayRecipe(recipe);
                        break;

                    case "3":
                        recipe = new Recipe();
                        Console.WriteLine();
                        Console.WriteLine("Enter recipe details:");
                        Console.Write("Name: ");
                        recipe.Name = Console.ReadLine();

                        Console.Write("Number of ingredients: ");
                        recipe.NumIngredients = Convert.ToInt32(Console.ReadLine());

                        for (int i = 0; i < recipe.NumIngredients; i++)
                        {
                            Console.WriteLine("Ingredient " + (i + 1) + ":");
                            Console.Write("Name: ");
                            string ingredientName = Console.ReadLine();
                            Console.Write("Quantity: ");
                            string ingredientQuantity = Console.ReadLine();
                            Console.Write("Unit of measurement: ");
                            string ingredientUnit = Console.ReadLine();
                            recipe.Ingredients.Add(ingredientName + " - " + ingredientQuantity + " " + ingredientUnit);
                        }

                        Console.Write("Number of steps: ");
                        recipe.NumSteps = Convert.ToInt32(Console.ReadLine());

                        for (int i = 0; i < recipe.NumSteps; i++)
                        {
                            Console.WriteLine("Step " + (i + 1) + ":");
                            Console.Write("Description: ");
                            string stepDescription = Console.ReadLine();
                            recipe.Steps.Add(stepDescription);
                        }

                        Console.WriteLine();
                        DisplayRecipe(recipe);
                        break;

                    case "4":
                        exit = true;
                        break;

                    default:
                        Console.WriteLine("Invalid input.");
                        break;
                }
            }
        }





        // Method to display a recipe
        static void DisplayRecipe(Recipe recipe)
        {
            Console.WriteLine("Name of the recipe: " + recipe.Name);
            Console.WriteLine();

            Console.WriteLine("Ingredients:");
            foreach (string ingredient in recipe.Ingredients)
            {
                Console.WriteLine(" - " + ingredient);
            }
            Console.WriteLine();

            Console.WriteLine("Steps:");
            for (int i = 0; i < recipe.NumSteps; i++)
            {
                Console.WriteLine(" " + (i + 1) + ". " + recipe.Steps[i]);
            }
            Console.WriteLine();
        }





       
        // Method to scale a recipe by a given factor
        static void ScaleRecipe(Recipe recipe, double scale)
        {
            for (int i = 0; i < recipe.NumIngredients; i++)
            {
                string ingredient = recipe.Ingredients[i];

                string[] parts = ingredient.Split(new string[] { " - " }, StringSplitOptions.None);

                string name = parts[0];

                string quantityUnit = parts[1];

                string[] quantityUnitParts = quantityUnit.Split(' ');

                double quantity = Convert.ToDouble(quantityUnitParts[0]);

                string unit = quantityUnitParts[1];

                quantity *= scale;

                recipe.Ingredients[i] = name + " - " + Math.Round(quantity, 2) + " " + unit;
            }
        }






        // Method to reset recipe quantities to their original values
        static void ResetQuantities(Recipe recipe)
        {
            for (int i = 0; i < recipe.NumIngredients; i++)
            {
                string ingredient = recipe.Ingredients[i];

                string[] parts = ingredient.Split(new string[] { " - " }, StringSplitOptions.None);

                string name = parts[0];

                string quantityUnit = parts[1];

                recipe.Ingredients[i] = name + " - " + quantityUnit;
            }
        }




    }
}

