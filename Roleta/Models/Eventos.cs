namespace DokkanBattleRoleta.Models
{
    public class Evento
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public List<int> RanksElegiveis { get; set; }
    }

}
