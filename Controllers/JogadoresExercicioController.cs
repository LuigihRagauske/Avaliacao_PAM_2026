using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using copaHAS.Models;
using copaHAS.Models.Enums;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace copaHAS.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class JogadoresExercicioController : ControllerBase
    {
        private static List<Jogador> listaJogadores = new List<Jogador>
        {
            new Jogador(){Nome="Tevez", Id=1, NumeroCamisa=10, Posicao="Meio-Campo", Status=Models.Enums.StatusJogador.TITULAR},
            new Jogador(){Nome="Cassio", Id=2, NumeroCamisa=12, Posicao="Goleiro", Status=Models.Enums.StatusJogador.TITULAR},
            new Jogador(){Nome="Ronaldo", Id=3, NumeroCamisa=9, Posicao="Atacante", Status=Models.Enums.StatusJogador.TITULAR},
            new Jogador(){Nome="Fagner", Id=4, NumeroCamisa=23, Posicao="Lateral Direito", Status=Models.Enums.StatusJogador.TITULAR},
            new Jogador(){Nome="Gil", Id=5, NumeroCamisa=4, Posicao="Zagueiro", Status=Models.Enums.StatusJogador.TITULAR},
            new Jogador(){Nome="Renato Augusto", Id=6, NumeroCamisa=8, Posicao="Meio-Campo", Status=Models.Enums.StatusJogador.TITULAR},
            new Jogador(){Nome="Paulinho", Id=7, NumeroCamisa=15, Posicao="Meio-Campo", Status=Models.Enums.StatusJogador.TITULAR},
            new Jogador(){Nome="Yuri Alberto", Id=8, NumeroCamisa=9, Posicao="Atacante", Status=Models.Enums.StatusJogador.TITULAR},
            new Jogador(){Nome="Roger Guedes", Id=9, NumeroCamisa=10, Posicao="Atacante", Status=Models.Enums.StatusJogador.TITULAR},
            new Jogador(){Nome="Fabio Santos", Id=10, NumeroCamisa=6, Posicao="Lateral Esquerdo", Status=Models.Enums.StatusJogador.TITULAR}
        };

        [HttpGet("GetByNome/{nome}")]
        public IActionResult Obter(string nome)
        {
            List<Jogador> lista = listaJogadores.FindAll(j => j.Nome.ToLower().Contains(nome.ToLower()));
            if (lista.Count == 0)
            {
                return NotFound("O jogador consultado não está na lista");
            }
            else
            {
                return Ok(lista);
            }
        }

        [HttpGet("GetTitulares")]
        public IActionResult GetTitulares()
        {
            List<Jogador> titulares = listaJogadores.FindAll(j => j.Status == Models.Enums.StatusJogador.TITULAR);
            return Ok(titulares);
        }

        [HttpGet("GetEstatisticas")]
        public IActionResult GetEstat()
        {
            return Ok("Soma das camisas =" + listaJogadores.Sum(j => j.NumeroCamisa));
        }

        [HttpGet("GetByStatus/{status}")]
        public IActionResult GetS(string status)
        {
            List<Jogador> stat = listaJogadores.FindAll(j => (int)j.Status == int.Parse(status));
            return Ok(stat); 
        }

        [HttpPost("PostValidacao")]
        public IActionResult PostV(Jogador j)
        {
            if(j.NumeroCamisa < 100)
            {
            listaJogadores.Add(j);
            }
            else
            {
                return BadRequest("Não pode adicionar jogadores com numero da camisa maior ou igual a 100");
            }
            return Ok(listaJogadores);
            
        }
        [HttpPost("PostValidacaoNome")]
        public IActionResult PostVNM(Jogador j)
        {
            if(j.NumeroCamisa == 1)
            {
            if(j.Posicao == "Goleiro")
                {
                    listaJogadores.Add(j);
                }
            else
            {
                return BadRequest("Jogadores de linha não podem usar o número 1");
            }
            }
            listaJogadores.Add(j);
            return Ok(listaJogadores);
            
        }



    };
    
}
