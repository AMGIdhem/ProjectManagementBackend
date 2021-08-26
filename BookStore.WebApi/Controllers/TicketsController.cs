using Bookstore.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TicketsController : ControllerBase
    {
        private readonly ITicketServices _ticketServices;
        private readonly IProjectServices _projectServices;

        public TicketsController(ITicketServices ticketServices, IProjectServices _projectServices)
        {
            _ticketServices = ticketServices;
            this._projectServices = _projectServices;
        }

        [HttpGet]
        public IActionResult GetTickets()
        {
            return Ok(_ticketServices.GetTickets());
        }

        [HttpGet("{projectId}/project", Name = "GetTicketsByProject")]
        public IActionResult GetTicketsByProject(string projectId)
        {
            return Ok(_ticketServices.GetTicketsByProject(projectId));
        }


        [HttpPost]
        public IActionResult AddTicket(Ticket ticket)
        {
            var project = _projectServices.GetProject(ticket.ProjectId);
            ticket.Project = project;
            _ticketServices.AddTicket(ticket);

            return CreatedAtRoute("GetTicket", new { id = ticket.Id }, ticket);
        }

        [HttpGet("{id}", Name = "GetTicket")]
        public IActionResult GetTicket(string id)
        {
            return Ok(_ticketServices.GetTicket(id));
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTicket(string id)
        {
            _ticketServices.DeleteTicket(id);
            return NoContent();
        }

        [HttpPut]
        public IActionResult UpdateTicket(Ticket ticket)
        {
            return Ok(_ticketServices.UpdateTicket(ticket));
        }
    }
}
