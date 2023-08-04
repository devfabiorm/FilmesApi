using System.ComponentModel.DataAnnotations;

namespace FilmesApi.Context.Dtos
{
    public class UpdateFilmeDto
    {
        [Required(ErrorMessage = "O título é obrigatório")]
        [StringLength(50, ErrorMessage = "O Título pode ter no máximo 50 caracteres")]
        public string Titulo { get; set; }
        [Required(ErrorMessage = "O gênero é obrigatório")]
        [StringLength(50, ErrorMessage = "O Gênero pode ter no máximo 50 caracteres")]
        public string Genero { get; set; }
        [Required(ErrorMessage = "O campo de duração é obrigatório")]
        [Range(70, 600, ErrorMessage = "A duração do filme deve ter entre 70 e 600 minutos")]
        public int Duracao { get; set; }
    }
}
