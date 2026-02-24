using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.General;

namespace VotingList.Models
{
    public class CitizenDB : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=LAPTOP-F0CC84IM;Initial Catalog=VotersDB;Integrated Security=True ;trustservercertificate=true");
        }
        public DbSet<Votermod> Voters { get; set; } // This will create a table named "Voters" in the database to store voter information.
    }
}
