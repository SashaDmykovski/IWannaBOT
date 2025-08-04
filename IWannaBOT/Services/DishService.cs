using IWannaBOT.Models;

namespace IWannaBOT.Services
{
    public class DishService
    {
        private readonly List<Dish> _dishes = new();
        private int _nextId = 1;

        public List<Dish> GetAll() => _dishes;

        public Dish Add(string text)
        {
            var dish = new Dish { Id = _nextId++, Text = text };
            _dishes.Add(dish);
            return dish;
        }
    }
}
