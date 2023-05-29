using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProEventos.API.Models;

namespace ProEventos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventoController : ControllerBase
    {
        private IEnumerable<Evento> _eventos = new List<Evento>
        {
            new Evento
            {
                EventoId = 1,
                Local = "Campo Grande",
                DataEvento = DateTime.Now.AddDays(2).ToString("dd/MM/yyyy"),
                Tema = "Angular e .NET 5",
                QtdPessoas = 250,
                Lote = "1º Lote",
                ImagemUrl = "foto.png"
            },
            new Evento
            {
                EventoId = 2,
                Local = "São Paulo",
                DataEvento = DateTime.Now.AddDays(3).ToString("dd/MM/yyyy"),
                Tema = "Angular e suas Novidades",
                QtdPessoas = 450,
                Lote = "2º Lote",
                ImagemUrl = "foto2.png"
            }
        };

        [HttpGet]
        public IEnumerable<Evento> Get()
        {
            return _eventos;
        }
    }
}
