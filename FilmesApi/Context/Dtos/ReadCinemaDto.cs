﻿namespace FilmesApi.Context.Dtos;

public class ReadCinemaDto
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public ReadEnderecoDto ReadEndereco { get; set; }
}
