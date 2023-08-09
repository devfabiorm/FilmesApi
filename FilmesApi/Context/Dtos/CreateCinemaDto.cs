using System.ComponentModel.DataAnnotations;

namespace FilmesApi.Context.Dtos;

public class CreateCinemaDto
{
    [Required(ErrorMessage = "O campo de nome é obrigatório")]
    public string Nome { get; set; }
}
