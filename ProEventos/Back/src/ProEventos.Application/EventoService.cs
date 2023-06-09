using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProEventos.Application.Contratos;
using ProEventos.Persistence;
using ProEventos.Persistence.Contratos;

namespace ProEventos.Application
{
    public class EventoService : InterfaceEventoService
    {
        public InterfaceEventoPersitence _eventoPersitence;
        private readonly InterfaceGeralPersistence _geralPersistence;
        public EventoService(InterfaceGeralPersistence geralPersistence, InterfaceEventoPersitence eventoPersitence)
        {
            this._eventoPersitence = eventoPersitence;
            this._geralPersistence = geralPersistence;

        }
        public async Task<Evento> AddEventos(Evento model)
        {
            try
            {
                _geralPersistence.Add<Evento>(model);
                if (await _geralPersistence.SaveChangesAsync())
                {
                    return await _eventoPersitence.GetEventosByIdAsync(model.Id, false);
                }
                return null;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public async Task<Evento> Updateevento(int eventoId, Evento model)
        {
            try
            {
                var evento = await _eventoPersitence.GetEventosByIdAsync(eventoId, false);
                if (evento == null) return null;

                model.Id = evento.Id;

                _geralPersistence.Update(model);
                if (await _geralPersistence.SaveChangesAsync())
                {
                    return await _eventoPersitence.GetEventosByIdAsync(model.Id, false);
                }
                return null;


            }

            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }


        public async Task<bool> DeleteEvento(int eventoId)
        {
            try
            {
                var evento = await _eventoPersitence.GetEventosByIdAsync(eventoId, false);
                if (evento == null) throw new Exception("Evento para delete não encontrado");

                _geralPersistence.Delete<Evento>(evento);
                return await _geralPersistence.SaveChangesAsync();
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
                var eventos = await _eventoPersitence.GetAllEventosAsync(includePalestrantes);
                if (eventos = null) return null;

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
                var eventos = await _eventoPersitence.GetAllEventosByTemaAsync(tema, includePalestrantes);
                if (eventos = null) return null;

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
                var eventos = await _eventoPersitence.GetEventosByIdAsync(eventoId, includePalestrantes);
                if (eventos = null) return null;

                return eventos;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }   

        }
    }
}