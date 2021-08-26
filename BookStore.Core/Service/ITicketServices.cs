using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore.Core
{
    public interface ITicketServices
    {
        List<Ticket> GetTickets();
        List<Ticket> GetTicketsByProject(string projectId);
        Ticket GetTicket(string id);
        Ticket AddTicket(Ticket ticket);
        void DeleteTicket(string id);
        Ticket UpdateTicket(Ticket ticket);
    }
}
