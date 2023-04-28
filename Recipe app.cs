using System;

namespace RecipeApp
{
    public class Ingredient
    {
        public string Name { get; set; }
        public double Quantity { get; set; }
        public string Unit { get; set; }
    }

    public class Step
    {
        public string Description { get; set; }
    }

    public class Recipe
    {
        public Ingredient[] Ingredients { get; set; }
        public Step[] Steps { get; set; }

        public Recipe()
        {
            Ingredients = new Ingredient[0];
            Steps = new Step[0];
        }

        public void Display()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Ingredients:\n");

            Console.ForegroundColor = ConsoleColor.White;
            foreach (var ingredient in Ingredients)
            {
                Console.WriteLine($"{ingredient.Quantity} {ingredient.Unit} {ingredient.Name}");
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nSteps:\n");

            Console.ForegroundColor = ConsoleColor.White;
            for (int i = 0; i < Steps.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {Steps[i].Description}");
            }
        }

        public void Scale(double factor)
        {
            foreach (var ingredient in Ingredients)
            {
                ingredient.Quantity *= factor;
            }
        }

        public void Reset()
        {
            foreach (var ingredient in Ingredients)
            {
                ingredient.Quantity /= 2;
            }
        }

        public void Clear()
        {
            Ingredients = new Ingredient[0];
            Steps = new Step[0];
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Recipe recipe = new Recipe();

            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Select an option:");

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("1. Enter ingredient details");
                Console.WriteLine("2. Enter step details");
                Console.WriteLine("3. Display recipe");
                Console.WriteLine("4. Scale recipe");
                Console.WriteLine("5. Reset recipe");
                Console.WriteLine("6. Clear recipe");
                Console.WriteLine("7. Exit");

                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Enter the number of ingredients:");
                        int numIngredients = int.Parse(Console.ReadLine());

                        Ingredient[] ingredients = new Ingredient[numIngredients];

                        for (int i = 0; i < numIngredients; i++)
                        {
                            Ingredient ingredient = new Ingredient();

                            Console.WriteLine($"Enter the name of ingredient {i + 1}:");
                            ingredient.Name = Console.ReadLine();

                            Console.WriteLine($"Enter the quantity of ingredient {i + 1}:");
                            ingredient.Quantity = double.Parse(Console.ReadLine());

                            Console.WriteLine($"Enter the unit of measurement of ingredient {i + 1}:");
                            ingredient.Unit = Console.ReadLine();

                            ingredients[i] = ingredient;
                        }

                        recipe.Ingredients = ingredients;

                        break;

                    case 2:
                        Console.WriteLine("Enter the number of steps:");
                        int numSteps = int.Parse(Console.ReadLine());

                        Step[] steps = new Step[numSteps];

                        for (int i = 0; i < numSteps; i++)
                        {
                            Step step = new Step();

                            Console.WriteLine($"Enter the description of step {i + 1}:");
                            step.Description = Console.ReadLine();

                            steps[i] = step;
                        }

                        recipe.Steps = steps;

                        break;

                    case 3:
                        recipe.Display();
                        break;

                    case 4:
                        Console.WriteLine("Enter the scale factor (0.5, 2, or 3):");
                        double factor = double.Parse(Console.ReadLine());

                        recipe.Scale(factor);
                        recipe.Display();

                        break;

                    case 5:
                        recipe.Reset();
                        recipe.Display();

                        break;

                    case 6:
                        recipe.Clear();
                        break;

                    case 7:
                        Environment.Exit(0);
                        break;
                }
            }
        }
    }
}
