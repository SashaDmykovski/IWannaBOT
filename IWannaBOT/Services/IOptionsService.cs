using IWannaBOT.Models;
using System.Collections.Generic;

namespace IWannaBOT.Services
{
    public interface IOptionsService
    {
        List<OptionItem> GetAll();
        void Add(OptionItem item);
    }
}