using System.ComponentModel.DataAnnotations;

namespace PolyglotAPI.Entities
{
    public class Professor
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Especializacao { get; set; }
        public int Experiencia { get; set; }

    }
}