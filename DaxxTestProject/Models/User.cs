using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DaxxTestProject.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public bool AgreeToWorkForFood { get; set; }
        public int CountryId { get; set; }
        public int StateId { get; set; }
        public virtual Country Country { get; set; }
        public virtual State State { get; set; }
    }
}