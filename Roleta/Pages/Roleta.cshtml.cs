using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using DokkanBattleRoleta.Data;
using DokkanBattleRoleta.Models;
using System;
using System.Linq;
using System.Collections.Generic;

namespace DokkanBattleRoleta.Pages
{
    public class RoletaModel : PageModel
    {
        public string Evento { get; set; }
        public string Categoria { get; set; }
        public string Condicao { get; set; }
        public List<Categoria> CategoriasFiltradas { get; set; } = new List<Categoria>();

        public int? EventoSelecionadoId
        {
            get => HttpContext.Session.GetInt32("EventoSelecionadoId");
            set => HttpContext.Session.SetInt32("EventoSelecionadoId", value.GetValueOrDefault());
        }

        public int? RankAssociado
        {
            get => HttpContext.Session.GetInt32("RankAssociado");
            set => HttpContext.Session.SetInt32("RankAssociado", value.GetValueOrDefault());
        }

        public void OnGet()
        {
            Evento = "";
            Categoria = "";
            Condicao = "";
            CategoriasFiltradas = new List<Categoria>();

            EventoSelecionadoId = HttpContext.Session.GetInt32("EventoSelecionadoId");
            RankAssociado = HttpContext.Session.GetInt32("RankAssociado");

            if (RankAssociado.HasValue)
            {
                CategoriasFiltradas = CategoriasData.Categorias
                    .Where(c => c.Rank == RankAssociado.Value)
                    .ToList();
            }
        }

        public void OnPostRodarRoleta()
        {
            var random = new Random();

            var eventoSelecionado = EventosData.Eventos[random.Next(EventosData.Eventos.Count)];
            Evento = eventoSelecionado.Nome;
            EventoSelecionadoId = eventoSelecionado.Id;
            RankAssociado = eventoSelecionado.RanksElegiveis?.FirstOrDefault();

            if (RankAssociado.HasValue)
            {
                CategoriasFiltradas = CategoriasData.Categorias
                    .Where(c => c.Rank == RankAssociado.Value)
                    .ToList();
            }
            else
            {
                CategoriasFiltradas = new List<Categoria>();
            }

            if (CategoriasFiltradas.Any())
            {
                Categoria = CategoriasFiltradas[random.Next(CategoriasFiltradas.Count)].Nome;
            }
            else
            {
                Categoria = "Nenhuma categoria disponível para o evento selecionado.";
            }

            if (CondicoesData.Condicoes != null && CondicoesData.Condicoes.Any())
            {
                Condicao = CondicoesData.Condicoes[random.Next(CondicoesData.Condicoes.Count)].Descricao;
            }
            else
            {
                Condicao = "Nenhuma condição disponível.";
            }
        }
    }
}
