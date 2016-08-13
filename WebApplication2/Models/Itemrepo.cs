using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;

namespace WebApplication2.Models
{
    //  public class Itemrepo : IItemrepo
    public class Itemrepo :INotifyPropertyChanged
    {
          private List<item> prods = new List<item>();

        private ObservableCollection<item> prods2 = new ObservableCollection<item>();

        public event PropertyChangedEventHandler PropertyChanged;


        //item[] prods = new item[]
        //{
        //    new item { id = 1, name = "ketchup", category = "food", price = 1 },
        //    new item { id = 2, name = "bicycle", category = "outdoor", price = 3.75M },
        //    new item { id = 3, name = "burger", category = "food", price = 16.99M }
        //};
        //  private int _nextId = 1;

        public Itemrepo()
        {
            Add(new item { id = 1, name = "ketchup", category = "food", price = 1 });
            Add(new item { id = 2, name = "ibuprophen", category = "drugs", price = 8.99M });
            Add(new item { id = 3, name = "burger", category = "food", price = 6.99M });
            //  prods.Add(new item { id = 4, name = "mustard", category = "food", price = 1 });
            prods2.Add(new item { id = 4, name = "mustard", category = "food", price = 1 });
          //  prods
         // prods2

            prods2.CollectionChanged += myList_CollectionChanged;
        }

        private void myList_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add)
            {
                
            }
        }

        public IEnumerable<item> GetAll()
        {
            //  return prods;
            return prods2;
        }

        //public IEnumerable<item> GetAll2() 
        //{
        //    return prods2;
        //}

        public item Get(int id)
        {
            // return prods.Find(p => p.id == id);
            if (!prods2.Contains(new item { id = id }))
            {
                throw new ArgumentNullException("item");
            }
            return prods2.Single(p => p.id == id);
          //  return prods2.Single(p => p.Equals(id));
        }

        public IEnumerable<item> Get(string category)
        {
            // return prods.Find(p => p.id == id);
            if (!prods2.Contains(new item { category = category }))
            {
              //  throw new ArgumentNullException("item");
            }
            // return prods2.Single(p => p.category == category);
            //  return prods2.SingleOrDefault(p => p.category.Equals(category));
            return prods2.Where(p => p.category == category);
        }

        //public item Get2(int id)
        //{
        //  //  return prods2.Find(p => p.id == id);


        //}

        public item Add(item prod)
        {
            if (prod == null)
            {
              //  throw new ArgumentNullException("item");
            }

            //  prod.id = _nextId++;
            //  prods.Add(prod);
            prods2.Add(prod);
            return prod;
        }

        public void Remove(int id)
        {
            //  prods.Remove(id);
            prods.RemoveAll(p => p.id == id);
           // prods2.Remove()
          //  prods2.RemoveAt(id);
          //  _nextId--;
            //  prods.Remove(p => p.id == id);
        }

        //public void Remove2(item prod)
        //{
        //    if (prod == null)
        //    {
        //        throw new ArgumentNullException("item");
        //    }

        //    //  prod.id = _nextId++;

        //    prods2.Remove(prod);

        //}

        public void Remove2(int id)
        {
            //  prods.Remove(id);
            // prods2.Remove(p.id == id);
            prods2.Remove(new item { id = id });
            // prods2.Remove()
            //  prods2.RemoveAt(id);
            //  _nextId--;
            //  prods.Remove(p => p.id == id);

            //var q = prods2.Where(p => p.id == id).FirstOrDefault();
            //if (q != null)
            //{
            //    prods2.
            //}
            //else
            //{

            //}
        }


        public void Remove2(string category)
        {
            //  prods.Remove(id);
            // prods2.Remove(p.id == id);
            prods2.Remove(new item { category = category });
            // prods2.Remove()
            //  prods2.RemoveAt(id);
            //  _nextId--;
            //  prods.Remove(p => p.id == id);

            //var q = prods2.Where(p => p.id == id).FirstOrDefault();
            //if (q != null)
            //{
            //    prods2.
            //}
            //else
            //{

            //}
        }

        public bool Update(item prod)
        {
            throw new NotImplementedException();
        }
    }
}