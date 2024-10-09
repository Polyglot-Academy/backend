namespace PolyglotAPI.Entities
{
    public class Curso
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string descricao { get; set; }
        public int Nivel { get; set; }
        public double duracao { get; set; }
        public int ProfessorID { get; set; }
        public DateTime DataInicio { get; set; }
        public double valor { get; set; }
    }

}
