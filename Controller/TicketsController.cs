using HahnApp_MEJRHIRROU.Data;
using HahnApp_MEJRHIRROU.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HahnApp_MEJRHIRROU.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketsController : ControllerBase
    {
        private readonly ContactlyDbContext dbContext;

        public TicketsController(ContactlyDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetAllTickets()
        {
            var tickets = dbContext.Tickets.ToList();
            return Ok(tickets);
        }

        [HttpPost]
        public IActionResult AddTicket(AddTicketRequestDTO request)
        {
            var domainModelTicket = new Ticket
            {
                Ticket_Id = Guid.NewGuid(),
                Description = request.Description,
                Date = System.DateTime.Now,
                Status = request.Status,
            };

            dbContext.Tickets.Add(domainModelTicket);
            dbContext.SaveChanges();

            return Ok(domainModelTicket);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public IActionResult DeleteTicket(Guid id)
        {
            var ticket = dbContext.Tickets.Find(id);

            if(ticket is not null)
            {
                dbContext.Tickets.Remove(ticket);
                dbContext.SaveChanges();

            }

            return Ok();
        }

        [HttpPut("{id:guid}")]
        public IActionResult UpdateTicket(Guid id, UpdateTicketRequestDTO request)
        {
            // Rechercher le ticket dans la base de données
            var existingTicket = dbContext.Tickets.FirstOrDefault(t => t.Ticket_Id == id);

            // Si le ticket n'existe pas, retourner 404 Not Found
            if (existingTicket == null)
            {
                return NotFound($"Ticket with ID {id} not found.");
            }

            // Mettre à jour les propriétés du ticket existant avec les données de la requête
            existingTicket.Description = request.Description;
            existingTicket.Status = request.Status;

            // Sauvegarder les modifications dans la base de données
            dbContext.SaveChanges();

            // Retourner un succès avec les nouvelles données du ticket
            return Ok(existingTicket);
        }
    }
}
