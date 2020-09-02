using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace MvcDemo.Models
{
    public class MovieDB    //模型命名为MovieDB，能确保连击上数据库表MovieDBs
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Director { get; set; }
        public DateTime Date { get; set; }

    }
    public class MovieDBContext : DbContext
    {
        public DbSet<MovieDB> Movies { get; set; }
    }
}