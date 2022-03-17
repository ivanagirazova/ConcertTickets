using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Concert_Tickets.Models
{
    public class Concert
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string Artist { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required] 
        [Display(Name = "Number of floor tickets")]
        [Range(1,10000,ErrorMessage = "Please enter a number between 1 and 10000")]
        public int FloorTickets { get; set; }

        [Required]
        [Display(Name = "Floor ticket price")]
        [Range(100, int.MaxValue, ErrorMessage = "Please enter a price above 100")]
        public int FloorTicketPrice { get; set; }

        [Required] 
        [Display(Name = "Number of pit tickets")]
        [Range(1, 500, ErrorMessage = "Please enter a number between 1 and 500")]
        public int PitTickets { get; set; }

        [Required]
        [Display(Name = "Pit ticket price")]
        [Range(1000, int.MaxValue, ErrorMessage = "Please enter a price above 1000")]
        public int PitTicketPrice { get; set; }

        [Display(Name = "Floor tickets left")]
        public int countFloor { get; set; }

        [Display(Name = "Pit tickets left")]
        public int countPit { get; set; }

        [Display(Name ="Please enter the number of floor tickets you wish to buy:")]
        public int numberOfTicketsFloor { get; set; }

        [Display(Name = "Please enter the number of pit tickets you wish to buy:")]
        public int numberOfTicketsPit { get; set; }

    }
}