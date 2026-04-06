using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using copaHAS.Data;
using copaHAS.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace copaHAS.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EstadioController : ControllerBase
    {
        private readonly DataContext _context;
        public EstadioController(DataContext context)
        {
            _context = context;
        }

        private static List<Estadio> listaEstadios = new List<Estadio>
        {
            new Estadio(){Nome="NeoQuímica Arena", Id=1, Cidade="São Paulo", Capacidade=46000},
                new Estadio(){Nome="Allianz Parque", Id=2, Cidade="São Paulo", Capacidade=45000},
                new Estadio(){Nome="Maracanã", Id=3, Cidade="Rio de Janeiro", Capacidade=75000},
                new Estadio(){Nome="Morumbi", Id=4, Cidade="São Paulo", Capacidade=47000},
                new Estadio(){Nome="Castelão", Id=5, Cidade="São Paulo", Capacidade=30000},
                new Estadio(){Nome="Brinco de Ouro", Id=6, Cidade="São Paulo", Capacidade=20000},
                new Estadio(){Nome="Camp Nou", Id=7, Cidade="São Paulo", Capacidade=50000},
                new Estadio(){Nome="Allianz Arena", Id=8, Cidade="São Paulo", Capacidade=60000},
                new Estadio(){Nome="Vila Belmiro", Id=9, Cidade="São Paulo", Capacidade=20000},
                new Estadio(){Nome="Arena Barueri", Id=10, Cidade="São Paulo", Capacidade=20000}
        };

        [HttpGet("GetAll")]
        public IActionResult ObterEstadios()
        {
            List<Estadio> lista = listaEstadios;
            return Ok(lista);
        } 

        [HttpPost]
        public IActionResult InserirEstadio(Estadio j)
        {
            listaEstadios.Add(j);
            return Ok(listaEstadios);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            listaEstadios.RemoveAll(j => j.Id == id);
            return Ok(listaEstadios);
        }

        
        

    }

}