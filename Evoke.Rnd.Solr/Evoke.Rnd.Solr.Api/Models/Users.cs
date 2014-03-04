using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Evoke.Rnd.Solr.Api.Models
{
    public class Users
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public int PhoneNo { get; set; }
        public string Email { get; set; }
        public string Company { get; set; }
        public string Designation { get; set; }
    }
}