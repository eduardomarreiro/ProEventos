using ProEventos.Application.Dtos;
using System.Threading.Tasks;

namespace ProEventos.Application.Interfaces.IService
{
    public interface IEventoService
    {
        Task<EventoDto> AddEvento(EventoDto evento);
        Task<EventoDto> UpdateEvento(int eventoId, EventoDto evento);
        Task<bool> DeletEvento(int eventoId);

        Task<EventoDto[]> GetAllEventosByTemaAsync(string tema, bool includePalestrantes = false);
        Task<EventoDto[]> GetAllEventosAsync(bool includePalestrantes = false);
        Task<EventoDto> GetEventosByIdAsync(int eventoId, bool includePalestrantes = false);
    }
}
