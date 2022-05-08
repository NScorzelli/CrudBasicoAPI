using FilmesAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilmeController : ControllerBase
    {
        private static List<Filme> filmes = new List<Filme>();
        private static int _id = 1;

        // CRUD = CREATE - READ - UPDATE - DELETE


        [HttpPost]
        public IActionResult AdicionaFilme([FromBody] Filme filme)
        {
            filmes.Add(filme);
            filme.Id = _id++;
            Console.WriteLine(filme.Titulo);
            return CreatedAtAction(nameof(GetFilmeById), new { Id = filme.Id }, filme);
        }

        [HttpGet]
        public IActionResult RecuperaFilme()
        {
            return Ok(filmes);
        }

        [HttpGet("{Id}")]
        public IActionResult GetFilmeById(int id)
        {
            foreach (Filme filme in filmes)
            {
                if (filme.Id == id) 
                {
                    return Ok(filme);
                }
            }
            return NotFound();
        } 
    }
}
