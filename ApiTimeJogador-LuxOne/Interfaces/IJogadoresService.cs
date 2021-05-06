﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiTimeJogador_LuxOne.Models;
using ApiTimeJogador_LuxOne.Models.DTQ;

namespace ApiTimeJogador_LuxOne.Iterfaces
{
    public interface IJogadoresService
    {
        Task<IEnumerable<Jogador>> Get();
        Task<IEnumerable<Jogador>> BuscaJogadoresPorTime(int id);
        Task<IEnumerable<Jogador>> BuscaPorIdade(int idade);
        Task<Jogador> Salvar(JogadorSalvarDTQ jogadorSalvarQuery);
    }
}
