using PizzaDeliveryApi.Models;

namespace PizzaDeliveryApi.Services
{
    public class DrinkService
    {
        static List<Drink> Drinks { get; }
        static int nextId = 3;
        static DrinkService()
        {
            Drinks = new List<Drink>
        {
            new Drink { Id = 1, Name = "Orange juice", Descripiton = "Fresh juice from the best oranges" },
            new Drink { Id = 2, Name = "Pepsi", Descripiton = "Cool" }
        };
        }

        public static List<Drink> GetAll() => Drinks;

        public static Drink? Get(int id) => Drinks.FirstOrDefault(p => p.Id == id);

        public static void Add(Drink drink)
        {
            drink.Id = nextId++;
            Drinks.Add(drink);
        }

        public static void Delete(int id)
        {
            var drink = Get(id);
            if (drink is null)
                return;

            Drinks.Remove(drink);
        }

        public static void Update(Drink drink)
        {
            var index = Drinks.FindIndex(p => p.Id == drink.Id);
            if (index == -1)
                return;

            Drinks[index] = drink;
        }
    }
}

