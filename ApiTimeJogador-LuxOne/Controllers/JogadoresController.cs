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

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Jogador>>> Get()
        {
            var jogadores = await _jogadoresService.Get();
            return Ok(jogadores);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Jogador>>> BuscarTimeID( int id)
        {
            var jogador = await _jogadoresService.BuscaJogadoresPorTime(id);

            if (jogador == null)
            {
                return NotFound();
            }

            return Ok(jogador);
        }

       
        [HttpGet]
        public async Task<ActionResult<Jogador>> BuscaPorIdade(int idade)
        {
            var jogador = await _jogadoresService.BuscaPorIdade(idade);

            if (jogador == null)
            {
                return NotFound();
            }

            return Ok(jogador);

        }

        [HttpPost]
        public async Task<ActionResult<Jogador>> Salvar(Jogador jogador)
        {
            validator.ValidateAndThrow(jogador);
            await _jogadoresService.Salvar(jogador);
            

            return CreatedAtRoute("DefaultApi", new { id = jogador.JogadorID }, jogador);
        }

    }
}
