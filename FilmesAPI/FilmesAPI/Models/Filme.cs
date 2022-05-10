using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FilmesAPI.Models
{
    public class Filme
    {

        [Key][Required]
        public int Id { get; set; }
        [Required(ErrorMessage ="O campo título é obrigatório.")][StringLength(30, ErrorMessage = "O título deve possuir 30 caracteres ou menos.")]
        public string Titulo { get; set; }
        public string Genero { get; set; }
        public string Diretor { get; set; }
        [Required][Range(1,600,ErrorMessage = "A duração em minutos de um filme deve estar entre 1 e 600 minutos.")]
        public int Duracao { get; set; }

    }
}
