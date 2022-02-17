using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Agenda
    {
        public int id { get; set; }

        public string note { get; set; }
        [DataType(DataType.Date)]
        public DateTime WhenToComplete { get; set; }

    }
}