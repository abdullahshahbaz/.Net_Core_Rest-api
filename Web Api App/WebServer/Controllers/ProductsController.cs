using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebServer.Models;

namespace WebServer.Controllers{

    [Route("api/[controller]")]
    public class ProductsController : Controller{

        //Get all Products
        [HttpGet]
        public Product[] Products(){
            Product[] all_products = new Product[FakeData.Products.Count];
            FakeData.Products.Values.CopyTo(all_products,0);
            if(all_products != null){
                return all_products;
            }
            else{
                return null;
            }
            
        }

        [HttpGet("{id}")]
        public Product GetById(int id){
            if(FakeData.Products.ContainsKey(id)){
                return FakeData.Products[id];      
            }
            else{
                return null;
            }
        }

        [HttpGet("price/{low}/{high}")]
        public Product[] GetByRange(int low, int high){
            var products = FakeData.Products.Values.
            Where(p => p.Price >= low && p.Price <= high).ToArray();
            return products;
        }

        [HttpDelete("{id}")]
        public void DeleteById(int id){
            if(FakeData.Products.ContainsKey(id)){
                FakeData.Products.Remove(id);
            }
        }

        [HttpPost]
        public Product Post([FromBody] Product p){
            p.ID = FakeData.Products.Count;
            FakeData.Products.Add(p.ID,p);
            return p;
        }

        [HttpPut("{id}")]
        public void Update(int id,[FromBody] Product p){
            if(FakeData.Products.ContainsKey(id)){
                var target = FakeData.Products[id];
                target.ID = p.ID;
                target.Name = p.Name;
                target.Price = p.Price;
            }
        }

        [HttpPut("raise/{value}")]
        public void UpdatePrice(int value){
            Product[] products = FakeData.Products.Values.ToArray();
            int i = 0;
            foreach (var item in  products){
                item.Price = item.Price * value;
                FakeData.Products[i] = item;
                i++;
            }
            
        }



    }
}