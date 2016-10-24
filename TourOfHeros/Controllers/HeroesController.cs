using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TourOfHeros.Models;

namespace TourOfHeros.Controllers
{
    public class HeroesController : ApiController
    {

        public static List<Hero> data = new List<Hero>() {
            new Hero(){ id= 11, name= "Mr. Nice" },
            new Hero() { id= 12, name= "Narco" },
            new Hero() { id= 13, name= "Bombasto" },
            new Hero() { id= 14, name= "Celeritas" },
            new Hero() { id= 15, name= "Magneta" },
            new Hero() { id= 16, name= "RubberMan" },
            new Hero() { id= 17, name= "Dynama" },
            new Hero() { id= 18, name= "Dr IQ" },
            new Hero() { id= 19, name= "Magma" },
            new Hero() { id= 20, name= "Tornado" }
            };

        public List<Hero> Get()
        {
            return data;
        }

        public List<Hero> Get(string name)
        {
            var lowername = name.ToLower();
            if (string.IsNullOrWhiteSpace(name))  return data;
            return data.Where(x => x.name.ToLower().Contains(lowername)).ToList();
        }

        public Hero Post([FromBody] Hero  hero)
        {
            var maxid = data.Max(x => x.id);
            hero.id = maxid+1;
            data.Add(hero);
            return hero;
        }

        public void Delete(int id)
        {
            data = data.Where(d => d.id != id).ToList();
        }

        public void Put(int id, [FromBody] Hero hero)
        {
            var updatedHero = data.Where(d => d.id == id).FirstOrDefault();
            if (updatedHero != null) updatedHero.name = hero.name;
        }
    }
}
