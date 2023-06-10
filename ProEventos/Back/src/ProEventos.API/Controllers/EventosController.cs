using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProEventos.Persistence;
using ProEventos.Domain;
using ProEventos.Persistence.Contextos;
using ProEventos.Application.Contratos;
using Microsoft.AspNetCore.Http;

namespace ProEventos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventosController : ControllerBase
    {      
        
        private readonly InterfaceEventoService _eventoService;

        public EventosController(InterfaceEventoService eventoService)
        {
            _eventoService = eventoService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var eventos = await _eventosService.GetAllEventosAsync(true);
                if (eventos ==null) return NotFound("Nenhum evento encontrado");

                return Ok(eventos);
            }
            catch (Exception ex)
            {
                
                return this.StatusCode(StatusCodes.Status500internalServerError,
                $"Erro ao Tentar Recuperar eventos. Erro:{ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task <IActionResult> GetById(int id)
        {
            try
            {
                var evento = await _eventosService.GetEventoByIdAsync(id, true);
                if (evento ==null) return NotFound("Id do evento não encontrado");

                return Ok(evento);
            }
            catch (Exception ex)
            {
                
                return this.StatusCode(StatusCodes.Status500internalServerError,
                $"Erro ao Tentar Recuperar eventos. Erro:{ex.Message}");
            }
        }

        [HttpGet("{tema}/tema")]
        public async Task <IActionResult> GetByTema(string tema)
        {
            try
            {
                var evento = await _eventosService.GetAllEventosByTemaAsync (tema, true);
                if (evento ==null) return NotFound("Tema de evento não encontrado");

                return Ok(evento);
            }
            catch (Exception ex)
            {
                
                return this.StatusCode(StatusCodes.Status500internalServerError,
                $"Erro ao Tentar Recuperar eventos. Erro:{ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(Evento model)
        {
            try
            {
                var evento = await _eventosService.AddEventos (model);
                if (evento == null) return BadRequest("Erro ao adicionar evento");

                return Ok(evento);
            }
            catch (Exception ex)
            {
                
                return this.StatusCode(StatusCodes.Status500internalServerError,
                    $"Erro ao Tentar Recuperar eventos. Erro:{ex.Message}");
            }
        }

        [HttpPut ("{id}")]
        public string Put(int id)
        {
            return $@"{id}";
        }

        [httpDelete("{id}")]

        public string Delete(int id)
        {
            return $@"{id}";
        }



    }
}
