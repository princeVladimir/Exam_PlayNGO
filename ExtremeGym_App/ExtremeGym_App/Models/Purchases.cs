using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ExtremeGym_App.Models
{
    public class Purchases
    {
        public int Id { get; set; }

        public string MembersID { get; set; }

        public string Item { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }

        
        public DateTime Date { get; set; }
    }
}