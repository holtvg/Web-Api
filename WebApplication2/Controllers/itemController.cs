using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class itemController : ApiController
    {
        //item[] inventory = new item[]
        //{
        //    new item { id = 1, name = "ketchup", category = "food", price = 1 },
        //    new item { id = 2, name = "bicycle", category = "outdoor", price = 3.75M },
        //    new item { id = 3, name = "burger", category = "food", price = 16.99M }
        //};

        //public IEnumerable<item> GetAllProducts()
        //{
        //    return inventory;
        //}

        //public IHttpActionResult GetProduct(int id)
        //{
        //    var product = inventory.FirstOrDefault((p) => p.id == id);
        //    if (product == null)
        //    {
        //        return NotFound();
        //    }
        //    return Ok(product);
        //}

        ////  public IHttpActionResult RemoveProduct(int id)
        //public void RemoveProduct(int id)
        //{
        //    var product = inventory.FirstOrDefault((p) => p.id == id);
        //    if (product == null)
        //    {
        //       // return NotFound();
        //    }
        //    // return null;
        // //   inventory.remove((p) => p.Id == id);
        //}

        //  static readonly IItemrepo repository = new Itemrepo();
        static readonly Itemrepo repository = new Itemrepo();

        public IEnumerable<item> GetAllProducts()
        {
            return repository.GetAll();
        }
       // [Route("api/item/{id}")]
        public item GetProduct(int id)
        {
            item prod = repository.Get(id);
            if (prod == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return prod;
        }

        //  public item GetProduct(string category)
        // [Route("api/item/{category}")]
        [ActionName("category")]
        public IEnumerable<item> GetProduct(string category)
        {
            //  item prod = repository.Get(category);
            //IEnumerable<item> prod = repository.Get(category);
            ////  if (prod == null)
            //if (prod.Equals(null))
            //    {
            //    throw new HttpResponseException(HttpStatusCode.NotFound);
            //}
            //return prod;

            return repository.Get(category);
        }

        //  public HttpResponseMessage PostProduct(Product item)
        public HttpResponseMessage PostProduct(item prod)
        {
            prod = repository.Add(prod);
            var response = Request.CreateResponse<item>(HttpStatusCode.Created, prod);

            string uri = Url.Link("DefaultApi", new { id = prod.id });
            response.Headers.Location = new Uri(uri);
            return response;
        }

          public void DeleteProduct(int id)
       // public void DeleteProduct(item prod)
        {
            //  repository.Remove(id);
            repository.Remove2(id);
            //  repository.Remove2(prod);
        }

        [ActionName("category")]
        public void DeleteProduct(string category)
        // public void DeleteProduct(item prod)
        {
            //  repository.Remove(id);
            repository.Remove2(category);
            //  repository.Remove2(prod);
        }

    }

    // interface IItemrepo
    //{
    //    IEnumerable<item> GetAll();
    //    item Get(int id);
    //    item Add(item prod);
    //    void Remove(int id);
    //    bool Update(item prod);
    //}
}
