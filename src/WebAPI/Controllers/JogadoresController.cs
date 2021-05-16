using ApiTimeJogador_LuxOne.Iterfaces;
using ApiTimeJogador_LuxOne.Models;
using ApiTimeJogador_LuxOne.Models.DTQ;
using ApiTimeJogador_LuxOne.Models.Validacao;
using FluentValidation;
using LuxOne.Model.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net;
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
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.NoContent)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(List<JogadorDTO>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Jogador>>> Get()
        {
            List<JogadorDTO> jogadores = await _jogadoresService.Get();
            return Ok(jogadores);
        }

        [HttpGet]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.NoContent)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(List<Jogador>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Jogador>>> BuscarTimeID([FromQuery] int id)
        {
            IEnumerable<Jogador> jogador = await _jogadoresService.BuscaJogadoresPorTime(id);

            if (jogador == null)
            {
                return NotFound();
            }

            return Ok(jogador);
        }

       
        [HttpGet]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.NoContent)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(List<Jogador>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Jogador>> BuscaPorIdade(int idade)
        {
            IEnumerable<Jogador> jogador = await _jogadoresService.BuscaPorIdade(idade);

            if (jogador == null)
            {
                return NotFound();
            }

            return Ok(jogador);

        }

        [HttpPost]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.NoContent)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(List<Jogador>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Jogador>> Salvar(JogadorSalvarDTQ jogadorSalvarQuery)
        {
            if (jogadorSalvarQuery is null)
                return BadRequest(jogadorSalvarQuery);

            validator.ValidateAndThrow(jogadorSalvarQuery);
            Jogador jogador = await _jogadoresService.Salvar(jogadorSalvarQuery);
          
            return CreatedAtAction("Get", new { id = jogador.JogadorID }, jogador);
        }

    }
}
