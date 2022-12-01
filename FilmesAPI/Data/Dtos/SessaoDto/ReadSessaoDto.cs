﻿using FilmesAPI.Models;
using System.Text.Json.Serialization;

namespace FilmesAPI.Data.Dtos.SessaoDto
{
    public class ReadSessaoDto
    {
        public int Id { get; set; }
        [JsonIgnore]
        public int FilmeId { get; set; }
        [JsonIgnore]
        public int CinemaId { get; set; }
        public Cinema Cinema { get; set; }
        public Filme Filme { get; set; }
        public DateTime HorarioDeEncerramento { get; set; }
        public DateTime HorarioDeInicio { get; set; }
    }
}
