using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Data.Dtos.GerenteDto;
using FilmesAPI.Models;
using FluentResults;
using Microsoft.AspNetCore.Mvc;

namespace FilmesAPI.Services
{
    public class GerenteService
    {
        private AppDbContext _context;
        private IMapper _mapper;

        public GerenteService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public Gerente AdicionaGerente(CreateGerenteDto enderecoDto)
        {
            Gerente endereco = _mapper.Map<Gerente>(enderecoDto);
            _context.Gerentes.Add(endereco);
            _context.SaveChanges();
            return endereco;
        }

        public IEnumerable<Gerente> RecuperaGerentes()
        {
            return _context.Gerentes;
        }
        public ReadGerenteDto RecuperaGerentePorId(int id)
        {
            Gerente endereco = _context.Gerentes.FirstOrDefault(endereco => endereco.Id == id);
            if (endereco != null)
            {
                ReadGerenteDto enderecoDto = _mapper.Map<ReadGerenteDto>(endereco);

                return enderecoDto;
            }
            return null;
        }
        public Result DeletaGerente(int id)
        {
            Gerente endereco = _context.Gerentes.FirstOrDefault(endereco => endereco.Id == id);
            if (endereco == null)
            {
                return Result.Fail("Gerente não encontrado");
            }
            _context.Remove(endereco);
            _context.SaveChanges();
            return Result.Ok();
        }
    }
}
