using AutoMapper;
using ProEventos.Application.Dtos;
using ProEventos.Application.Interfaces.IService;
using ProEventos.Domain.Interfaces.IRepository;
using ProEventos.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProEventos.Application.Services
{
    public class EventoService : IEventoService
    {
        private readonly IEventoRepository _eventoRepo;
        private readonly IRepository _repo;
        private readonly IMapper _mapper;

        public EventoService(IEventoRepository eventoRepo, IRepository repo, IMapper mapper)
        {
            _eventoRepo = eventoRepo;
            _repo = repo;
            _mapper = mapper;
        }
        public async Task<EventoDto> AddEvento(EventoDto model)
        {
            try
            {
                var evento = _mapper.Map<Evento>(model);

                _repo.Add<Evento>(evento);

                if (await _repo.SavaChangesAsync())
                {
                    var eventoRetorno = await _eventoRepo.GetEventosByIdAsync(evento.Id, false);

                    return _mapper.Map<EventoDto>(eventoRetorno);
                }
                return null;

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<EventoDto> UpdateEvento(int eventoId, EventoDto model)
        {
            try
            {
                var evento = await _eventoRepo.GetEventosByIdAsync(eventoId, false);
                if (evento == null) return null;

                model.Id = evento.Id;

                _mapper.Map(model, evento);

                _repo.Update<Evento>(evento);

                if (await _repo.SavaChangesAsync())
                {
                    var eventoRetorno = await _eventoRepo.GetEventosByIdAsync(evento.Id, false);

                    return _mapper.Map<EventoDto>(eventoRetorno);
                }
                return null;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeletEvento(int eventoId)
        {
            try
            {
                var evento = await _eventoRepo.GetEventosByIdAsync(eventoId, false);
                if (evento == null) throw new Exception("Evento não encontrado");

                _repo.Delete(evento);
                return await _repo.SavaChangesAsync();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<EventoDto[]> GetAllEventosAsync(bool includePalestrantes = false)
        {
            try
            {
                var eventos = await _eventoRepo.GetAllEventosAsync(includePalestrantes);
                if (eventos == null) return null;

                var eventosRetorno = new List<EventoDto>();

                var resultado = _mapper.Map<EventoDto[]>(eventos);

                return resultado;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<EventoDto[]> GetAllEventosByTemaAsync(string tema, bool includePalestrantes = false)
        {
            try
            {
                var eventos = await _eventoRepo.GetAllEventosByTemaAsync(tema, includePalestrantes);
                if (eventos == null) return null;

                var resultado = _mapper.Map<EventoDto[]>(eventos);

                return resultado;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<EventoDto> GetEventosByIdAsync(int eventoId, bool includePalestrantes = false)
        {
            try
            {
                var eventos = await _eventoRepo.GetEventosByIdAsync(eventoId, includePalestrantes);
                if (eventos == null) return null;

                var resultado = _mapper.Map<EventoDto>(eventos);

                return resultado;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
