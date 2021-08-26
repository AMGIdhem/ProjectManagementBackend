using MongoDB.Driver;
using System;
using System.Collections.Generic;

namespace Bookstore.Core
{
    public class TicketService : ITicketServices
    {

        private readonly IMongoCollection<Ticket> _tickets;
        public TicketService(IDbClient dbClient)
        {
            _tickets = dbClient.GetTicketsCollection();
        }

        public Ticket AddTicket(Ticket ticket)
        {
            _tickets.InsertOne(ticket);
            return ticket;
        }

        public void DeleteTicket(string id)
        {
            _tickets.DeleteOne(ticket => ticket.Id == id);
        }

        public Ticket GetTicket(string id) => _tickets.Find(ticket => ticket.Id == id).First();

        public List<Ticket> GetTickets()
        {
            return _tickets.Find(ticket => true).ToList();
        }

        public List<Ticket> GetTicketsByProject(string projectId)
        {
            return _tickets.Find(ticket => ticket.ProjectId == projectId).ToList();
        }

        public Ticket UpdateTicket(Ticket ticket)
        {
            GetTicket(ticket.Id);
            _tickets.ReplaceOne(t => t.Id == ticket.Id, ticket);
            return ticket;
        }
    }
}
