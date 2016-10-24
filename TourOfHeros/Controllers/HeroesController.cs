using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TourOfHeros.Models;

namespace TourOfHeros.Controllers
{
    /// <summary>
    /// Demonstration WEBApi contrller. Its purpose is to demonstrate that API works with the HTML5 routing. 
    /// </summary>
    public class HeroesController : ApiController
    {
        /// <summary>
        /// This is not a good way to make a database.
        /// Its not thread safe, or scalable.
        /// Or persistent.
        /// However, its fine for a single user machine to test routes.
        /// </summary>
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


        /// <summary>
        /// Return all the data
        /// </summary>
        /// <returns>All the data</returns>
        public List<Hero> Get()
        {
            return data;
        }

        /// <summary>
        /// Return all matching data (used by the hero-search.service)
        /// </summary>
        /// <param name="name">Text to search for</param>
        /// <returns>Matching Heros</returns>
        public List<Hero> Get(string name)
        {
            var lowername = name.ToLower();
            if (string.IsNullOrWhiteSpace(name))  return data;
            return data.Where(x => x.name.ToLower().Contains(lowername)).ToList();
        }

        /// <summary>
        /// Create a new hero
        /// </summary>
        /// <param name="hero">Hero to create. Id is ignored.</param>
        /// <returns>Created hero with new id</returns>
        public Hero Post([FromBody] Hero  hero)
        {
            var maxid = data.Max(x => x.id);
            hero.id = maxid+1;
            data.Add(hero);
            return hero;
        }

        /// <summary>
        /// Delete the reqested hero
        /// </summary>
        /// <param name="id">id of hero to delete</param>
        public void Delete(int id)
        {
            data = data.Where(d => d.id != id).ToList();
        }

        /// <summary>
        /// Update a hero
        /// </summary>
        /// <param name="id">id of record to update</param>
        /// <param name="hero">hero record with data to update</param>
        public void Put(int id, [FromBody] Hero hero)
        {
            var updatedHero = data.Where(d => d.id == id).FirstOrDefault();
            if (updatedHero != null) updatedHero.name = hero.name;
        }
    }
}
