using DokkanBattleRoleta.Models;

public static class CondicoesData
{
    public static List<Condicao> Condicoes = new List<Condicao>
    {
        new Condicao { Id = 1, Descricao = "🚫 No Item" },
        new Condicao { Id = 2, Descricao = "🎒 1 Item" },
        new Condicao { Id = 3, Descricao = "🎒🎒 2 Items" },
        new Condicao { Id = 4, Descricao = "💾 Support Memory" },
        new Condicao { Id = 5, Descricao = "🎒 1 Item + 💾 Support Memory" },
        new Condicao { Id = 6, Descricao = "🎒🎒 2 Items + 💾 Support Memory" },
        new Condicao { Id = 7, Descricao = "🏆 Usar o líder da categoria + 🎒💾 Items" },
        new Condicao { Id = 8, Descricao = "🏆 Usar o líder da categoria + 🚫 No Item" },

    };
}
