using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DaxxTestProject.Models
{
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual List<State> States { get; set; }
    }
}