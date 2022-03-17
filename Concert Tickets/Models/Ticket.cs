using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Concert_Tickets.Models
{
    public class Ticket
    {
        [Key]
        public int ID { get; set; }
        public int Price { get; set; }
        public bool TicketType { get; set; } //true -> pit, false -> floor
        
    }
}