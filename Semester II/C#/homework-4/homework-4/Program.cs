using homework_4;

Food[] menu = new Food[]
{
    new Pizza("Margherita", 8.99, new string[] {"Tomato sauce", "Mozzarella cheese", "Fresh basil"}),
    new Salad("Caesar", 6.49, "Caesar"),
    new Pizza("Pepperoni", 10.99, new string[] {"Tomato sauce", "Mozzarella cheese", "Pepperoni"}),
    new Salad("Greek", 7.99, "Greek yogurt")
};

foreach (var food in menu)
{
    Console.WriteLine($"Preparing {food.Name}...");
    food.Cook();
    Console.WriteLine();
}