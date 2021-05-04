using ApiTimeJogador_LuxOne.Iterfaces;
using ApiTimeJogador_LuxOne.Models;
using ApiTimeJogador_LuxOne.Models.Validacao;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiTimeJogador_LuxOne.Controllers
{
    [Route("/api/[controller]/[action]")]
    [ApiController]
    public class JogadoresController : ControllerBase
    {
        private readonly IJogadoresService _jogadoresService;
        private readonly JogadorValidator validator = new JogadorValidator();

        public JogadoresController(IJogadoresService jogadoresService)
        {
            _jogadoresService = jogadoresService;
        }

        // GET: api/Jogadores
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Jogador>>> Get()
        {
            var jogadores = await _jogadoresService.Get();
            return Ok(jogadores);
        }

        // GET: api/Jogadores/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Jogador>> GetID(int id)
        {
            var jogador = await _jogadoresService.GetID(id);

            if (jogador == null)
            {
                return NotFound();
            }

            return jogador;
        }

  
        [HttpPost]
        public async Task<ActionResult<Jogador>> Salvar(Jogador jogador)
        {
            validator.ValidateAndThrow(jogador);
            await _jogadoresService.Salvar(jogador);
            

            return CreatedAtAction("GetID", new { id = jogador.JogadorID }, jogador);
        }

    }
}
