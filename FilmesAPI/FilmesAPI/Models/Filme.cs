using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FilmesAPI.Models
{
    public class Filme
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O título é obrigatório.")]
        [StringLength(30, ErrorMessage = "O tamanho do título deve ser inferior a 30 caracteres.")]
        public string Titulo { get; set; }
        public string Diretor { get; set; }
        public string Genero { get; set; }

        [Range(1,600, ErrorMessage = "A duração do filme deve ser entre 1 minuto e 600 minutos.")]
        public int Duracao { get; set; }
    }
}
