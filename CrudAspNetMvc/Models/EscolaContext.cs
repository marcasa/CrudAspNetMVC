using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CrudAspNetMvc.Models
{
    public class EscolaContext : DbContext
    {
        public EscolaContext() : base("BPTRAN")
        {
            Database.CreateIfNotExists();
        }

        public DbSet<Aluno> Alunos { get; set; }
    }
}