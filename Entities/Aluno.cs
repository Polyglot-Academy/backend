﻿using System.ComponentModel.DataAnnotations;

namespace PolyglotAPI.Entities
{
    public class Aluno
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        
    }

}
