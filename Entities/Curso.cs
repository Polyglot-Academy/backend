namespace PolyglotAPI.Entities
{
    public class Curso
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Nivel { get; set; }
        public int Duracao { get; set; }
        public int ProfessorId { get; set; }
        public DateTime DataInicio { get; set; }
        public double Valor { get; set; }
    }
}
