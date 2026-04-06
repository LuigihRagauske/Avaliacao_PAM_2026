using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using copaHAS.Data;
using copaHAS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace copaHAS.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class JogadoresController : ControllerBase
    {
        private readonly DataContext _context;
        public JogadoresController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")] //Buscar pelo ID
        public async Task<IActionResult> GetSingle(int id)
        {
            try
            {
                Jogador j = await _context.TB_JOGADORES.FirstOrDefaultAsync(pBusca => pBusca.Id == id);
                return Ok(j);
            }
            catch(System.Exception ex)
            {
                return BadRequest(ex.Message + "-" + ex.InnerException);
            }

        }

        [HttpPost]
        public async Task<IActionResult> Add(Jogador novoJogador)
        {
            try
            {
                if (novoJogador.NumeroCamisa >= 100)
                return BadRequest("Número da camisa não pode ser maior/igual a 100");

                await _context.TB_JOGADORES.AddAsync(novoJogador);
                await _context.SaveChangesAsync();

                return Ok(novoJogador.Id);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message + "-" + ex.InnerException);
            }
        }

        /*private static List<Jogador> listaJogadores = new List<Jogador>
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

        [HttpGet("GetAll")]
        public IActionResult ObterJogadores()
        {
            List<Jogador> lista = listaJogadores;
            return Ok(lista);
        } 
        
        [HttpGet("Get")]
        public IActionResult GetFirst()
        {
            return Ok(listaJogadores[0]);
        }

        [HttpPost]
        public IActionResult InserirJogador(Jogador j)
        {
            listaJogadores.Add(j);
            return Ok(listaJogadores);
        }

        [HttpGet("GetOrdenado")]

        public IActionResult GetOrder()
        {
            List<Jogador> listaFinal = listaJogadores.OrderBy(j => j.Nome).ToList();
            return Ok(listaFinal);
        }

        [HttpPut("AtualizarJogador")]

        public IActionResult Att(Jogador j)
        {
            Jogador jEncontrado = listaJogadores.Find(jBusca => jBusca.Id == j.Id);

            if(jEncontrado == null)
                return BadRequest("Esse ID nn existe, seu boca aberta");

            jEncontrado.Nome = j.Nome;
            jEncontrado.NumeroCamisa = j.NumeroCamisa;

            return Ok(listaJogadores);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            listaJogadores.RemoveAll(j => j.Id == id);
            return Ok(listaJogadores);
        }

        [HttpGet("GetByNmA/{nome}")]

        public IActionResult GetByNomeApromikado(string nome)
        {
            List<Jogador> lista = listaJogadores.FindAll(j => j.Nome.ToLower().Contains(nome.ToLower()));
            return Ok(lista);
        } */
    }

}
