using IWannaBOT.Models;
using System.Collections.Generic;

namespace IWannaBOT.Services
{
    public class OptionsService : IOptionsService
    {
        private readonly List<OptionItem> _items = new();

        public List<OptionItem> GetAll() => _items;

        public void Add(OptionItem item)
        {
            if (!string.IsNullOrWhiteSpace(item.Name))
                _items.Add(item);
        }
    }
}