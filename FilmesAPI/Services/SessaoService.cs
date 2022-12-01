using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Data.Dtos.SessaoDto;
using FilmesAPI.Models;
using MySqlX.XDevAPI;

namespace FilmesAPI.Services
{
    public class SessaoService
    {
        private AppDbContext _context;
        private IMapper _mapper;
        public SessaoService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public Sessao AdicionaSessao(CreateSessaoDto dto)
        {
            Sessao sessao = _mapper.Map<Sessao>(dto);
            _context.Sessoes.Add(sessao);
            _context.SaveChanges();
            return sessao;
        }
        public IEnumerable<Sessao> RecuperaSessoes()
        {
            List<Sessao> sessoes = new List<Sessao>();
            foreach(Sessao sessao in _context.Sessoes) 
            {
                sessoes.Add(sessao);
            }
            foreach (Sessao sessao in sessoes)
            {
                sessao.Cinema = _context.Cinemas.FirstOrDefault(cinema => cinema.Id == sessao.CinemaId);
                sessao.Filme = _context.Filmes.FirstOrDefault(filme => filme.Id == sessao.FilmeId);
            }

            return sessoes;
        }

        public ReadSessaoDto RecuperaSessaoPorId(int id)
        {
            Sessao sessao = _context.Sessoes.FirstOrDefault(sessao => sessao.Id == id);
            if (sessao != null)
            {
                ReadSessaoDto sessaoDto = _mapper.Map<ReadSessaoDto>(sessao);
                sessaoDto.Cinema = _context.Cinemas.FirstOrDefault(cinema => sessaoDto.CinemaId == cinema.Id);
                sessaoDto.Filme = _context.Filmes.FirstOrDefault(filme => sessaoDto.FilmeId == filme.Id);
                return sessaoDto;
            }
            return null;
        }
    }
}
