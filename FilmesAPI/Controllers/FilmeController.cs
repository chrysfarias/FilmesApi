﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FilmesAPI.Models;


namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class FilmeController : ControllerBase
    {
        private static List<Filme> filmes = new List<Filme>();
        public static int id = 1;


        [HttpPost]
        public IActionResult AdicionaFilme([FromBody] Filme filme)
        {
            filme.Id = id++;
            filmes.Add(filme);
            return CreatedAtAction(nameof(RecuperaFilmesPorId), new { Id = filme.Id }, filme);
        }

        [HttpGet]
        public IActionResult RecuperaFilmes()
        {
            return Ok(filmes);
        }

        [HttpGet("{id}")]

        public IActionResult RecuperaFilmesPorId(int id)
        {
          Filme filme = filmes.FirstOrDefault(filme => filme.Id == id );
            if(filme != null)
            {
                return Ok(filme);            
            }
            return NotFound();
        }
    }
}

