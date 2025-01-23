using Microsoft.AspNetCore.Mvc;
using DokkanBattleRoleta.Models;
using DokkanBattleRoleta.Data;
using System;
using System.Linq;

public class RoletaController : Controller
{
    public IActionResult Index()
    {
        var random = new Random();
        var evento = EventosData.Eventos[random.Next(EventosData.Eventos.Count)];
        var categoria = CategoriasData.Categorias
            .Where(c => evento.RanksElegiveis.Contains(c.Rank)) // Filtra categorias baseadas nos ranks elegíveis do evento
            .OrderBy(c => random.Next()) // Embaralha as categorias restantes
            .FirstOrDefault();
        var condicao = CondicoesData.Condicoes[random.Next(CondicoesData.Condicoes.Count)];

        ViewBag.Evento = evento;
        ViewBag.Categoria = categoria;
        ViewBag.Condicao = condicao;

        return View();
    }
}
