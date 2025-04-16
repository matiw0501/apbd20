using Microsoft.AspNetCore.Mvc;
using Tutorial6.Models;

namespace Tutorial6.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalsController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            var animals = Database.Animals;
            return Ok(animals);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var animal = Database.Animals.FirstOrDefault(x => x.Id == id);
            return Ok(animal);
        }

        [HttpPost("{id}, {name}, {category}, {weight}, {color}")]
        public IActionResult Post(int id, string name, string category, int weight, string color)
        {
            Animal animal = new Animal() { Id = id, Name = name, category = category, weight = weight, color = color };
           Database.Animals.Add(animal); 
           return Ok();
        }

    }
}