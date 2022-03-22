using ProEventos.Domain.Interfaces.IRepository;
using ProEventos.Domain.Interfaces.IService;
using ProEventos.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProEventos.Application.Services
{
    public class EventoService : IEventoService
    {
        private readonly IEventoRepository _eventoRepo;
        private readonly IRepository _repo;

        public EventoService(IEventoRepository eventoRepo, IRepository repo)
        {
            _eventoRepo = eventoRepo;
            _repo = repo;
        }
        public async Task<Evento> AddEvento(Evento model)
        {
            try
            {
                _repo.Add<Evento>(model);
                if(await _repo.SavaChangesAsync())
                {
                    return await _eventoRepo.GetEventosByIdAsync(model.Id, false);
                }
                return null;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<Evento> UpdateEvento(int eventoId, Evento model)
        {
            try
            {
                var evento = await _eventoRepo.GetEventosByIdAsync(eventoId, false);
                if (evento == null) return null;

                model.Id = evento.Id;

                _repo.Update(model);
                if (await _repo.SavaChangesAsync())
                {
                    return await _eventoRepo.GetEventosByIdAsync(evento.Id, false);
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

        public async Task<Evento[]> GetAllEventosAsync(bool includePalestrantes = false)
        {
            try
            {
                var eventos = await _eventoRepo.GetAllEventosAsync(includePalestrantes);
                if (eventos == null) return null;

                return eventos;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool includePalestrantes = false)
        {
            try
            {
                var eventos = await _eventoRepo.GetAllEventosByTemaAsync(tema, includePalestrantes);
                if (eventos == null) return null;

                return eventos;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<Evento> GetEventosByIdAsync(int eventoId, bool includePalestrantes = false)
        {
            try
            {
                var eventos = await _eventoRepo.GetEventosByIdAsync(eventoId, includePalestrantes);
                if (eventos == null) return null;

                return eventos;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
