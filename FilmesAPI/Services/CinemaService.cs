using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Data.Dtos.CinemaDto;
using FilmesAPI.Data.Dtos.EnderecoDto;
using FilmesAPI.Data.Dtos.GerenteDto;
using FilmesAPI.Data.Dtos.SessaoDto;
using FilmesAPI.Models;
using FluentResults;

namespace FilmesAPI.Services
{
    public class CinemaService
    {
        private AppDbContext _context;
        private IMapper _mapper;
        public CinemaService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public Cinema AdicionaCinema(CreateCinemaDto cinemaDto)
        {
            Cinema cinema = _mapper.Map<Cinema>(cinemaDto);
            _context.Cinemas.Add(cinema);
            _context.SaveChanges();
            return cinema;
        }

        public List<Cinema> RecuperaCinemas()
        {
            List<Cinema> cinemas = new List<Cinema>();
            foreach (Cinema cinema in _context.Cinemas)
            {
                cinemas.Add(cinema);
            }
            foreach (Cinema c in cinemas)
            {
                c.Endereco = _context.Enderecos.FirstOrDefault(endereco => endereco.Id == c.EnderecoId);
                c.Gerente = _context.Gerentes.FirstOrDefault(gerente => gerente.Id == c.GerenteId);
            }
            return cinemas;
        }

        public ReadCinemaDto RecuperaCinemaPorId(int id)
        {
            Cinema cinema = _context.Cinemas.FirstOrDefault(cinema => cinema.Id == id);
            return GetCinemaDto(cinema);
        }

        public Result AtualizaCinema(int id, UpdateCinemaDto cinemaDto)
        {
            Cinema cinema = _context.Cinemas.FirstOrDefault(cinema => cinema.Id == id);
            if (cinema == null)
            {
                return Result.Fail("Cinema não encontrado");
            }
            _mapper.Map(cinemaDto, cinema);
            _context.SaveChanges();
            return Result.Ok();
        }

        public Result DeletaCinema(int id)
        {
            Cinema cinema = _context.Cinemas.FirstOrDefault(cinema => cinema.Id == id);
            if (cinema == null)
            {
                return Result.Fail("Cinema não encontrado");
            }
            _context.Remove(cinema);
            _context.SaveChanges();
            return Result.Ok();
        }
        private ReadCinemaDto GetCinemaDto(Cinema cinema)
        {
            ReadCinemaDto cinemaDto = _mapper.Map<ReadCinemaDto>(cinema);
            Endereco endereco = _context.Enderecos.FirstOrDefault(endereco => endereco.Id == cinema.EnderecoId);
            Gerente gerente = _context.Gerentes.FirstOrDefault(gerente => gerente.Id == cinema.GerenteId);
            List<Sessao> sessoes = new List<Sessao>();
            foreach (Sessao sessao in _context.Sessoes)
            {
                sessoes.Add(sessao);
            }

            cinemaDto.Endereco = _mapper.Map<GetEnderecoDto>(endereco);
            cinemaDto.Gerente = _mapper.Map<GetGerenteDto>(gerente);
            foreach (Sessao sessao in sessoes)
            {
                if (sessao.CinemaId == cinema.Id)
                {
                    cinemaDto.Sessao = new List<GetSessaoDto>();
                    sessao.Cinema = _context.Cinemas.FirstOrDefault(cinema => cinema.Id == sessao.CinemaId);
                    sessao.Filme = _context.Filmes.FirstOrDefault(filme => filme.Id == sessao.FilmeId);
                    cinemaDto.Sessao.Add(_mapper.Map<GetSessaoDto>(sessao));
                }
            }

            return cinemaDto;
        }
    }
}
