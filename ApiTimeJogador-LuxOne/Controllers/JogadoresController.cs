using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiTimeJogador_LuxOne.Data;
using FluentValidation;
using ApiTimeJogador_LuxOne.Models;
using ApiTimeJogador_LuxOne.Models.Validacao;
using ApiTimeJogador_LuxOne.Services;

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

        

       /* private bool JogadorExists(int id)
        {
            return _context.Jogadores.Any(e => e.JogadorID == id);
        }*/
    }
}
