using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BikeStore.Data.Model
{
    public class Users
    {
        //public int UserId { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public DateTime CreateDate { get; set; }
        public bool Active { get; set; }
    }
}