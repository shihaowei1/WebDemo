using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;


namespace LoginTest.Models
{
    public class LoginDB
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public string passwd { get; set; }
    }

    public class LoginDBContext : DbContext
    {
        public DbSet<LoginDB> Others { get; set; }
    }
}