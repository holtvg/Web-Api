using System.Collections.Generic;

namespace WebApplication2.Models
{
    public interface IItemrepo
    {
        IEnumerable<item> GetAll();
        item Get(int id);
        item Add(item prod);
        void Remove(int id);
        bool Update(item prod);
    }
}